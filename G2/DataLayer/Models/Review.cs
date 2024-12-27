using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Review")]
    public class Review
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public required string Content { get; set; }
        public int Rate { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public ICollection<ReviewProsCons> Reviews { get; set; } = new List<ReviewProsCons>();
    }
}
