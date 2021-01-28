using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Models.Bio
{
    public class BioDetail
    {
        public int BioId { get; set; }

        public string Name { get; set; }

        public string Biography { get; set; }

        public string Id { get; set; }

        public int Points { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
