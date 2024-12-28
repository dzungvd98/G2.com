using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Category")]
    public class Category
    {
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public int? ParentCategoryID { get; set; }
        public string? Description { get; set; }
        public string? Slug {  get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
