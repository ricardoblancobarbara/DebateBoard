using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebateBoard.Data
{
    public class Debater
    {
        [Key]
        public int DebaterId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        //public int Points { get; set; }
        //public string Bio { get; set; }
        //public int MyProperty { get; set; }

    }
}
