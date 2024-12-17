using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class CategoryFeature
    {
        public int CategoryFeatureId { get; set; }
        public int CategoryId { get; set; } 
        public int FeatureId { get; set; }
    }
}
