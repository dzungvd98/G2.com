using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ProductCategory {
        public int ProductCategoryId {  get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

    }
}
