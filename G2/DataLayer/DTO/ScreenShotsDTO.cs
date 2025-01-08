using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTO
{
   
    public class ScreenShotsDTO
    {
        public string Title { get; set; }
        public int IsImage { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }

    }
}
