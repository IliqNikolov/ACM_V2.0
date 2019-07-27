using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Data;
using ACM.Models;

namespace ACM.Services
{
    public class MeetingsService : IMeetingsService
    {
        private readonly ACMDbContext context;

        public MeetingsService(ACMDbContext context)
        {
            this.context = context;
        }

        public void CreateMeeting(string text, List<VoteViewModel> votes)
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
        }

        public bool DeleteMeeting(string id)
        {
            Meeting meeting = context.Meetings
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (meeting==null)
            {
                return false;
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

        public bool EditMeeting(string id, string text, List<VoteViewModel> votes)
        {
            Meeting meeting = context.Meetings
               .Where(x => x.Id == id)
               .FirstOrDefault();
            if (meeting == null)
            {
                return false;
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

        public List<MeetingsListViewModel> GetAllMeetings()
        {
            return context.Meetings.Select(x => new MeetingsListViewModel
            {
                Id = x.Id,
                Text = x.Text,
                NumberOfVotes = x.Votes.Count(),
                Date = x.Date
            })
                .OrderByDescending(x=>x.Date)
                .ToList();
        }

        public MeetingDetailsViewModel GetOneMeeting(string id)
        {
            Meeting meeting = context.Meetings
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return new MeetingDetailsViewModel
            {
                Id = meeting.Id,
                Text = meeting.Text,
                Votes = context.Votes.Where(y=>y.Meeting==meeting).Select(y => new VoteViewModel
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
