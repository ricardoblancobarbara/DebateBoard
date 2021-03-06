﻿using DebateBoard.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Models
{
    public class ArticleCreate
    {
        //public int ArticleId { get; set; }

        public string Category { get; set; }

        public string Subject { get; set; }

        [Required]
        //[MinLength(5, ErrorMessage = "Please enter no less than 5 characters.")]
        //[MaxLength(50, ErrorMessage = "Please enter no more than 30 characters.")]
        public string Title { get; set; }

        [Required]
        //[MinLength(5, ErrorMessage = "Please enter no less than 5 characters.")]
        //[MaxLength(50, ErrorMessage = "Please enter no more than 30 characters.")]
        public string SubTitle { get; set; }

        //[MinLength(20, ErrorMessage = "Please enter no less than 20 characters.")]
        //[MaxLength(300, ErrorMessage = "Please enter no more than 300 characters.")]
        public string Content { get; set; }

        public Guid AuthorId { get; set; }
        //public string AuthorId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int Points { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
