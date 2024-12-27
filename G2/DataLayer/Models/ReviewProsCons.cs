using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ReviewProsCons
    {
        public int ReviewProsConsId { get; set; }
        public int ReviewId { get; set; }
        public int ProsConsId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public required ProsCons ProsCons { get; set; }
        public required Review review { get; set; }
    }
}
