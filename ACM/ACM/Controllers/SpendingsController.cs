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
    public class SpendingsController : Controller
    {
        private readonly ISpendingService spendingService;

        public SpendingsController(ISpendingService spendingService)
        {
            this.spendingService = spendingService;
        }
        [Authorize]
        public IActionResult All()
        {
            return View(spendingService.GetAllSpendings());
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        [HttpPost]
        public IActionResult Create(SpendingViewModel model)
        {
            if (ModelState.IsValid)
            {
                spendingService.CreateSpending(model);
                return Redirect("/Spendings/All");
            }
            return View(model);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult Edit(string id)
        {
            SpendingViewModel model = spendingService.GetOneSpending(id);
            if (model==null)
            {
                return Redirect("/Spendings/All");
            }
            return View(model);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        [HttpPost]
        public IActionResult Edit(SpendingViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (spendingService.EditSpending(model))
                {
                    return Redirect("/Spendings/All");
                }
            }
            return View(model);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult Delete(string id)
        {
            if (spendingService.DeleteSpending(id))
            {
                return View();
            }
            return Redirect("/Spendings/All");
        }
    }
}
