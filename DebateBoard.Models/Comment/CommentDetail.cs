using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Models
{
    public class CommentDetail
    {
        public int CommentId { get; set; }

        public string Content { get; set; }

        [Display(Name = "Author")]
        public string Id { get; set; }

        [Display(Name = "Article")]
        public int ArticleId { get; set; }

        public int Points { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
