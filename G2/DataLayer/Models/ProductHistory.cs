using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ProductHistory
    {
        public int ProductHistoryId { get; set; }
        public int ProductId { get; set; }
        public int CompanyId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
