using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Award")]
    public class Award
    {
        public int AwardId { get; set; }
        public required string AwardName { get; set; }
        public string? AwardImg {  get; set; }
        public int AwardYear { get; set; }
    }
}
