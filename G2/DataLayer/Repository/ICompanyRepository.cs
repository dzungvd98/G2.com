using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllCompanysAsync();
        Task<Company> GetCompanyByIdAsync(int companyId);
        Task AddCompanyAsync(Company company);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(int companyId);
    }
}
