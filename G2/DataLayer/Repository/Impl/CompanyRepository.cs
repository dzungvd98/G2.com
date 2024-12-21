using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Impl
{
    public class CompanyRepository : ICompanyRepository
    {
        public Task AddCompanyAsync(Company company)
        { 
            throw new NotImplementedException();
        }

        public Task DeleteCompanyAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetAllCompanysAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetCompanyByIdAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCompanyAsync(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
