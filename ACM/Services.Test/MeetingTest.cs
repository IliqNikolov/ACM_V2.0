using Data;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Utilities;
using Xunit;

namespace Services.Test
{
    public class MeetingTest
    {
        [Fact]
        public void TestCreateMeeting()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            List<VoteViewModel> votes;
            votes = CreateVotes();
            string output = meetingsService.CreateMeeting("Beer", votes);
            Assert.Single(context.Meetings.ToList());
            Assert.True(context.Meetings.Any(x => x.Id == output));
            Meeting meeting = context.Meetings.Where(x => x.Id == output).FirstOrDefault();
            Assert.Equal("Beer", meeting.Text);
            Assert.Equal(3, meeting.Votes.Count());
            Assert.Equal("text1", meeting.Votes.ToList()[0].Text);
            Assert.Equal(1, meeting.Votes.ToList()[0].Yes);
            Assert.Equal(1, meeting.Votes.ToList()[0].No);
            Assert.Equal("text2", meeting.Votes.ToList()[1].Text);
            Assert.Equal(2, meeting.Votes.ToList()[1].Yes);
            Assert.Equal(2, meeting.Votes.ToList()[1].No);
            Assert.Equal("text3", meeting.Votes.ToList()[2].Text);
            Assert.Equal(3, meeting.Votes.ToList()[2].Yes);
            Assert.Equal(3, meeting.Votes.ToList()[2].No);
        }
        [Fact]
        public void TestDeleteMeetingGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            string id=CreateAMeeting(context);
            string id2=CreateAMeeting(context);
            bool output = meetingsService.DeleteMeeting(id);
            Assert.True(output);
            Assert.Single(context.Meetings.ToList());
            Assert.Equal(3, context.Votes.ToList().Count);
            Assert.True(context.Meetings.Any(x => x.Id == id2));
        }
        [Fact]
        public void TestDeleteMeetingInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            string id = CreateAMeeting(context);
            Action act = () => meetingsService.DeleteMeeting(id+"Random string");
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestEditMeetingGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            string id = CreateAMeeting(context);
            bool output = meetingsService.EditMeeting(id, "new text", new List<VoteViewModel>());
            Assert.True(output);
            Assert.Equal("new text", context.Meetings.Where(x => x.Id == id).FirstOrDefault().Text);
            Assert.Empty(context.Votes.ToList());
        }
        [Fact]
        public void TestEditMeetingInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            string id = CreateAMeeting(context);
            Action act = () => 
            meetingsService.EditMeeting(id+"Random string", "new text", new List<VoteViewModel>());
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestGetAllMeetingsGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            string id1 = CreateAMeeting(context);
            string id2 = CreateAMeeting(context);
            List<MeetingsListViewModel> output = meetingsService.GetAllMeetings();
            Assert.Equal(2, output.Count);
            Assert.Equal(3, output[0].NumberOfVotes);
            Assert.Equal("beer", output[0].Text);
            Assert.Equal(id2, output[0].Id);
            Assert.Equal(3, output[1].NumberOfVotes);
            Assert.Equal("beer", output[1].Text);
            Assert.Equal(id1, output[1].Id);
        }
        [Fact]
        public void TestGetAllMeetingsEmptyTable()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            List<MeetingsListViewModel> output = meetingsService.GetAllMeetings();
            Assert.Empty(output);           
        }
        [Fact]
        public void TestGetOneMeetingGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            string id = CreateAMeeting(context);
            MeetingDetailsViewModel output = meetingsService.GetOneMeeting(id);
            Assert.Equal(id, output.Id);
            Assert.Equal("beer", output.Text);
            Assert.Equal("text1", output.Votes[0].Text);
            Assert.Equal(1, output.Votes[0].Yes);
            Assert.Equal(1, output.Votes[0].No);
            Assert.Equal("text2", output.Votes[1].Text);
            Assert.Equal(2, output.Votes[1].Yes);
            Assert.Equal(2, output.Votes[1].No);
            Assert.Equal("text3", output.Votes[2].Text);
            Assert.Equal(3, output.Votes[2].Yes);
            Assert.Equal(3, output.Votes[2].No);
        }
        [Fact]
        public void TestGetOneMeetingInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            string id = CreateAMeeting(context);
            Action act = () => meetingsService.GetOneMeeting(id+"Random string");
            Assert.Throws<ACMException>(act);
        }
        private static string CreateAMeeting(ACMDbContext context)
        {
            List<VoteViewModel> tempVotes = CreateVotes();
            Meeting meeting = new Meeting { Text = "beer" };
            for (int i = 0; i < tempVotes.Count; i++)
            {
                Vote temp = new Vote
                {
                    Text = tempVotes[i].Text,
                    Yes = tempVotes[i].Yes,
                    No = tempVotes[i].No,
                    Meeting = meeting
                };
                context.Votes.Add(temp);
            }
            context.Meetings.Add(meeting);
            context.SaveChanges();
            return meeting.Id;
        }

        private static List<VoteViewModel> CreateVotes()
        {
            List<VoteViewModel> votes;
            VoteViewModel vote1 = new VoteViewModel
            {
                Text = "text1",
                Yes = 1,
                No = 1
            };
            VoteViewModel vote2 = new VoteViewModel
            {
                Text = "text2",
                Yes = 2,
                No = 2
            };
            VoteViewModel vote3 = new VoteViewModel
            {
                Text = "text3",
                Yes = 3,
                No = 3
            };
            votes = new List<VoteViewModel>();
            votes.Add(vote1);
            votes.Add(vote2);
            votes.Add(vote3);
            return votes;
        }
    }
}