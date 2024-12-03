using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ReviewDetail
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public int RatingId { get; set; }
        public int point { get; set; }
    }
}
