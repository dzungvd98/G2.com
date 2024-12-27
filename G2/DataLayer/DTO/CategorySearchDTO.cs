using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
    public class CategorySearchDTO
    {
        public string Type { get; set; }
        public string SortBy { get; set; }
        public bool IsAscending { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
