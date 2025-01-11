using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

        public string VideoRef {  get; set; }

        public List<string> ProsConsName { get; set; }

        public int TotalLike { get; set; }
        public List<CriteriaRatingDTO> CriteriaRatings { get; set; }

    }
}
