using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACM.Models
{
    public class BillsViewModel
    {
        public int Apartment { get; set; }
        public string Amount { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public bool Ispayed { get; set; }
        public string Id { get; set; }
    }
}
