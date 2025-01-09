using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Review")]
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public required string Content { get; set; }
        public int Rate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<ReviewProsCons> ReviewProsCons { get; set; } = new List<ReviewProsCons>();
        public ICollection<ReviewVideo> ReviewVideos { get; set; } = new List<ReviewVideo>();


        //public ICollection<User> Users { get; set; } = new List<User>();
    }
}
