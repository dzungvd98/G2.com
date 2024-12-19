﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Pricing
    {
        public int PriceId { get; set; }
        public int ProductId { get; set; }
        public decimal Price {  get; set; }
        public string? Description { get; set; }
        public int PackageId { get; set; }
        public bool IsFreeTrial { get; set; }
        public string? ContactLink { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}