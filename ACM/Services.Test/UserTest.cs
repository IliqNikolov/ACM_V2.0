using Data;
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
    public class UserTest
    {
        [Fact]
        public async Task TestGenerateCodeGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { UserName = "gosho" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            string code =await userService.GenerateCode("gosho");
            Assert.True(context.Users.Any(x => x.ExpectedCode == code));
        }

        [Fact]
        public async Task TestGenerateCodeInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { UserName = "gosho" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            await Assert.ThrowsAsync<ACMException>(() 
                => userService.GenerateCode("Not gosho"));
        }

        [Fact]
        public async Task TestGetApartmentNumberGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { Email = "gosho" ,AppartentNumber=1};
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            int output = userService.GetApartmentNumber("gosho");
            Assert.True(context.Users.Any(x => x.AppartentNumber == output));
        }

        [Fact]
        public async Task TestGetApartmentNumberInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { Email = "gosho", AppartentNumber = 1 };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            Action act = () => userService.GetApartmentNumber("Not gosho");
            Assert.Throws<ACMException>(act);
        }

        [Fact]
        public async Task TestIsCodeValidGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { UserName = "gosho",ExpectedCode="1" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            bool output = userService.IsCodeValid("1", "gosho");
            Assert.True(output);
        }

        [Fact]
        public async Task TestIsCodeValidInvalidCode()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { UserName = "gosho", ExpectedCode = "1" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            bool output = userService.IsCodeValid("2", "gosho");
            Assert.False(output);
        }

        [Fact]
        public async Task TestIsCodeValidInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { UserName = "gosho", ExpectedCode = "1" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            bool output = userService.IsCodeValid("1", "Not gosho");
            Assert.False(output);
        }

        [Fact]
        public async Task TestIsUserValidGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { Email = "gosho" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            bool output = userService.IsUserValid("gosho");
            Assert.True(output);
        }

        [Fact]
        public async Task TestIsUserValidinvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { Email = "gosho" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            bool output = userService.IsUserValid("Not gosho");
            Assert.False(output);
        }

        [Fact]
        public async Task TestGetOneUserGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { Email = "gosho" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            ACMUser output = userService.GetOneUser("gosho");
            Assert.NotNull(output);
            Assert.Equal("gosho",output.Email);
        }

        [Fact]
        public async Task TestGetOneUserInvalidEmail()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            UserService userService = new UserService(context);
            ACMUser user = new ACMUser { Email = "gosho" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            Action  act = () =>userService.GetOneUser("Not gosho");
            Assert.Throws<ACMException>(act);
        }
    }
}