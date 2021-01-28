using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Models.Bio
{
    public class BioCreate
    {
        public readonly object ApplicationUser;

        public int BioId { get; set; }

        public string Name { get; set; }

        public string Biography { get; set; }

        public string Id { get; set; }

        public int Points { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
