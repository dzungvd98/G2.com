using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("CompanySize")]
    public class CompanySize
    {
        public int CompanySizeId { get; set; }
        public required string CompanySizeName { get; set; }
    }
}
