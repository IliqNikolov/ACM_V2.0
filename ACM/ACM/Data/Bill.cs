﻿namespace ACM
{ 
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;

    public class Bill
    {
        public Bill()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IssuedOn = DateTime.Now;
            this.IsPayed = false;
        }

        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        [Range(0,double.MaxValue)]
        public decimal Amount { get; set; }

        public virtual Apartment Apartment { get; set; }

        public string Text { get; set; }

        public bool IsPayed { get; set; }
    }
}