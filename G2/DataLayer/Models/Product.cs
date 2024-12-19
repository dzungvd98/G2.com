using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public string? ProductLogo { get; set; }
        public string? Description { get; set; }
        public string? ProductLink { get; set; }

        public string? CoverImage { get; set; }

        public int TypeId;
    }
}
