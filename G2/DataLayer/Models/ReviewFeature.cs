using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ReviewFeature
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int FeatureId { get; set; }
        public int Rate { get; set; }
    }
}
