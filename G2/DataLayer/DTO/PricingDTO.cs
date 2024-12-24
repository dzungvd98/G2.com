using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
    public class PricingDTO
    {
        public int PricingId { get; set; }
        public string Description { get; set; }
        public string ContactLink { get; set; }
        public bool IsFreeTrial { get; set; }
        public string PricingType { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public Decimal Price { get; set; }
        public string PackageName { get; set; }
    }
}
