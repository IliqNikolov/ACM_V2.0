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
    public class BillsController : Controller
    {
        private readonly IBillService billService;
        private readonly IApartmentServise apartmentServise;
        private readonly IUserService userService;

        public BillsController(IBillService billService,IApartmentServise apartmentServise
            ,IUserService userService)
        {
            this.billService = billService;
            this.apartmentServise = apartmentServise;
            this.userService = userService;
        }
        [Authorize]
        public IActionResult All()
        {
            ViewBag.UserApartment = userService.GetApartmentNumber(User.Identity.Name);
            return View(billService.GetAllBills());
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult Create()
        {
            List<ApartmentListElementViewModel> list = new List<ApartmentListElementViewModel>();
            list.Add(new ApartmentListElementViewModel { Id = "all", Number = "all" });
            list.AddRange(apartmentServise.GetAppartments().OrderBy(x=>x.Number));
            ViewBag.apartmantList = list;
            return View();
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        [HttpPost]
        public IActionResult Create(CreateBillViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Apartment=="all")
                {
                    billService.BillAllApartments(model.Text,Decimal.Parse(model.Amount));
                    return Redirect("/Bills/All");
                }
                else
                {
                    billService.BillOneApartment(model.Apartment,model.Text, Decimal.Parse(model.Amount));
                    return Redirect("/Bills/All");
                }
            }
            List<ApartmentListElementViewModel> list = new List<ApartmentListElementViewModel>();
            list.Add(new ApartmentListElementViewModel { Id = "all", Number = "all" });
            list.AddRange(apartmentServise.GetAppartments().OrderBy(x => x.Number));
            ViewBag.apartmantList = list;
            return View(model);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult Edit(string id)
        {
            BillsViewModel bill = billService.GetOneBill(id);
            List<ApartmentListElementViewModel> list = apartmentServise.GetAppartments();
            ApartmentListElementViewModel first = list.Where(x => x.Number == bill.Apartment.ToString()).FirstOrDefault();
            list.Remove(first);
            list.OrderBy(x => x.Number);
            list.Insert(0, first);
            ViewBag.apartmantList = list;
            if (bill==null)
            {
                return Redirect("All");
            }
            return View(bill);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        [HttpPost]
        public IActionResult Edit(BillsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (billService.EditBill(model))
                {
                    return Redirect("/Bills/All");
                }
            }
            List<ApartmentListElementViewModel> list = new List<ApartmentListElementViewModel>();
            list.AddRange(apartmentServise.GetAppartments().OrderBy(x => x.Number));
            ViewBag.apartmantList = list;
            return View(model);
        }
        [Authorize(Roles = MagicStrings.AdminString)]
        public IActionResult Delete(string id)
        {
            billService.DeleteBill(id);

                return View();

        }
        [Authorize]
        public IActionResult Pay(string id)
        {
            BillsViewModel bill = billService.GetOneBill(id);
            if (bill==null)
            {
                return Redirect("/Bills/All");
            }
            CardViewModel model = new CardViewModel
            {
                BillId = bill.Id,
                Apartment = bill.Apartment,
                IssuedOn = bill.Date,
                BillAmount = bill.Amount,
                Text = bill.Text
            };
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Pay(CardViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (billService.PayBill(model.BillId))
                {
                    return Redirect("/Bills/All");
                }
            }
            return View(model);
        }
    }
}
