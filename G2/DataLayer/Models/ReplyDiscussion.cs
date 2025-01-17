﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    [Table("ReplyDiscussion")]
    public class ReplyDiscussion
    {
        public int ReplyDiscussionId { get; set; }
        public int DiscussionId { get; set; }
        public int UserId { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        }
    }
