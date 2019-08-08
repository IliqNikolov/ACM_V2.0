using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACM.Controllers
{
    public class HomeownersController : Controller
    {
        private readonly IHomeownerService homeownerSevice;

        public HomeownersController(IHomeownerService homeownerSevice)
        {
            this.homeownerSevice = homeownerSevice;
        }

        [Authorize]
        public async Task<IActionResult> Ideas()
        {
            return View(homeownerSevice.All());
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateIdeaDTO model)
        {
            if (ModelState.IsValid)
            {
                await homeownerSevice.Create(model.Text, User.Identity.Name);
                return Redirect("/Homeowners/Ideas");
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            EditIdeaDTO model = homeownerSevice.GetIdea(id, User.Identity.Name);
            if (model == null)
            {
                return Redirect("/Homeowners/Ideas");
            }
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditIdeaDTO model)
        {
            if (ModelState.IsValid)
            {

            if(await homeownerSevice.EditIdea(model.Id, User.Identity.Name, model.Text))
            {
                return Redirect("/Homeowners/Ideas");
            }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            if (User.IsInRole(MagicStrings.AdminString))
            {
                await homeownerSevice.AdminDeleteIdea(id);
                return Redirect("/Homeowners/Ideas");
            }
            else if(await homeownerSevice.DeleteIdea(id, User.Identity.Name))
            {
                return View();
            }
            return Redirect("/Homeowners/Ideas");
        }
        
    }
}
