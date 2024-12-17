using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Criteria
    {
        public int CriteriaId { get; set; }
        public required string CriteriaName { get; set; }
    }
}
