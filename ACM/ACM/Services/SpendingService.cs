using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Data;
using ACM.Models;

namespace ACM.Services
{
    public class SpendingService : ISpendingService
    {
        private readonly ACMDbContext context;

        public SpendingService(ACMDbContext context)
        {
            this.context = context;
        }

        public void CreateSpending(SpendingViewModel model)
        {
            context.Spendings.Add(new Spending
            {
                Amount = model.Amount,
                Text = model.Text,
                IsPayed = model.IsPayed
            });
            context.SaveChanges();
        }

        public bool DeleteSpending(string id)
        {
            Spending spending = context.Spendings
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (spending == null)
            {
                return false;
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
                return false;
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
            return context.Spendings
                .Where(x=>x.Id==id)
                .Select(x => new SpendingViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                IsPayed = x.IsPayed,
                IssuedOn = x.IssuedOn,
                Text = x.Text
            }).FirstOrDefault();
        }
    }
}
