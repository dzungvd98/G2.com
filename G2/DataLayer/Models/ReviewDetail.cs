using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ReviewDetail
    {
        public int ReviewDetailId { get; set; }
        public int ReviewId { get; set; }
        public int CriteriaId { get; set; }
        public int Rate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
