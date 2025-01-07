using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("ReviewVideo")]
    public class ReviewVideo
    {
        public int ReviewVideoID { get; set; }
        public int UserId { get; set; }
        public int ReviewId { get; set; }
        public required string VideoRef { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Review> Reviews { get; set; }

    }
}
