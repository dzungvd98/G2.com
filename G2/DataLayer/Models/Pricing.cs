using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Pricing")]
    public class Pricing
    {
        public int PricingId { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price {  get; set; }
        public string? Description { get; set; }
        public int PackageId { get; set; }
        public string? PriceType { get; set; }
        public int IsFreeTrial { get; set; }
        public string? ContactLink { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Package Package { get; set; }
    }
}
