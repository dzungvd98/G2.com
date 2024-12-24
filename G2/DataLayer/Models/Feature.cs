using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Feature")]
    public class Feature
    {
        public int FeatureId { get; set; }
        public required string FeatureName { get; set; }
        public int? ParentFeatureId { get; set; }
        
        public virtual Feature? ParentFeature { get; set; }
        public virtual ICollection<ProductFeature> ProductFeatures { get; set; } = new List<ProductFeature>();  
    }
}
