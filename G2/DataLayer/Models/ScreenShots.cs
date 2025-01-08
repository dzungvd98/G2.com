using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Screenshots")]
    public class ScreenShots
    {
        public int ScreenShotsId { get; set; }
        public int ProductId    { get; set; }
        public required string Title { get; set; } 
        public required string Link { get; set; }
        public int IsImage { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }
        public Product Product { get; set; }
    }
}
