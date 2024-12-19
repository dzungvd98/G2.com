using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public required string CompanyName { get; set; }
        public int CountryId { get; set; }
        public int IndustryId { get; set; }
        public int CompanySizeId { get; set; }
        public string? CompanyLink { get; set; }
        public string? Email { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
