﻿namespace Data
{ 
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;

    public class Bill
    {
        public Bill()
        {
            Id = Guid.NewGuid().ToString();
            IssuedOn = DateTime.Now;
            IsPayed = false;
        }

        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        [Required]
        [Range(0,double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public virtual Apartment Apartment { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        public bool IsPayed { get; set; }
    }
}
