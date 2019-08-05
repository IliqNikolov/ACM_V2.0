using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class MeetingsListViewModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public int NumberOfVotes { get; set; }
        public DateTime Date { get; set; }
    }
}
