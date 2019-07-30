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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        [HttpPost]
        public IActionResult Create(CreateApartmentViewModel model)
        {
            if (ModelState.IsValid)
            {

            if (apartmentServise.Create(model.Number))
            {
                return Redirect("/Administration/Apartments/All");
            }
            }
            return View(model);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult All()
        {
            return View(apartmentServise.GetAllApartments());
        }
        
    }
}
