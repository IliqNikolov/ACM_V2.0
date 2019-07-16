using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ACM.Data
{
    public class ACMDbContext : IdentityDbContext<ACMUser,IdentityRole,string>
    {
        public DbSet<Apartment> Apartments { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Idea> Ideas { get; set; }

        public DbSet<IP> IPs { get; set; }

        public DbSet<Meeting> Meetings { get; set; }

        public DbSet<RegistrationCode> RegistrationCodes { get; set; }

        public DbSet<Spending> Spendings { get; set; }

        public DbSet<Vote> Votes { get; set; }
        public ACMDbContext(DbContextOptions<ACMDbContext> options)
            : base(options)
        {
        }
    }
}
