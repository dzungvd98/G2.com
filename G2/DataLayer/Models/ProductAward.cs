﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class ProductAward
    {
        public int ProductAwardId { get; set; }
        public int ProductId { get; set; }
        public int AwardId { get; set; }
    }
}
