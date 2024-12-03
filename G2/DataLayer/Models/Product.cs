using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Logo { get; set; }
        public string Overview { get; set; }
        public string Link { get; set; }
        public string ProductType { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public string Price { get; set; }
    }
}
