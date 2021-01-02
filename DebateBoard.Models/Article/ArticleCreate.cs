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
        [Required]
        //[MinLength(5, ErrorMessage = "Please enter no less than 5 characters.")]
        //[MaxLength(50, ErrorMessage = "Please enter no more than 30 characters.")]
        public string Title { get; set; }

        //[MinLength(20, ErrorMessage = "Please enter no less than 20 characters.")]
        //[MaxLength(300, ErrorMessage = "Please enter no more than 300 characters.")]
        public string Content { get; set; }

    }
}
