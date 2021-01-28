using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Models.Bio
{
    public class BioEdit
    {
        public int BioId { get; set; }

        public string Name { get; set; }

        public string Biography { get; set; }

        public int Points { get; set; }
        
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
