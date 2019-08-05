using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class WallOfShameElementViewModel
    {
        public int ApartmentNumber { get; set; }
        public decimal Amount { get; set; }
        public int NumberOfUnpaidBills { get; set; }
    }
}
