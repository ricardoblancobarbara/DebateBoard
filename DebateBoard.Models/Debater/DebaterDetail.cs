using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Models.Debater
{
    public class DebaterDetail
    {
        public int DebaterId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

    }
}
