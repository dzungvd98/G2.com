using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ReviewFeature
    {
        public int ReviewFeatureId { get; set; }
        public int ReviewID { get; set; }
        public int FeatureID { get; set; }
        public int Rate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
