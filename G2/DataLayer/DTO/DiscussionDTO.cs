using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
    public class DiscussionDTO
    {
        public int DiscussionId { get; set; }
        public string Topic { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Avatar {  get; set; }
        public string Username { get; set; }
        public int CountReply { get; set; }
    }
}
