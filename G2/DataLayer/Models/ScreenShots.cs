using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ScreenShots
    {
        public int ScreenShotId { get; set; }
        public int ProductId    { get; set; }
        public required string Title { get; set; } 
        public required string Link { get; set; }
        public bool IsImage { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
    }
}
