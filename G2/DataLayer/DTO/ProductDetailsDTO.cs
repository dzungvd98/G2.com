using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
    public class ProductDetailsDTO
    {
        public required string ProductName { get; set; }
        public string? Description { get; set; }
        public string? ProductLogo { get; set; }
        public string? CoverImage { get; set; }
        public string? ProductLink { get; set; }
        public double AvgRate { get; set; }
        public int TotalReviews { get; set; }
        public int TotalDiscussion { get; set; }

        public IEnumerable<FeatureDTO> Features { get; set; } = null!;
        public IEnumerable<PricingDTO> Pricings { get; set; } = null!;
        public IEnumerable<ProsConsDTO> ProsCons { get; set; } = null!;
        public IEnumerable<ScreenShotsDTO> ScreenShots { get; set; } = null!;
    }
}
