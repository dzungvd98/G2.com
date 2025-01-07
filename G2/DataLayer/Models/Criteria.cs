using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Criteria")]
    public class Criteria
    {
        public int CriteriaId { get; set; }
        public required string CriteriaName { get; set; }
    }
}
