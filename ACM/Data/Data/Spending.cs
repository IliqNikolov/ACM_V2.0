﻿namespace Data
{ 
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;

    public class Spending
    {
        public Spending()
        {
            Id = Guid.NewGuid().ToString();
            IssuedOn = DateTime.Now;
            IsPayed = false;
        }

        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [MaxLength(500)]
        public string Text { get; set; }

        public bool IsPayed { get; set; }
    }
}
