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
    public class CodeTest
    {
        [Fact]
        public void TestIsCodeValidTrue()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            CodeService codeService = new CodeService(context);
            RegistrationCode code = new RegistrationCode { Code = "code" };
            context.RegistrationCodes.Add(code);
            context.SaveChanges();
            bool output = codeService.IsCodeValid("code");
            Assert.True(output);
        }
        [Fact]
        public void TestIsCodeValidFalse()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            CodeService codeService = new CodeService(context);
            RegistrationCode code = new RegistrationCode { Code = "code1" };
            context.RegistrationCodes.Add(code);
            context.SaveChanges();
            bool output = codeService.IsCodeValid("code2");
            Assert.False(output);
        }
        [Fact]
        public void TestGetAllCodesGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            CodeService codeService = new CodeService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            context.Apartments.Add(apartment1);
            context.Apartments.Add(apartment2);
            RegistrationCode code1 = new RegistrationCode { Code = "code1",Apartment=apartment1 };
            RegistrationCode code2 = new RegistrationCode { Code = "code2",Apartment=apartment2 };
            context.RegistrationCodes.Add(code1);
            context.RegistrationCodes.Add(code2);
            context.SaveChanges();
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
            List<Models.CodeViewModel> list = codeService.GetAllCodes();
            Assert.Empty(list);
        }
        [Fact]
        public void TestDeleteCodeGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            CodeService codeService = new CodeService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            context.Apartments.Add(apartment1);
            context.Apartments.Add(apartment2);
            RegistrationCode code1 = new RegistrationCode { Code = "code1", Apartment = apartment1 };
            RegistrationCode code2 = new RegistrationCode { Code = "code2", Apartment = apartment2 };
            context.RegistrationCodes.Add(code1);
            context.RegistrationCodes.Add(code2);
            context.SaveChanges();
            bool output = codeService.DeleteCode(code1.Code);
            Assert.True(output);
            Assert.Single(context.RegistrationCodes.ToList());
            Assert.Equal("code2", context.RegistrationCodes.ToList()[0].Code);
        }
        [Fact]
        public void TestDeleteBadCode()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            CodeService codeService = new CodeService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            context.Apartments.Add(apartment1);
            context.Apartments.Add(apartment2);
            RegistrationCode code1 = new RegistrationCode { Code = "code1", Apartment = apartment1 };
            RegistrationCode code2 = new RegistrationCode { Code = "code2", Apartment = apartment2 };
            context.RegistrationCodes.Add(code1);
            context.RegistrationCodes.Add(code2);
            context.SaveChanges();
            Action act = () => codeService.DeleteCode("not a real code");
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestCreateARegistrationCodeGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            CodeService codeService = new CodeService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            context.Apartments.Add(apartment1);
            context.SaveChanges();
            CodeViewModel code = codeService.CreateARegistrationCode("1");
            Assert.Single(context.RegistrationCodes.ToList());
            Assert.Equal(1, context.RegistrationCodes.FirstOrDefault().Apartment.Number);
            Assert.Equal(code.Code, context.RegistrationCodes.FirstOrDefault().Code);            
        }
        [Fact]
        public void TestCreateARegistrationCodeInvalidApartmentNumber()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            CodeService codeService = new CodeService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            context.Apartments.Add(apartment1);
            context.SaveChanges();
            Action act = () => codeService.CreateARegistrationCode("0");
            Assert.Throws<ACMException>(act);
        }
    }
}