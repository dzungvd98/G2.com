﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentFeatureId { get; set; }
    }
}