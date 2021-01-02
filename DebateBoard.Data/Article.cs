﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Data
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        //public string Category { get; set; }

        //public string Subject { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        //public string Author { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }

    }
}