using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Package
    {
        public int PackageId { get; set; }
        public required string PackageName { get; set; }
    }
}
