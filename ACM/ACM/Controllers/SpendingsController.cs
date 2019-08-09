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
        public async Task<IActionResult> Create(SpendingDTO model)
        {
            if (ModelState.IsValid)
            {
                await spendingService.CreateSpending(model);
                return Redirect("/Spendings/All");
            }
            return View(model);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult Edit(string id)
        {
            SpendingDTO model = spendingService.GetOneSpending(id);
            if (model == null)
            {
                return Redirect("/Spendings/All");
            }
            return View(model);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        [HttpPost]
        public async Task<IActionResult> Edit(SpendingDTO model)
        {
            if (ModelState.IsValid)
            {
                if (await spendingService.EditSpending(model))
                {
                    return Redirect("/Spendings/All");
                }
            }
            return View(model);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public async Task<IActionResult> Delete(string id)
        {
            if (await spendingService.DeleteSpending(id))
            {
                return View();
            }
            return Redirect("/Spendings/All");
        }
    }
}
