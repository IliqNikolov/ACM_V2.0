using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Areas.Administration.Models;
using ACM.Models;
using ACM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACM.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class CodeController : Controller
    {
        private readonly ICodeService codeService;
        private readonly IApartmentServise apartmentServise;

        public CodeController(ICodeService codeService,IApartmentServise apartmentServise)
        {
            this.codeService = codeService;
            this.apartmentServise = apartmentServise;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult CreateARegistrationNumber(string id)
        {
            CodeViewModel code = codeService.CreateARegistrationCode(id);
            if (code == null)
            {
                return Redirect("/Administration/Code/All");
            }
            return View(code);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult AllCodes()
        {
            return View(codeService.GetAllCodes());
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult DeleteCode(string id)
        {
            if (codeService.DeleteCode(id))
            {
                return View();
            }
            return Redirect("/Administration/Code/AllCodes");
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult CreateCode()
        {
            List<ApartmentListElementViewModel> list = new List<ApartmentListElementViewModel>();
            list.AddRange(apartmentServise.GetAppartments().OrderBy(x => x.Number));
            ViewBag.apartmantList = list;
            return View();
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        [HttpPost]
        public IActionResult CreateCode(CreateCodeViewModel code)
        {
            return Redirect($"/Administration/Code/CreateARegistrationNumber/{code.ApartmentNumber}");
        }
    }
}
