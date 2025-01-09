using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("ReviewDetail")]
    public class ReviewDetail
    {
        public int ReviewDetailId { get; set; }
        [Column("ReviewID")]
        public int ReviewId { get; set; }
        public int CriteriaId { get; set; }
        public int Rate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
