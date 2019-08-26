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
    public class CodeTest
    {
        [Fact]
        public async Task TestIsCodeValidTrue()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            CodeService codeService = new CodeService(context);
            RegistrationCode code = new RegistrationCode { Code = "code" };
            await context.RegistrationCodes.AddAsync(code);
            await context.SaveChangesAsync();
            bool output = codeService.IsCodeValid("code");
            Assert.True(output);
        }

        [Fact]
        public async Task TestIsCodeValidFalse()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            CodeService codeService = new CodeService(context);
            RegistrationCode code = new RegistrationCode { Code = "code1" };
            await context.RegistrationCodes.AddAsync(code);
            await context.SaveChangesAsync();
            bool output = codeService.IsCodeValid("code2");
            Assert.False(output);
        }

        [Fact]
        public async Task TestGetAllCodesGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            CodeService codeService = new CodeService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            await context.Apartments.AddAsync(apartment1);
            await context.Apartments.AddAsync(apartment2);
            RegistrationCode code1 = new RegistrationCode { Code = "code1",Apartment=apartment1 };
            RegistrationCode code2 = new RegistrationCode { Code = "code2",Apartment=apartment2 };
            await context.RegistrationCodes.AddAsync(code1);
            await context.RegistrationCodes.AddAsync(code2);
            await context.SaveChangesAsync();
            var list = codeService.GetAllCodes();
            Assert.Equal(2, list.Count);
            Assert.Equal(1, list[0].ApartmentNumber);
            Assert.Equal("code1", list[0].Code);
            Assert.Equal(2, list[1].ApartmentNumber);
            Assert.Equal("code2", list[1].Code);
        }

        [Fact]
        public void TestGetAllCodesEmptyTable()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            CodeService codeService = new CodeService(context);
            List<Models.CodeDTO> list = codeService.GetAllCodes();
            Assert.Empty(list);
        }

        [Fact]
        public async Task TestDeleteCodeGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            CodeService codeService = new CodeService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            await context.Apartments.AddAsync(apartment1);
            await context.Apartments.AddAsync(apartment2);
            RegistrationCode code1 = new RegistrationCode { Code = "code1", Apartment = apartment1 };
            RegistrationCode code2 = new RegistrationCode { Code = "code2", Apartment = apartment2 };
            await context.RegistrationCodes.AddAsync(code1);
            await context.RegistrationCodes.AddAsync(code2);
            await context.SaveChangesAsync();
            bool output = await codeService.DeleteCode(code1.Code);
            Assert.True(output);
            Assert.Single(context.RegistrationCodes.ToList());
            Assert.Equal("code2", context.RegistrationCodes.ToList()[0].Code);
        }

        [Fact]
        public async Task TestDeleteBadCode()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            CodeService codeService = new CodeService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            await context.Apartments.AddAsync(apartment1);
            await context.Apartments.AddAsync(apartment2);
            RegistrationCode code1 = new RegistrationCode { Code = "code1", Apartment = apartment1 };
            RegistrationCode code2 = new RegistrationCode { Code = "code2", Apartment = apartment2 };
            await context.RegistrationCodes.AddAsync(code1);
            await context.RegistrationCodes.AddAsync(code2);
            await context.SaveChangesAsync();
            await Assert.ThrowsAsync<ACMException>(() =>  codeService.DeleteCode("not a real code"));
        }

        [Fact]
        public async Task TestCreateARegistrationCodeGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            CodeService codeService = new CodeService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            await context.Apartments.AddAsync(apartment1);
            await context.SaveChangesAsync();
            CodeDTO code = await codeService.CreateARegistrationCode("1");
            Assert.Single(context.RegistrationCodes.ToList());
            Assert.Equal(1, context.RegistrationCodes.FirstOrDefault().Apartment.Number);
            Assert.Equal(code.Code, context.RegistrationCodes.FirstOrDefault().Code);            
        }

        [Fact]
        public async Task TestCreateARegistrationCodeInvalidApartmentNumber()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            CodeService codeService = new CodeService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            await context.Apartments.AddAsync(apartment1);
            await context.SaveChangesAsync();
            await Assert.ThrowsAsync<ACMException>(() =>  codeService.CreateARegistrationCode("0"));
        }
    }
}