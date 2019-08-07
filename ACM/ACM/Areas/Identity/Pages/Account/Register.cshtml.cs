using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ACM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Services;
using Data;

namespace ACM.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ACMUser> _signInManager;
        private readonly UserManager<ACMUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly ICodeService codeService;
        private readonly IIPService iPService;

        //private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ACMUser> userManager,
            SignInManager<ACMUser> signInManager,
            ILogger<RegisterModel> logger,
            ICodeService codeService,
            IIPService iPService
            //IEmailSender emailSender
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            this.codeService = codeService;
            this.iPService = iPService;
            // _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "FullName")]
            public string FullName { get; set; }
            
            [Required]
            [StringLength(15, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "PhoneNumber")]
            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "Code")]
            public string Code { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                if (Input.Email=="admin@admin.admin")
                {
                     var user = new ACMUser { UserName = Input.Email, Email = Input.Email, FullName = Input.FullName, PhoneNumber = Input.PhoneNumber, AppartentNumber = int.Parse(Input.Code.Split("_")[0]) };
                    var result = await _userManager.CreateAsync(user, Input.Password);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { userId = user.Id, code = code },
                            protocol: Request.Scheme);

                        //  await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        //     $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                        await _userManager.AddToRoleAsync(user, MagicStrings.AdminString);
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        string ip = Request.Host.Value;
                        iPService.Create(new Models.IpDTO(user, ip));

                        return LocalRedirect(returnUrl);
                    }
                }
                else if (codeService.IsCodeValid(Input.Code))
                {
                    var user = new ACMUser { UserName = Input.Email, Email = Input.Email, FullName = Input.FullName, PhoneNumber = Input.PhoneNumber, AppartentNumber = int.Parse(Input.Code.Split("_")[0]) };
                    var result = await _userManager.CreateAsync(user, Input.Password);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { userId = user.Id, code = code },
                            protocol: Request.Scheme);

                        //  await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        //     $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        string ip = Request.Host.Value;
                        iPService.Create(new Models.IpDTO(user, ip));
                        codeService.DeleteCode(Input.Code);
                        return LocalRedirect(returnUrl);
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
