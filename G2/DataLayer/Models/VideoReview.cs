using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class VideoReview
    {
        public int VideoReviewId { get; set; }
        public int UserId { get; set; }
        public int ReviewId { get; set; }
        public required string VideoRef { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
