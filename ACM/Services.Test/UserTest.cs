using Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Utilities;
using Xunit;

namespace Services.Test
{
    public class UserTest
    {
        [Fact]
        public void TestGenerateCodeGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { UserName = "gosho" };
            context.Users.Add(user);
            context.SaveChanges();
            string code = userService.GenerateCode("gosho");
            Assert.True(context.Users.Any(x => x.ExpectedCode == code));
        }
        [Fact]
        public void TestGenerateCodeInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { UserName = "gosho" };
            context.Users.Add(user);
            context.SaveChanges();
            Action act = () => userService.GenerateCode("Not gosho");
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestGetApartmentNumberGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { Email = "gosho" ,AppartentNumber=1};
            context.Users.Add(user);
            context.SaveChanges();
            int output = userService.GetApartmentNumber("gosho");
            Assert.True(context.Users.Any(x => x.AppartentNumber == output));
        }
        [Fact]
        public void TestGetApartmentNumberInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { Email = "gosho", AppartentNumber = 1 };
            context.Users.Add(user);
            context.SaveChanges();
            Action act = () => userService.GetApartmentNumber("Not gosho");
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestIsCodeValidGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { UserName = "gosho",ExpectedCode="1" };
            context.Users.Add(user);
            context.SaveChanges();
            bool output = userService.IsCodeValid("1", "gosho");
            Assert.True(output);
        }
        [Fact]
        public void TestIsCodeValidInvalidCode()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { UserName = "gosho", ExpectedCode = "1" };
            context.Users.Add(user);
            context.SaveChanges();
            bool output = userService.IsCodeValid("2", "gosho");
            Assert.False(output);
        }
        [Fact]
        public void TestIsCodeValidInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { UserName = "gosho", ExpectedCode = "1" };
            context.Users.Add(user);
            context.SaveChanges();
            bool output = userService.IsCodeValid("1", "Not gosho");
            Assert.False(output);
        }
    }
}