using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Data;
using ACM.Models;

namespace ACM.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly ACMDbContext context;

        public SummaryService(ACMDbContext context)
        {
            this.context = context;
        }
        public FinancialSummaryViewModel FinancialSummary()
        {
            FinancialSummaryViewModel output = new FinancialSummaryViewModel
            {
                Paid = context.Bills
                .Where(x => x.IsPayed)
                .Sum(x => x.Amount),
                ToBePaid = context.Bills
                .Where(x => !x.IsPayed)
                .Sum(x => x.Amount),
                Spend = context.Spendings
                .Where(x => x.IsPayed)
                .Sum(x => x.Amount),
                ToBeSpend = context.Spendings
                .Where(x => !x.IsPayed)
                .Sum(x => x.Amount),
                GoodHomeowners = context.Apartments
                .Where(x => !context.Bills
                .Any(y => y.Apartment == x && !y.IsPayed))
                .Select(x => new WallOfShameElementViewModel
                {
                    ApartmentNumber = x.Number,
                    Amount = 0
                }).ToList(),
                BadHomeowners= context.Apartments
                .Where(x => context.Bills
                .Any(y => y.Apartment == x && !y.IsPayed))
                .Select(x => new WallOfShameElementViewModel
                {
                    ApartmentNumber = x.Number,
                    Amount = context.Bills
                    .Where(y=>y.Apartment==x)
                    .Sum(y=>y.Amount)
                }).ToList(),
                PaidSpendings=context.Spendings
                .Where(x=>x.IsPayed)
                .Select(x=>new SpendingSummaryViewModel
                {
                    Amount=x.Amount,
                    Text=x.Text
                }).ToList(),
                UnpaidSpendings = context.Spendings
                .Where(x => !x.IsPayed)
                .Select(x => new SpendingSummaryViewModel
                {
                    Amount = x.Amount,
                    Text = x.Text
                }).ToList()
            };

            return output;
        }
    }
}
