using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Models;
using Utilities;

namespace Services
{
    public class SpendingService : ISpendingService
    {
        private readonly ACMDbContext context;

        public SpendingService(ACMDbContext context)
        {
            this.context = context;
        }

        public string CreateSpending(SpendingViewModel model)
        {
            Spending spending = new Spending
            {
                Amount = model.Amount,
                Text = model.Text,
                IsPayed = model.IsPayed
            };
            context.Spendings.Add(spending);
            context.SaveChanges();
            return spending.Id;
        }

        public bool DeleteSpending(string id)
        {
            Spending spending = context.Spendings
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (spending == null)
            {
                throw new Utilities.ACMException();
            }
            context.Spendings.Remove(spending);
            context.SaveChanges();
            return true;
        }

        public bool EditSpending(SpendingViewModel model)
        {
            Spending spending = context.Spendings
                .Where(x => x.Id == model.Id)
                .FirstOrDefault();
            if (spending==null)
            {
                throw new Utilities.ACMException();
            }
            spending.Amount = model.Amount;
            spending.IsPayed = model.IsPayed;
            spending.Text = model.Text;
            context.SaveChanges();
            return true;
        }

        public List<SpendingViewModel> GetAllSpendings()
        {
            return context.Spendings.Select(x => new SpendingViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                IsPayed = x.IsPayed,
                IssuedOn = x.IssuedOn,
                Text = x.Text
            })
                .OrderByDescending(x => x.IssuedOn)
                .ToList(); 
        }

        public SpendingViewModel GetOneSpending(string id)
        {
            SpendingViewModel model = context.Spendings
                .Where(x => x.Id == id)
                .Select(x => new SpendingViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    IsPayed = x.IsPayed,
                    IssuedOn = x.IssuedOn,
                    Text = x.Text
                }).FirstOrDefault();
            if (model==null)
            {
                throw new ACMException();
            }
            return model;
        }
    }
}
