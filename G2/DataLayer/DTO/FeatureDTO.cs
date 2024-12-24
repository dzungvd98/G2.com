using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
    public class FeatureDTO
    {
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
        public string? ParentFeatureName { get; set; }
    }
}
