using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Models;
using ACM.Services;
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
        public IActionResult Ideas()
        {
            return View(homeownerSevice.All());
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateIdeaViewModel model)
        {
            if (ModelState.IsValid)
            {
                homeownerSevice.Create(model.Text, User.Identity.Name);
                return Redirect("/Homeowners/Ideas");
            }
            return View();
        }

        [Authorize]
        public IActionResult Edit(string id)
        {
            EditIdeaViewModel model = homeownerSevice.GetIdea(id, User.Identity.Name);
            if (model == null)
            {
                return Redirect("/Homeowners/Ideas");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditIdeaViewModel model)
        {
            if(homeownerSevice.EditIdea(model.Id,User.Identity.Name,model.Text))
            {
                return Redirect("/Homeowners/Ideas");
            }
            return View(model);
        }

        public IActionResult Delete(string id)
        {
            if(homeownerSevice.DeleteIdea(id, User.Identity.Name))
            {
                return View();
            }
            return Redirect("/Homeowners/Ideas");
        }
        
    }
}
