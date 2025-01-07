using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
    public class CriteriaRatingDTO
    {
        public string CriteriaName { get; set; }
        public int RatingBreakdown { get; set; }
        public double OverallRating { get; set; }
        public double Ratings { get; set; }
    }
}
