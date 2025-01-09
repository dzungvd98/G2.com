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

        public async Task<IEnumerable<ReviewDTO>> GetReviewDetailByProductID(int productID)
        {
            var reviews = await _context.Reviews
                .Join(_context.Users,
                    r => r.UserId,
                    u => u.UserId,
                    (r, u) => new { r, u })
                .Join(_context.Companies,
                    ru => ru.u.CompanyId,
                    c => c.CompanyId,
                    (ru, c) => new { ru.r, ru.u, c })
                .Join(_context.CompanySizes,
                    ruc => ruc.c.CompanySizeId,
                    cs => cs.CompanySizeId,
                    (ruc, cs) => new
                    {
                        ruc.r,
                        ruc.u,
                        CompanySizeName = cs.CompanySizeName
                    })
                .Join(_context.ReviewVideos,
                        rucs => rucs.r.ReviewId,
                        rv => rv.ReviewId,
                        (rucs, rv) => new
                        {
                            rucs.r,
                            rucs.u,
                            rucs.CompanySizeName,
                            rv.VideoRef
                        })
                .Join(_context.ReviewProsCons, 
                        rucsv => rucsv.r.ReviewId,
                        pcr => pcr.ReviewId,
                        (rucsv, pcr) => new { rucsv, pcr })
                .Join(_context.ProsCons,
                    rucsv_pcr => rucsv_pcr.pcr.ProsConsId,
                    pc => pc.ProsConsId,
                    (rucsv_pcr, pc) => new
                    {
                        rucsv_pcr.rucsv.r,
                        rucsv_pcr.rucsv.u,
                        rucsv_pcr.rucsv.CompanySizeName,
                        rucsv_pcr.rucsv.VideoRef,
                        ProsConsName = pc.ProsConsName, 
                        IsPros = pc.IsPros 
                    })
                .Where(x => x.r.ProductId == productID)
                .ToListAsync(); 
            var reviewsDetails = await _context.ReviewsDetail
                .Join(_context.Criterias,
                    rd => rd.CriteriaId,
                    c => c.CriteriaId,
                    (rd, c) => new { rd, c })
                .ToListAsync(); 

            var likes = await _context.Like.ToListAsync(); 

            var result = reviews
                .GroupJoin(
                    reviewsDetails,
                    review => review.r.ReviewId,
                    detail => detail.rd.ReviewId,
                    (review, details) => new
                    {
                        review.r,
                        review.u,
                        review.CompanySizeName,
                        review.VideoRef,
                        review.ProsConsName,
                        CriteriaDetails = details
                            .GroupBy(d => d.c.CriteriaName)
                            .Select(grouped => new
                            {
                                CriteriaName = grouped.Key,
                                RatingBreakdown = grouped.Count(),
                                OverallRating = grouped.Average(g => g.rd.Rate),
                                Ratings = grouped.Average(g => g.rd.Rate)
                            }).ToList()
                    })
                .GroupJoin(
                    likes,
                    review => review.r.ReviewId,
                    like => like.ReviewId,
                    (review, likeGroup) => new
                    {
                        review.r,
                        review.u,
                        review.CompanySizeName,
                        review.VideoRef,
                        review.ProsConsName,
                        review.CriteriaDetails,
                        TotalLike = likeGroup.Count()
                    })
                .OrderByDescending(x => x.TotalLike)
                .ThenByDescending(x => x.r.CreatedAt)
                .Take(2)
                .Select(x => new ReviewDTO
                {
                    UserName = x.u.UserName,
                    Rate = x.r.Rate,
                    Content = x.r.Content,
                    CompanySizeName = x.CompanySizeName,
                    TotalLike = x.TotalLike,
                    VideoRef = x.VideoRef,
                    ProsConsName = x.ProsConsName,
                    CriteriaRatings = x.CriteriaDetails.Select(cd => new CriteriaRatingDTO
                    {
                        CriteriaName = cd.CriteriaName,
                        RatingBreakdown = cd.RatingBreakdown,
                        OverallRating = cd.OverallRating,
                        Ratings = cd.Ratings
                    }).ToList()
                })
                .ToList();

            return result;
        }

    }
}
