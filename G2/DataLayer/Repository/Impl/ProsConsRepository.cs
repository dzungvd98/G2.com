using DataLayer.Database;
using DataLayer.DTO;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Impl
{
    public class ProsConsRepository : IProsConsRepository
    {
        private readonly ApplicationDbContext _context;

        public ProsConsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProsConsDTO>> GetProsAndConsOfProductByIdAsync(int productId)
        {
            var result = await _context.ProsCons
                .Join(_context.ReviewProsCons, pac => pac.ProsConsId, rpc => rpc.ProsConsId, (pac, rpc) => new { ProsCons =  pac, ReviewProsCons = rpc })
                .Join(_context.Reviews, combined => combined.ReviewProsCons.ReviewId, r => r.ReviewId, (combined, review) => new { combined.ProsCons, Review = review })
                .Where(combined => combined.Review.ProductId == productId)
                .GroupBy(combined => new { combined.ProsCons.ProsConsName, combined.ProsCons.IsPros })
                .Select(group => new ProsConsDTO
                {
                    ProsConsName = group.Key.ProsConsName,
                    IsPros = group.Key.IsPros,
                    CountRate = group.Count()
                }).ToListAsync();
            return result;
        } 
        }
    }
