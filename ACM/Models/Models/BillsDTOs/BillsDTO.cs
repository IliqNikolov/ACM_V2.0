using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class BillsDTO
    {
        [Required]
        public int Apartment { get; set; }

        [Range(0, double.MaxValue)]
        [Required]
        public string Amount { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(500)]
        [Required]
        public string Text { get; set; }

        [Required]
        public bool Ispayed { get; set; }

        public string Id { get; set; }
    }
}
