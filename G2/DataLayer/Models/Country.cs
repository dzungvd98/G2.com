using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public required string CountryName { get; set; }
        public int ContinentId { get; set; }

    }
}
