using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Product")]
    public class Product
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public string? ProductLogo { get; set; }
        public string? Description { get; set; }
        public string? ProductLink { get; set; }
        public string? CoverImage { get; set; }
        public int TypeId { get; set; }
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();  
        public ICollection<Discussion> Discussions { get; set; } = new List<Discussion>();
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<ScreenShots> ScreenShots { get; set; }
        public Type Type { get; set; }
    }
}
