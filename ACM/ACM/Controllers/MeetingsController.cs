using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Models;
using ACM.Services;
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
        public IActionResult All()
        {
            return View(meetingsService.GetAllMeetings());
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        [HttpPost]
        public IActionResult Create(CreateMeetingViewModel model)
        {
            List<VoteViewModel> ListOfVotes;
            try
            {
                ListOfVotes = (List<VoteViewModel>)JsonConvert.DeserializeObject(model.Json, typeof(List<VoteViewModel>));
            }
            catch (Exception)
            {

                return View(model);
            }

            if (model.Text != null && !ListOfVotes.Any(x=>x.Yes<0 || x.No<0 || x.Text==""))
            {
                meetingsService.CreateMeeting(model.Text, ListOfVotes);
                return Redirect("/Meetings/All");
            }

            return View(model);
        }
        [Authorize]
        public IActionResult Details(string id)
        {
            MeetingDetailsViewModel meeting = meetingsService.GetOneMeeting(id);
            if (meeting==null)
            {
                return Redirect("/Meetings/All");
            }
            return View(meeting);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult Delete(string id)
        {
            if (meetingsService.DeleteMeeting(id))
            {
                return View();
            }
            return Redirect("/Meetings/All");
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult Edit(string id)
        {
            MeetingDetailsViewModel meeting = meetingsService.GetOneMeeting(id);
            MeetingEditViewModel model = new MeetingEditViewModel
            {
                Id = meeting.Id,
                Text=meeting.Text,
                Json=JsonConvert.SerializeObject(meeting.Votes)
            };
            return View(model);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        [HttpPost]
        public IActionResult Edit(MeetingEditViewModel model)
        {
            List<VoteViewModel> ListOfVotes;
            try
            {
                ListOfVotes = (List<VoteViewModel>)JsonConvert.DeserializeObject(model.Json, typeof(List<VoteViewModel>));
            }
            catch (Exception)
            {

                return View(model);
            }

            if (model.Text != null && !ListOfVotes.Any(x => x.Yes < 0 || x.No < 0 || x.Text == ""))
            {
                meetingsService.EditMeeting(model.Id,model.Text, ListOfVotes);
                return Redirect("/Meetings/All");
            }

            return View(model);
        }
    }
}
