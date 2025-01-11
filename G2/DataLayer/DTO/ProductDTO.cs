using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public double AveragePoint {  get; set; }
        public int CountRate { get; set; }
    }
}
