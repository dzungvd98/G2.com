using DataLayer.Database;
using DataLayer.DTO;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Impl
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            _context.Reviews.Add(review);           
            await _context.SaveChangesAsync();
            return review;
        }
        public async Task AddReviewDetailsAsync(IEnumerable<ReviewDetail> reviewDetails)
        {
            _context.ReviewsDetail.AddRange(reviewDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<Review?> GetReviewByIdAsync(int reviewId)
        {
            return await _context.Reviews
                .Include(r => r.ReviewProsCons) // Load các bảng liên quan nếu cần
                .Include(r => r.ReviewVideos)
                .Include(r => r.ReviewDetails)
                .FirstOrDefaultAsync(r => r.ReviewId == reviewId);
        }

        public async Task DeleteReviewAsync(Review review)
        {
            // Xóa các bản ghi liên quan trước
            _context.ReviewsDetail.RemoveRange(review.ReviewDetails);
            _context.ReviewProsCons.RemoveRange(review.ReviewProsCons);
            _context.ReviewVideos.RemoveRange(review.ReviewVideos);

            // Xóa review
            _context.Reviews.Remove(review);

            // Lưu thay đổi
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ReviewDTO>> GetReviewDetailByProductID(int productID)
        {

            // Lấy thông tin Reviews với Users (Left Join)
            var reviewsWithUsers = await (from r in _context.Reviews
                                          where r.ProductId == productID
                                          join u in _context.Users on r.UserId equals u.UserId into userGroup
                                          from user in userGroup.DefaultIfEmpty() // Left Join
                                          select new
                                          {
                                              Review = r,
                                              User = user
                                          }).ToListAsync();

            // Lấy thông tin Company (Left Join)
            var reviewsWithCompanies = (from rw in reviewsWithUsers
                                        join c in _context.Companies on rw.User.CompanyId equals c.CompanyId into companyGroup
                                        from company in companyGroup.DefaultIfEmpty() // Left Join
                                        select new
                                        {
                                            rw.Review,
                                            rw.User,
                                            Company = company
                                        }).ToList();

            // Lấy thông tin CompanySizes (Left Join)
            var reviewsWithCompanySizes = (from rwc in reviewsWithCompanies
                                           join cs in _context.CompanySizes on rwc.Company.CompanySizeId equals cs.CompanySizeId into sizeGroup
                                           from size in sizeGroup.DefaultIfEmpty() // Left Join
                                           select new
                                           {
                                               rwc.Review,
                                               rwc.User,
                                               rwc.Company,
                                               CompanySize = size
                                           }).ToList();

            // Lấy thông tin ReviewVideos (Left Join)
            var reviewsWithVideos = (from rwcs in reviewsWithCompanySizes
                                     join rv in _context.ReviewVideos on rwcs.Review.ReviewId equals rv.ReviewId into videoGroup
                                     from video in videoGroup.DefaultIfEmpty() // Left Join
                                     select new
                                     {
                                         rwcs.Review,
                                         rwcs.User,
                                         rwcs.Company,
                                         rwcs.CompanySize,
                                         Video = video
                                     }).ToList();

            // Lấy thông tin ProsCons (Left Join)
            var reviewsWithProsCons = (from rwv in reviewsWithVideos
                                       join rpc in _context.ReviewProsCons on rwv.Review.ReviewId equals rpc.ReviewId into prosConsGroup
                                       from prosCons in prosConsGroup.DefaultIfEmpty() // Left Join
                                       join pc in _context.ProsCons on prosCons.ProsConsId equals pc.ProsConsId into prosGroup
                                       from pros in prosGroup.DefaultIfEmpty() // Left Join
                                       select new
                                       {
                                           rwv.Review,
                                           rwv.User,
                                           rwv.Company,
                                           rwv.CompanySize,
                                           rwv.Video,
                                           ProsConsName = pros != null ? pros.ProsConsName : "Unknown"
                                       }).ToList();

            // Lấy thông tin chi tiết ReviewsDetails (Left Join)
            var reviewsDetails = await (from rd in _context.ReviewsDetail
                                        join c in _context.Criterias on rd.CriteriaId equals c.CriteriaId into criteriaGroup
                                        from criteria in criteriaGroup.DefaultIfEmpty() // Left Join
                                        select new
                                        {
                                            rd.ReviewId,
                                            CriteriaName = criteria != null ? criteria.CriteriaName : "Unknown",
                                            Rate = rd.Rate
                                        }).ToListAsync();

            // Lấy thông tin Like (GroupBy)
            var likes = await (from l in _context.Like
                               group l by l.ReviewId into likeGroup
                               select new
                               {
                                   ReviewId = likeGroup.Key,
                                   TotalLike = likeGroup.Count()
                               }).ToDictionaryAsync(x => x.ReviewId, x => x.TotalLike);

            // Kết hợp dữ liệu và map thành ReviewDTO
            var result = reviewsWithProsCons.Select(x => new ReviewDTO
            {
                UserName = x.User != null ? x.User.UserName : "Unknown",
                Rate = x.Review.Rate,
                Content = x.Review.Content ?? "Unknown",
                CompanySizeName = x.CompanySize != null ? x.CompanySize.CompanySizeName : "Unknown",
                VideoRef = x.Video != null ? x.Video.VideoRef : "Unknown",
                ProsConsName = x.ProsConsName,
                TotalLike = likes.ContainsKey(x.Review.ReviewId) ? likes[x.Review.ReviewId] : 0,
                CriteriaRatings = reviewsDetails
                    .Where(detail => detail.ReviewId == x.Review.ReviewId)
                    .GroupBy(detail => detail.CriteriaName)
                    .Select(grouped => new CriteriaRatingDTO
                    {
                        CriteriaName = grouped.Key,
                        RatingBreakdown = grouped.Count(),
                        OverallRating = grouped.Average(g => g.Rate),
                        Ratings = grouped.Average(g => g.Rate)
                    }).ToList()
            }).OrderByDescending(r => r.TotalLike)
              .ThenByDescending(r => r.Rate)
              .ToList();
            return result;
        }

    }
}
