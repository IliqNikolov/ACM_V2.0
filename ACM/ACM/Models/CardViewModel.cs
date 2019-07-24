using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACM.Models
{
    public class CardViewModel
    {
        public string BillId { get; set; }
        public int Apartment { get; set; }
        public string Text { get; set; }
        public DateTime IssuedOn { get; set; }
        public string BillAmount { get; set; }
        [CreditCard]
        [Required]
        public string CardNumber { get; set; }
        [MinLength(3)]
        [MaxLength(4)]
        [Required]
        public string CVC { get; set; }
    }
}
