using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
    public class CategoryDetailsDTO
    {
        public string CategoryName { get; set; }
        public string ParentCategoryName { get; set; }
        public string TypeName { get; set; }
        public int ProductCount { get; set; }
    }
}
