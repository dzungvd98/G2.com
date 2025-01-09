using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
    public class VideoReviewDTO
    {
        public string Content { get; set; }
        public string VideoRef { get; set; }
        public int Rate { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; } 
    }
}
