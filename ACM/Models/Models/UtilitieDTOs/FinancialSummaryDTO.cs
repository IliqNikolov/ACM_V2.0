using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class FinancialSummaryDTO
    {
        public decimal Paid { get; set; }

        public decimal ToBePaid { get; set; }

        public decimal Spend { get; set; }

        public decimal ToBeSpend { get; set; }

        public List<WallOfShameElementDTO> BadHomeowners { get; set; }

        public List<WallOfShameElementDTO> GoodHomeowners { get; set; }

        public List<SpendingSummaryDTO> PaidSpendings { get; set; }

        public List<SpendingSummaryDTO> UnpaidSpendings { get; set; }

        public decimal CurrentBalance { get; set; }
    }
}
