using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("ReviewProsCons")]
    public class ReviewProsCons
    {
        public int ReviewProsConsId { get; set; }
        [Column("ReviewID")]
        public int ReviewId { get; set; }
        public int ProsConsId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //public ICollection<Review> Reviews { get; set; }

        public ICollection<ProsCons> ProsCons { get; set; } = new List<ProsCons>();
    }
}
