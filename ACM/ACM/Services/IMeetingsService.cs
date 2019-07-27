using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Models;

namespace ACM.Services
{
    public interface IMeetingsService
    {
        List<MeetingsListViewModel> GetAllMeetings();
        void CreateMeeting(string text, List<VoteViewModel> votes);
        MeetingDetailsViewModel GetOneMeeting(string id);
        bool DeleteMeeting(string id);
        bool EditMeeting(string id, string text, List<VoteViewModel> votes);
    }
}
