using Data;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Xunit;

namespace Services.Test
{
    public class MeetingTest
    {
        [Fact]
        public async Task TestCreateMeeting()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            List<VoteDTO> votes;
            votes = CreateVotes();
            string output = await meetingsService.CreateMeeting("Beer", votes);
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
        public async Task TestDeleteMeetingGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            string id = await CreateAMeeting(context);
            string id2 = await CreateAMeeting(context);
            bool output = await meetingsService.DeleteMeeting(id);
            Assert.True(output);
            Assert.Single(context.Meetings.ToList());
            Assert.Equal(3, context.Votes.ToList().Count);
            Assert.True(context.Meetings.Any(x => x.Id == id2));
        }

        [Fact]
        public async Task TestDeleteMeetingInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            string id = await CreateAMeeting(context);
            await Assert.ThrowsAsync<ACMException>(() 
                => meetingsService.DeleteMeeting(id + "Random string"));
        }

        [Fact]
        public async Task TestEditMeetingGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            string id = await CreateAMeeting(context);
            bool output = await meetingsService.EditMeeting(id, "new text", new List<VoteDTO>());
            Assert.True(output);
            Assert.Equal("new text", context.Meetings.Where(x => x.Id == id).FirstOrDefault().Text);
            Assert.Empty(context.Votes.ToList());
        }

        [Fact]
        public async Task TestEditMeetingInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            string id = await CreateAMeeting(context);
            await Assert.ThrowsAsync<ACMException>(() =>meetingsService
            .EditMeeting(id + "Random string", "new text", new List<VoteDTO>()));
        }

        [Fact]
        public async Task TestGetAllMeetingsGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            string id1 = await CreateAMeeting(context);
            string id2 = await CreateAMeeting(context);
            List<MeetingsListDTO> output = meetingsService.GetAllMeetings();
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
            List<MeetingsListDTO> output = meetingsService.GetAllMeetings();
            Assert.Empty(output);
        }

        [Fact]
        public async Task TestGetOneMeetingGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            string id = await CreateAMeeting(context);
            MeetingDetailsDTO output = meetingsService.GetOneMeeting(id);
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
        public async Task TestGetOneMeetingInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            MeetingsService meetingsService = new MeetingsService(context);
            string id = await CreateAMeeting(context);
            Action act = () => meetingsService.GetOneMeeting(id+"Random string");
            Assert.Throws<ACMException>(act);
        }

        private static async Task<string> CreateAMeeting(ACMDbContext context)
        {
            List<VoteDTO> tempVotes = CreateVotes();
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
                await context.Votes.AddAsync(temp);
            }
            await context.Meetings.AddAsync(meeting);
            await context.SaveChangesAsync();
            return meeting.Id;
        }

        private static List<VoteDTO> CreateVotes()
        {
            List<VoteDTO> votes;
            VoteDTO vote1 = new VoteDTO
            {
                Text = "text1",
                Yes = 1,
                No = 1
            };
            VoteDTO vote2 = new VoteDTO
            {
                Text = "text2",
                Yes = 2,
                No = 2
            };
            VoteDTO vote3 = new VoteDTO
            {
                Text = "text3",
                Yes = 3,
                No = 3
            };
            votes = new List<VoteDTO>();
            votes.Add(vote1);
            votes.Add(vote2);
            votes.Add(vote3);
            return votes;
        }
    }
}