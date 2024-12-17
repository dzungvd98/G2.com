using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ProsCons
    {
        public int ProsConsId { get; set; }
        public required string ProsConsName { get; set; }
        public bool IsPros;
    }
}
