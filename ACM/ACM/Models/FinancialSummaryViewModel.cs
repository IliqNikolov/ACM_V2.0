using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACM.Models
{
    public class FinancialSummaryViewModel
    {
        public decimal Paid { get; set; }
        public decimal ToBePaid { get; set; }
        public decimal Spend { get; set; }
        public decimal ToBeSpend { get; set; }
        public List<WallOfShameElementViewModel> BadHomeowners { get; set; }
        public List<WallOfShameElementViewModel> GoodHomeowners { get; set; }
        public List<SpendingSummaryViewModel> PaidSpendings { get; set; }
        public List<SpendingSummaryViewModel> UnpaidSpendings { get; set; }
    }
}
