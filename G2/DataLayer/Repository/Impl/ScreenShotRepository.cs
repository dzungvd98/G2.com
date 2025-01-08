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
    public class ScreenShotRepository : IScreenShotRepository
    {
        private readonly ApplicationDbContext _content;

        public ScreenShotRepository(ApplicationDbContext context)
        {
            _content = context;
        }

        public async Task<IEnumerable<ScreenShotsDTO>> GetScreenShotsByProductIdAsync(int productId)
        {
            var screenShots = await _content.ScreenShots
                .Where(s => s.ProductId == productId)
                .Select(s => new ScreenShotsDTO
                {
                    Description = s.Description,
                    IsImage = s.IsImage,
                    Link = s.Link,
                    Title = s.Title
                }).ToListAsync();
            return screenShots;
        }
    }
}
