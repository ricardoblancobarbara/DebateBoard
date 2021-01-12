using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Models
{
    public class ArticleList
    {
        public int ArticleId { get; set; }

        public string Title { get; set; }

        public string SubTitle { get; set; }

        public Guid AuthorId { get; set; }

        public int Points { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

    }
}
