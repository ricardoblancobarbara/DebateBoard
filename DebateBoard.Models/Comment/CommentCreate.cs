﻿using DebateBoard.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Models
{
    public class CommentCreate
    {        
        public int CommentId { get; set; }

        public string Content { get; set; }

        [Display(Name = "Author")]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Article")]
        public int ArticleId { get; set; }

        public int Points { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
