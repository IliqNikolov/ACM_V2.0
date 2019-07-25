using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACM.Models
{
    public class SpendingViewModel
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [MaxLength(500)]
        public string Text { get; set; }

        public bool IsPayed { get; set; }
    }
}
