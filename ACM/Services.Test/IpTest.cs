using Data;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Utilities;
using Xunit;

namespace Services.Test
{
    public class IpTest
    {
        [Fact]
        public void TestAddIpGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            IPService iPService = new IPService(context);
            ACMUser user = new ACMUser {UserName= "gosho@abv.bg", FullName = "gosho" };
            context.Users.Add(user);
            context.SaveChanges();
            string output = iPService.AddNewIp("gosho@abv.bg", "123.123.123...");
            Assert.Single(context.IPs.ToList());
            Assert.True(context.IPs.Any(x => x.Id == output));
            Assert.Equal("gosho@abv.bg", context.IPs.FirstOrDefault().User.UserName);
            Assert.Equal("123.123.123...", context.IPs.FirstOrDefault().IpString);
        }
        [Fact]
        public void TestAddIpInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            IPService iPService = new IPService(context);
            ACMUser user = new ACMUser { UserName = "gosho@abv.bg", FullName = "gosho" };
            context.Users.Add(user);
            context.SaveChanges();
            Action act = () => iPService.AddNewIp("Not gosho@abv.bg", "123.123.123...");
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestCreateGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            IPService iPService = new IPService(context);
            ACMUser user = new ACMUser { UserName = "gosho@abv.bg", FullName = "gosho" };
            context.Users.Add(user);
            context.SaveChanges();
            IpDTO model = new IpDTO(user, "123.123.123...");
            string output = iPService.Create(model);
            Assert.Single(context.IPs.ToList());
            Assert.True(context.IPs.Any(x => x.Id == output));
            Assert.Equal("gosho@abv.bg", context.IPs.FirstOrDefault().User.UserName);
            Assert.Equal("123.123.123...", context.IPs.FirstOrDefault().IpString);
        }
        [Fact]
        public void TestCreateInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            IPService iPService = new IPService(context);
            ACMUser user = new ACMUser { UserName = "gosho@abv.bg", FullName = "gosho" };
            context.Users.Add(user);
            context.SaveChanges();
            IpDTO model = new IpDTO(null, "123.123.123...");
            Action act = () => iPService.Create(model);
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestIsNewIpFalse()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            IPService iPService = new IPService(context);
            ACMUser user = new ACMUser { UserName = "gosho@abv.bg", FullName = "gosho" };
            IP iP = new IP
            {
                IpString = "123.123.123...",
                User = user
            };
            context.Users.Add(user);
            context.IPs.Add(iP);
            context.SaveChanges();
            bool output = iPService.IsNewIp(user.UserName, "123.123.123...");
            Assert.False(output);
        }
        [Fact]
        public void TestIsNewIInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            IPService iPService = new IPService(context);
            ACMUser user = new ACMUser { UserName = "gosho@abv.bg", FullName = "gosho" };
            IP iP = new IP
            {
                IpString = "123.123.123...",
                User = user
            };
            context.Users.Add(user);
            context.IPs.Add(iP);
            context.SaveChanges();
            bool output = iPService.IsNewIp(user.UserName + "Random string", "123.123.123...");
            Assert.True(output);
        }
        [Fact]
        public void TestIsNewIpInvalidIp()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            IPService iPService = new IPService(context);
            ACMUser user = new ACMUser { UserName = "gosho@abv.bg", FullName = "gosho" };
            IP iP = new IP
            {
                IpString = "123.123.123...",
                User = user
            };
            context.Users.Add(user);
            context.IPs.Add(iP);
            context.SaveChanges();
            bool output = iPService.IsNewIp(user.UserName, "123.123.123...Random string");
            Assert.True(output);
        }
    }
}