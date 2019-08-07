using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Models;

namespace Services
{
    public class MeetingsService : IMeetingsService
    {
        private readonly ACMDbContext context;

        public MeetingsService(ACMDbContext context)
        {
            this.context = context;
        }

        public string CreateMeeting(string text, List<VoteDTO> votes)
        {
            Meeting meeting = new Meeting();
            meeting.Text = text;
            Vote vote;
            for (int i = 0; i < votes.Count; i++)
            {
                vote = new Vote
                {
                    Text = votes[i].Text,
                    Yes = votes[i].Yes,
                    No = votes[i].No,
                    Meeting = meeting
                };
                context.Votes.Add(vote);
            }
            context.Meetings.Add(meeting);
            context.SaveChanges();
            return meeting.Id;
        }

        public bool DeleteMeeting(string id)
        {
            Meeting meeting = context.Meetings
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (meeting==null)
            {
                throw new Utilities.ACMException();
            }
            List<Vote> votes = context.Votes
                .Where(x => x.Meeting == meeting)
                .ToList(); 
            for (int i = 0; i < votes.Count ; i++)
            {
                context.Votes.Remove(votes[i]);
            }
            context.Meetings.Remove(meeting);
            context.SaveChanges();
            return true;
        }

        public bool EditMeeting(string id, string text, List<VoteDTO> votes)
        {
            Meeting meeting = context.Meetings
               .Where(x => x.Id == id)
               .FirstOrDefault();
            if (meeting == null)
            {
                throw new Utilities.ACMException();
            }
            List<Vote> oldVotes = context.Votes
                .Where(x => x.Meeting == meeting)
                .ToList();
            for (int i = 0; i < oldVotes.Count; i++)
            {
                context.Votes.Remove(oldVotes[i]);
            }
            meeting.Text = text;
            Vote vote;
            for (int i = 0; i < votes.Count; i++)
            {
                vote = new Vote
                {
                    Text = votes[i].Text,
                    Yes = votes[i].Yes,
                    No = votes[i].No,
                    Meeting = meeting
                };
                context.Votes.Add(vote);
            };
            context.SaveChanges();
            return true;
        }

        public List<MeetingsListDTO> GetAllMeetings()
        {
            return context.Meetings.Select(x => new MeetingsListDTO
            {
                Id = x.Id,
                Text = x.Text,
                NumberOfVotes = x.Votes.Count(),
                Date = x.Date
            })
                .OrderByDescending(x=>x.Date)
                .ToList();
        }

        public MeetingDetailsDTO GetOneMeeting(string id)
        {
            Meeting meeting = context.Meetings
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (meeting==null)
            {
                throw new Utilities.ACMException();
            }
            return new MeetingDetailsDTO
            {
                Id = meeting.Id,
                Text = meeting.Text,
                Votes = context.Votes.Where(y=>y.Meeting==meeting).Select(y => new VoteDTO
                {
                    Text = y.Text,
                    Yes = y.Yes,
                    No = y.No
                })
                .ToList()
            };
        }

    }
}
