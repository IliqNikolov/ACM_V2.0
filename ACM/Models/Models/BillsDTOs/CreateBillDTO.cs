using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class CreateBillDTO
    {
        public string Apartment { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public string Amount { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }
    }
}
