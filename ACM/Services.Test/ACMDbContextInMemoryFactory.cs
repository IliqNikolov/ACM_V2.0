using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Services.Test
{
    public class ACMDbContextInMemoryFactory
    {
        public static ACMDbContext InitializeContext()
        {
            var options = new DbContextOptionsBuilder<ACMDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            return new ACMDbContext(options);
        }
    }
}