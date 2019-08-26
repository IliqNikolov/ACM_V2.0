using Data;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Xunit;

namespace Services.Test
{
    public class IpTest
    {
        [Fact]
        public async Task TestAddIpGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            IPService iPService = new IPService(context);
            ACMUser user = new ACMUser {UserName= "gosho@abv.bg", FullName = "gosho" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            string output = await iPService.AddNewIp("gosho@abv.bg", "123.123.123...");
            Assert.Single(context.IPs.ToList());
            Assert.True(context.IPs.Any(x => x.Id == output));
            Assert.Equal("gosho@abv.bg", context.IPs.FirstOrDefault().User.UserName);
            Assert.Equal("123.123.123...", context.IPs.FirstOrDefault().IpString);
        }

        [Fact]
        public async Task TestAddIpInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            IPService iPService = new IPService(context);
            ACMUser user = new ACMUser { UserName = "gosho@abv.bg", FullName = "gosho" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            await Assert.ThrowsAsync<ACMException>(() 
                => iPService.AddNewIp("Not gosho@abv.bg", "123.123.123..."));
        }

        [Fact]
        public async Task TestCreateGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            IPService iPService = new IPService(context);
            ACMUser user = new ACMUser { UserName = "gosho@abv.bg", FullName = "gosho" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            IpDTO model = new IpDTO(user, "123.123.123...");
            string output = await iPService.Create(model);
            Assert.Single(context.IPs.ToList());
            Assert.True(context.IPs.Any(x => x.Id == output));
            Assert.Equal("gosho@abv.bg", context.IPs.FirstOrDefault().User.UserName);
            Assert.Equal("123.123.123...", context.IPs.FirstOrDefault().IpString);
        }

        [Fact]
        public async Task TestCreateInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            IPService iPService = new IPService(context);
            ACMUser user = new ACMUser { UserName = "gosho@abv.bg", FullName = "gosho" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            IpDTO model = new IpDTO(null, "123.123.123...");
            await Assert.ThrowsAsync<ACMException>(() => iPService.Create(model));
        }

        [Fact]
        public async Task TestIsNewIpFalse()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            IPService iPService = new IPService(context);
            ACMUser user = new ACMUser { UserName = "gosho@abv.bg", FullName = "gosho" };
            IP iP = new IP
            {
                IpString = "123.123.123...",
                User = user
            };
            await context.Users.AddAsync(user);
            await context.IPs.AddAsync(iP);
            await context.SaveChangesAsync();
            bool output = iPService.IsNewIp(user.UserName, "123.123.123...");
            Assert.False(output);
        }

        [Fact]
        public async Task TestIsNewIInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            IPService iPService = new IPService(context);
            ACMUser user = new ACMUser { UserName = "gosho@abv.bg", FullName = "gosho" };
            IP iP = new IP
            {
                IpString = "123.123.123...",
                User = user
            };
            await context.Users.AddAsync(user);
            await context.IPs.AddAsync(iP);
            await context.SaveChangesAsync();
            bool output = iPService.IsNewIp(user.UserName + "Random string", "123.123.123...");
            Assert.True(output);
        }

        [Fact]
        public async Task TestIsNewIpInvalidIp()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            IPService iPService = new IPService(context);
            ACMUser user = new ACMUser { UserName = "gosho@abv.bg", FullName = "gosho" };
            IP iP = new IP
            {
                IpString = "123.123.123...",
                User = user
            };
            await context.Users.AddAsync(user);
            await context.IPs.AddAsync(iP);
            await context.SaveChangesAsync();
            bool output = iPService.IsNewIp(user.UserName, "123.123.123...Random string");
            Assert.True(output);
        }
    }
}