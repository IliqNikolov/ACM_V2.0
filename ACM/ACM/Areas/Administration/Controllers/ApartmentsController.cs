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
    public class ApartmentsController : Controller
    {
        private readonly IApartmentServise apartmentServise;

        public ApartmentsController(IApartmentServise apartmentServise)
        {
            this.apartmentServise = apartmentServise;
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        [HttpPost]
        public IActionResult Create(CreateApartmentViewModel model)
        {
            if (apartmentServise.Create(model.Number))
            {
                return Redirect("/Administration/Apartments/All");
            }
            return View(model);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult All()
        {
            return View(apartmentServise.GetAllApartments());
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult CreateARegistrationNumber(string id)
        {
            CodeViewModel code = apartmentServise.CreateARegistrationCode(id);
            if (code==null)
            {
                return Redirect("/Administration/Apartments/All");
            }
            return View(code);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult AllCodes()
        {
            return View(apartmentServise.GetAllCodes());
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult DeleteCode(string id)
        {
            if (apartmentServise.DeleteCode(id))
            {
                return View();
            }
            return Redirect("/Administration/Apartments/AllCodes");
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
            return Redirect($"/administration/apartments/CreateARegistrationNumber/{code.ApartmentNumber}");
        }
    }
}
