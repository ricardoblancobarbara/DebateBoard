using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Models
{
    public class CommentEdit
    {
        public int CommentId { get; set; }

        public string Content { get; set; }

        [Display(Name = "Author")]
        public string Id { get; set; }

        public int ArticleId { get; set; }

        public int Points { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
