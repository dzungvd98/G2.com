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
        public int ReviewDetailID { get; set; }
        [Column("ReviewID")]
        public int ReviewID { get; set; }
        public int CriteriaID { get; set; }
        public int Rate { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
