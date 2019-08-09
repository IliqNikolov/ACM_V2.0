using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Services;
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
        public async Task<IActionResult> Create(CreateApartmentDTO model)
        {
            if (ModelState.IsValid)
            {

            if (await apartmentServise.Create(model.Number)!=null)
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
