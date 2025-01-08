using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ProsCons
    {
        public int ProsConsId { get; set; }
        public required string ProsConsName { get; set; }
        public int IsPros {  get; set; }

        public ICollection<ReviewProsCons> ReviewsProsCons { get; set; } = new List<ReviewProsCons>();
    }
}
