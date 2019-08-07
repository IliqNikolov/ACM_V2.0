using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IMeetingsService
    {
        List<MeetingsListDTO> GetAllMeetings();
        string CreateMeeting(string text, List<VoteDTO> votes);
        MeetingDetailsDTO GetOneMeeting(string id);
        bool DeleteMeeting(string id);
        bool EditMeeting(string id, string text, List<VoteDTO> votes);
    }
}
