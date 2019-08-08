using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace ACM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBillService billService;
        private readonly IUserService userService;
        private readonly UserManager<ACMUser> userManager;
        private readonly IEmailSender emailSender;

        public HomeController(IBillService billService,IUserService userService
            , UserManager<ACMUser> userManager,IEmailSender emailSender)
        {
            this.billService = billService;
            this.userService = userService;
            this.userManager = userManager;
            this.emailSender = emailSender;
        }
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(billService.GetWallOfShameList());
            }
            return Redirect("/Identity/Account/Login");
        }
        public async Task<IActionResult> RessetPassword()
        {           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RessetPassword (ResetpasswordDTO model)
        {
            if (ModelState.IsValid)
            {
                if (userService.IsUserValid(model.Email))
                {
                    ACMUser user = userService.GetOneUser(model.Email);
                    string newPassword = string.Join("", Guid.NewGuid().ToString().Take(8)).ToUpper();
                    emailSender.Send(model.Email, "Password Resset", $"Your new Password is {newPassword}");
                    string token = await userManager.GeneratePasswordResetTokenAsync(user);
                    await userManager.ResetPasswordAsync(user,token, newPassword);
                    return Redirect("/Home/RessetedPassword");
                }
            }
            model.IsValid = false;
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async  Task<IActionResult> ChangePassword(ChangePasswordDTO model)
        {
            if (ModelState.IsValid)
            {
                if (model.ConfirmedPassword==model.NewPassword)
                {
                    ACMUser user = userService.GetOneUser(User.Identity.Name);
                    IdentityResult result = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return Redirect("/");
                    }
                    model.IsPasswordInvalid = true;
                }
            }
            return View(model);
        }
        public async Task<IActionResult> RessetedPassword()
        {
            return View();
        }
        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> JokeError()
        {
            StringBuilder errorCode=new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                errorCode.Append(System.Guid.NewGuid().ToString());
            }
            return View(new ErrorDTO { ErrorCode=errorCode.ToString()});
        }
    }
}
