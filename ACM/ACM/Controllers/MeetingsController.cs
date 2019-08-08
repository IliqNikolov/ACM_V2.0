using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ACM.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly IMeetingsService meetingsService;

        public MeetingsController(IMeetingsService meetingsService)
        {
            this.meetingsService = meetingsService;
        }
        [Authorize]
        public async Task<IActionResult> All()
        {
            return View(meetingsService.GetAllMeetings());
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        [HttpPost]
        public async Task<IActionResult> Create(CreateMeetingDTO model)
        {
            if (ModelState.IsValid)
            {
                List<VoteDTO> ListOfVotes;
                try
                {
                    ListOfVotes = (List<VoteDTO>)JsonConvert.DeserializeObject(model.Json, typeof(List<VoteDTO>));
                }
                catch (Exception)
                {
                    return View(model);
                }

                if (model.Text != null && !ListOfVotes.Any(x=>x.Yes<0 || x.No<0 || x.Text==""))
                {
                    await meetingsService.CreateMeeting(model.Text, ListOfVotes);
                    return Redirect("/Meetings/All");
                }
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Details(string id)
        {
            MeetingDetailsDTO meeting = meetingsService.GetOneMeeting(id);
            if (meeting==null)
            {
                return Redirect("/Meetings/All");
            }
            return View(meeting);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public async Task<IActionResult> Delete(string id)
        {
            if (await meetingsService.DeleteMeeting(id))
            {
                return View();
            }
            return Redirect("/Meetings/All");
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public async Task<IActionResult> Edit(string id)
        {
            MeetingDetailsDTO meeting = meetingsService.GetOneMeeting(id);
            MeetingEditDTO model = new MeetingEditDTO
            {
                Id = meeting.Id,
                Text=meeting.Text,
                Json=JsonConvert.SerializeObject(meeting.Votes)
            };
            return View(model);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        [HttpPost]
        public async Task<IActionResult> Edit(MeetingEditDTO model)
        {
            List<VoteDTO> ListOfVotes;
            try
            {
                ListOfVotes = (List<VoteDTO>)JsonConvert.DeserializeObject(model.Json, typeof(List<VoteDTO>));
            }
            catch (Exception)
            {

                return View(model);
            }

            if (model.Text != null && !ListOfVotes.Any(x => x.Yes < 0 || x.No < 0 || x.Text == ""))
            {
                await meetingsService.EditMeeting(model.Id, model.Text, ListOfVotes);
                return Redirect("/Meetings/All");
            }

            return View(model);
        }
    }
}
