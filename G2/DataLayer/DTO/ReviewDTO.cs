using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
    public class ReviewDTO
    {
        public string Content {  get; set; }
        public int Rate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; }
        public string CompanySizeName { get; set; }
    }
}
