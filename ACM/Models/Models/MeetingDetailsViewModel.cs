using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class MeetingDetailsViewModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public List<VoteViewModel> Votes { get; set; }
    }
}
