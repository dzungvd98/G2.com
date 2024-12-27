using DataLayer.DTO;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IProsConsRepository
    {
        Task<IEnumerable<ProsConsDTO>> GetProsAndConsOfProductByIdAsync(int productId);
    }
}
