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
            
            _context.ReviewsDetail.RemoveRange(review.ReviewDetails);
            _context.ReviewProsCons.RemoveRange(review.ReviewProsCons);
            _context.ReviewVideos.RemoveRange(review.ReviewVideos);

            _context.Reviews.Remove(review);

            
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ReviewDTO>> GetReviewDetailByProductID(int productID)
        {

            
            var reviewsWithUsers = await (from r in _context.Reviews
                                          where r.ProductId == productID
                                          join u in _context.Users on r.UserId equals u.UserId into userGroup
                                          from user in userGroup.DefaultIfEmpty()
                                          select new
                                          {
                                              Review = r,
                                              User = user
                                          }).ToListAsync();

            
            var reviewsWithCompanies = (from rw in reviewsWithUsers
                                        join c in _context.Companies on rw.User.CompanyId equals c.CompanyId into companyGroup
                                        from company in companyGroup.DefaultIfEmpty()
                                        select new
                                        {
                                            rw.Review,
                                            rw.User,
                                            Company = company
                                        }).ToList();

            
            var reviewsWithCompanySizes = (from rwc in reviewsWithCompanies
                                           join cs in _context.CompanySizes on rwc.Company.CompanySizeId equals cs.CompanySizeId into sizeGroup
                                           from size in sizeGroup.DefaultIfEmpty() 
                                           select new
                                           {
                                               rwc.Review,
                                               rwc.User,
                                               rwc.Company,
                                               CompanySize = size
                                           }).ToList();

            
            var reviewsWithVideos = (from rwcs in reviewsWithCompanySizes
                                     join rv in _context.ReviewVideos on rwcs.Review.ReviewId equals rv.ReviewId into videoGroup
                                     from video in videoGroup.DefaultIfEmpty()
                                     select new
                                     {
                                         rwcs.Review,
                                         rwcs.User,
                                         rwcs.Company,
                                         rwcs.CompanySize,
                                         Video = video
                                     }).ToList();


            var reviewsWithProsCons = (from rwv in reviewsWithVideos
                                       join rpc in _context.ReviewProsCons on rwv.Review.ReviewId equals rpc.ReviewId into prosConsGroup
                                       from prosCons in prosConsGroup.DefaultIfEmpty()
                                       join pc in _context.ProsCons on prosCons.ProsConsId equals pc.ProsConsId into prosGroup
                                       from pros in prosGroup.DefaultIfEmpty()
                                       select new
                                       {
                                           rwv.Review,
                                           rwv.User,
                                           rwv.Company,
                                           rwv.CompanySize,
                                           rwv.Video,
                                           ProsConsName = pros != null ? pros.ProsConsName : null
                                       })
                           .GroupBy(r => new
                           {
                               r.Review,
                               r.User,
                               r.Company,
                               r.CompanySize,
                               r.Video
                           })
                           .Select(grouped => new
                           {
                               grouped.Key.Review,
                               grouped.Key.User,
                               grouped.Key.Company,
                               grouped.Key.CompanySize,
                               grouped.Key.Video,
                               ProsConsNames = grouped.Where(g => g.ProsConsName != null).Select(g => g.ProsConsName).Distinct().ToList()
                           }).ToList();



            var reviewsDetails = await (from rd in _context.ReviewsDetail
                                        join c in _context.Criterias on rd.CriteriaId equals c.CriteriaId into criteriaGroup
                                        from criteria in criteriaGroup.DefaultIfEmpty() 
                                        select new
                                        {
                                            rd.ReviewId,
                                            CriteriaName = criteria != null ? criteria.CriteriaName : "Unknown",
                                            Rate = rd.Rate
                                        }).ToListAsync();

            
            var likes = await (from l in _context.Likes
                               group l by l.ReviewId into likeGroup
                               select new
                               {
                                   ReviewId = likeGroup.Key,
                                   TotalLike = likeGroup.Count()
                               }).ToDictionaryAsync(x => x.ReviewId, x => x.TotalLike);

            var result = reviewsWithProsCons.Select(x => new ReviewDTO
            {
                UserName = x.User != null ? x.User.UserName : "Unknown",
                Rate = x.Review.Rate,
                Content = x.Review.Content ?? "Unknown",
                CompanySizeName = x.CompanySize != null ? x.CompanySize.CompanySizeName : "Unknown",
                VideoRef = x.Video != null ? x.Video.VideoRef : "Unknown",
                ProsConsName = x.ProsConsNames,
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
