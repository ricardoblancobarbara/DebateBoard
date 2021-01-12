using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Data
{
    public class Article
    {
        // De aca va a tomar la info ArticleCreate
        [Key]
        public int ArticleId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        // This should be a picklist
        //public Enum Category { get; set; }
        public String Category { get; set; }

        // This should be a picklist ?
        public string Subject { get; set; }

        [Required]
        public string Title { get; set; }

        // This should be the first paragraph
        [Required]
        public string SubTitle { get; set; }

        [Required]
        public string Content { get; set; }

        public int Points { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
