using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Data;
using ACM.Models;

namespace ACM.Services
{
    public class BillService : IBillService
    {
        private readonly ACMDbContext context;

        public BillService(ACMDbContext context)
        {
            this.context = context;
        }

        public void BillAllApartments(string text, decimal amount)
        {
            IQueryable apartments = context.Apartments;
            foreach (var apartment in apartments)
            {
                context.Bills.Add(new Bill { Apartment = (Apartment)apartment, Text = text, Amount = amount });
            }
            context.SaveChanges();
        }

        public bool BillOneApartment(string id, string text, decimal amount)
        {
            Apartment apartment = context.Apartments
                .Where(x => x.Number ==int.Parse(id))
                .FirstOrDefault();
            if (apartment==null)
            {
                return false;
            }
            context.Bills.Add(new Bill { Apartment = apartment, Text = text, Amount = amount });
            context.SaveChanges();
            return true;
        }

        public bool EditBill(BillsViewModel model)
        {
            Bill bill = context.Bills.Where(x => x.Id == model.Id).FirstOrDefault();
            Apartment apartment= context.Apartments.Where(x => x.Number == model.Apartment).FirstOrDefault();
            if (bill==null || apartment==null)
            {
                return false;
            }
            bill.Apartment = apartment;
            bill.IsPayed = model.Ispayed;
            bill.Text = model.Text;
            bill.Amount =decimal.Parse(model.Amount);
            context.SaveChanges();
            return true;
        }

        public List<BillsViewModel> GetAllBills()
        {
            return context.Bills
                .Select(x => new BillsViewModel
                {
                    Apartment = x.Apartment.Number,
                    Amount = Math.Round(x.Amount, 2).ToString(),
                    Text = x.Text,
                    Ispayed = x.IsPayed,
                    Date = x.IssuedOn,
                    Id=x.Id                   
                })
                .ToList();
        }

        public BillsViewModel GetOneBill(string id)
        {
            return context.Bills.Where(x => x.Id == id)
                .Select(x => new BillsViewModel
            {
                Apartment = x.Apartment.Number,
                Amount = Math.Round(x.Amount, 2).ToString(),
                Text = x.Text,
                Ispayed = x.IsPayed,
                Date = x.IssuedOn,
                Id = x.Id
            }).FirstOrDefault();
        }
    }
}
