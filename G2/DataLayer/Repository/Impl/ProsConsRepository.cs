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
                .Join(_context.ReviewProsCons, pac => pac.ProsConsId, rpc => rpc.ProsConsId, (pac, rpc) => new { pac, rpc })
                .Join(_context.Reviews, combined => combined.rpc.ReviewId, r => r.ReviewId, (combined, r) => new { combined.pac, r })
                .Where(combined => combined.r.ProductId == productId)
                .GroupBy(combined => new { combined.pac.ProsConsName, combined.pac.IsPros })
                .Select(g => new ProsConsDTO
                {
                    ProsConsName = g.Key.ProsConsName,
                    IsPros = g.Key.IsPros,
                    CountRate = g.Count()
                }).ToListAsync();
            return result;
        } 
        }
    }
