using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("ProductFeature")]
    public class ProductFeature
    {
        public int ProductFeatureId { get; set; }
        public int ProductId { get; set; }
        public int FeatureId { get; set; }

        public virtual Feature Feature { get; set; } = null!;
    }
}
