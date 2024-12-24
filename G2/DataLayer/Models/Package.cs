using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("Package")]
    public class Package
    {
        public int PackageId { get; set; }
        public required string PackageName { get; set; }

        public ICollection<Pricing> Pricings { get; set; } = new List<Pricing>();
    }
}
