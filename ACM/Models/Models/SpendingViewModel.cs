using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class SpendingViewModel
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        [Range(0, double.MaxValue)]
        [Required]
        public decimal Amount { get; set; }

        [MaxLength(500)]
        [Required]
        public string Text { get; set; }

        [Required]
        public bool IsPayed { get; set; }
    }
}
