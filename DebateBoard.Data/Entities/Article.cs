using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Data
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        public string Category { get; set; }

        public string Subject { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string SubTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        //[ForeignKey(nameof(ApplicationUser))]
        public Guid AuthorId { get; set; }
        //public string AuthorId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int Points { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
