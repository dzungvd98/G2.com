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
        public async Task<IEnumerable<ReviewDTO>> GetReviewDetailByProductID(int productID)
        {
            var topReviews = await _context.Reviews
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
                .Join(_context.ProsCons,
                    rucsv => rucsv.r.ReviewId,
                    rpc => rpc.ProsConsId,
                    (rucsv, pc) => new
                    {
                        rucsv.r,
                        rucsv.u,
                        rucsv.CompanySizeName,
                        rucsv.VideoRef,
                        ProsConsName = pc.ProsConsName
                    })
                .Where(x => x.r.ProductId == productID)
                .GroupJoin(
                            _context.ReviewsDetail.Join(_context.Criterias,
                                rd => rd.CriteriaId,
                                c => c.CriteriaId,
                                (rd, c) => new { rd, c }),
                            r => r.r.ReviewId,
                            rc => rc.rd.ReviewId,
                            (review, details) => new
                            {
                                review.r,
                                review.u,
                                review.CompanySizeName,
                                review.VideoRef,
                                review.ProsConsName,
                                CriteriaDetails = details.GroupBy(d => new { d.c.CriteriaName, d.rd.Rate })
                                                          .Select(grouped => new
                                                          {
                                                              CriteriaName = grouped.Key.CriteriaName,
                                                              RatingBreakdown = grouped.Count(),
                                                              OverallRating = grouped.Sum(g => g.rd.Rate) / grouped.Count(),
                                                              Ratings = grouped.Sum(g => g.rd.Rate) / grouped.Count()
                                                          }).ToList()
                            })

                .OrderByDescending(x => x.r.CreatedAt)
                .Take(2)
                .Select(x => new ReviewDTO
                {
                    UserName = x.u.UserName,
                    Rate = x.r.Rate,
                    Content = x.r.Content,
                    CompanySizeName = x.CompanySizeName,
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
                .ToListAsync();
            return topReviews;

        }
    }
}
