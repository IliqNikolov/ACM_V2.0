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
        Task<string> CreateMeeting(string text, List<VoteDTO> votes);
        MeetingDetailsDTO GetOneMeeting(string id);
        Task<bool> DeleteMeeting(string id);
        Task<bool> EditMeeting(string id, string text, List<VoteDTO> votes);
    }
}
