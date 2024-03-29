﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Data;
using Models;
using Data;
using Utilities;

namespace Services
{
    public class BillService : IBillService
    {
        private readonly ACMDbContext context;

        public BillService(ACMDbContext context)
        {
            this.context = context;
        }

        public async Task BillAllApartments(string text, decimal amount)
        {
            IQueryable apartments = context.Apartments;
            foreach (var apartment in apartments)
            {
                await context.Bills.AddAsync(new Bill { Apartment = (Apartment)apartment, Text = text, Amount = amount });
            }
            await context.SaveChangesAsync();
        }

        public async Task<string> BillOneApartment(string id, string text, decimal amount)
        {
            Apartment apartment = context.Apartments
                .Where(x => x.Number ==int.Parse(id))
                .FirstOrDefault();
            if (apartment==null)
            {
                throw new Utilities.ACMException();
            }
            Bill bill = new Bill { Apartment = apartment, Text = text, Amount = amount };
            await context.Bills.AddAsync(bill);
            await context.SaveChangesAsync();
            return bill.Id;
        }

        public async Task<bool> DeleteBill(string id)
        {
            Bill bill = context.Bills
                .Where(x => x.Id == id).FirstOrDefault();
            if (bill==null)
            {
                throw new Utilities.ACMException();
            }
            context.Bills.Remove(bill);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditBill(BillsDTO model)
        {
            Bill bill = context.Bills.Where(x => x.Id == model.Id).FirstOrDefault();
            Apartment apartment= context.Apartments.Where(x => x.Number == model.Apartment).FirstOrDefault();
            if (bill==null || apartment==null)
            {
                throw new Utilities.ACMException();
            }
            bill.Apartment = apartment;
            bill.IsPayed = model.Ispayed;
            bill.Text = model.Text;
            bill.Amount =decimal.Parse(model.Amount);
            await context.SaveChangesAsync();
            return true;
        }

        public List<BillsDTO> GetAllBills()
        {
            return context.Bills
                .Select(x => new BillsDTO
                {
                    Apartment = x.Apartment.Number,
                    Amount = Math.Round(x.Amount, 2).ToString(),
                    Text = x.Text,
                    Ispayed = x.IsPayed,
                    Date = x.IssuedOn,
                    Id=x.Id                   
                })
                .OrderByDescending(x=>x.Date)
                .ToList();
        }

        public BillsDTO GetOneBill(string id)
        {
            BillsDTO bill = context.Bills.Where(x => x.Id == id)
                .Select(x => new BillsDTO
            {
                Apartment = x.Apartment.Number,
                Amount = Math.Round(x.Amount, 2).ToString(),
                Text = x.Text,
                Ispayed = x.IsPayed,
                Date = x.IssuedOn,
                Id = x.Id
            }).FirstOrDefault();
            if (bill==null)
            {
                throw new ACMException();
            }
            return bill;
        }

        public List<WallOfShameElementDTO> GetWallOfShameList()
        {
            return context.Apartments.Select(x => new WallOfShameElementDTO
            {
                Amount = context.Bills.Where(y => y.Apartment.Number == x.Number && !y.IsPayed).Sum(y => y.Amount),
                NumberOfUnpaidBills = context.Bills.Where(y => y.Apartment.Number == x.Number && !y.IsPayed).Count(),
                ApartmentNumber = x.Number
            })
                .Where(x=>x.Amount>0)
                .OrderByDescending(x=>x.Amount)
                .ThenByDescending(x=>x.NumberOfUnpaidBills)
                .ToList();
        }

        public async Task<bool> PayBill(string id)
        {
            Bill bill = context.Bills
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (bill==null)
            {
                throw new Utilities.ACMException();
            }
            if (bill.IsPayed)
            {
                return false;
            }
            bill.IsPayed = true;
            await context.SaveChangesAsync();
            return true;
        }
    }
}
