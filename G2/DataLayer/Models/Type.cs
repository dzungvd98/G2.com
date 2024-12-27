using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Type")]
    public class Type
    {
        public int TypeId { get; set; }
        public string? TypeName { get; set; }
    }
}
