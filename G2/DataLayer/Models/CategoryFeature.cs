using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("CategoryFeature")]
    public class CategoryFeature
    {
        public int CategoryFeatureId { get; set; }
        public int CategoryId { get; set; } 
        public int FeatureId { get; set; }
    }
}
