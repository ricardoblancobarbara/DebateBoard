using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Models
{
    public class ArticleDetail
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Display(Name = "Published")]
        public DateTimeOffset CreatedUtc { get; set; }


    }
}
