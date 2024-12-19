﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Discussion
    {
        public int DiscussionId {  get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public required string Topic { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}