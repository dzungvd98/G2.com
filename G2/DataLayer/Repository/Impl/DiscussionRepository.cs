using DataLayer.Database;
using DataLayer.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Impl
{
    public class DiscussionRepository : IDiscussionRepository
    {
        private readonly ApplicationDbContext _context;
        
        public DiscussionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiscussionDTO>> GetDiscussionOfProductByIdAsync(int productId)
        {
            var results =  await _context.Discussions
                .Where(d => d.ProductId == productId)
                .Join(_context.Users,
                    d => d.UserId,
                    u => u.UserId,
                    (d, u) => new { Discussion = d, User = u })
                .GroupJoin(_context.ReplyDiscussions,
                    du => du.Discussion.DiscussionId,
                    rd => rd.DiscussionId,
                    (du, replies) => new DiscussionDTO
                    {
                        DiscussionId = du.Discussion.DiscussionId,
                        Topic = du.Discussion.Topic,
                        Avatar = du.User.Avatar,
                        CountReply = replies.Count(),
                        CreatedAt = du.Discussion.CreatedAt,
                        UpdatedAt = du.Discussion.UpdatedAt,
                        UserId = du.Discussion.UserId,
                        Username = du.User.UserName
                    })
                .OrderByDescending(x => x.CountReply)
                .ToListAsync();
            
            return results;
        }
    }
}
