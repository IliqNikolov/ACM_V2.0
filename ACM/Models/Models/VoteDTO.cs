using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class VoteDTO
    {
        public string Text { get; set; }
        public int Yes { get; set; }
        public int No { get; set; }
    }
}
