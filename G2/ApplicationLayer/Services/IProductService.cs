using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
    }
}
