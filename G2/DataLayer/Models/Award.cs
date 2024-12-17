using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Award
    {
        public int AwardId { get; set; }
        public required string AwardName { get; set; }
        public string? AwardImg {  get; set; }
        public int AwardYear { get; set; }
    }
}
