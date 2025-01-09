using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
    public class AddReviewDTO
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public List<int> ProsConsIDs { get; set; } = new List<int>();
        public List<string> VideoRefs { get; set; } = new List<string>();
    }
}
