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
    public class ApartmentTest
    {
        [Fact]
        public void TestCreateWithGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            ApartmentService apartmentService = new ApartmentService(context);
            apartmentService.Create(1);
            Assert.Equal(1, context.Apartments.Count());
        }
        [Fact]
        public void TestCreateIfTheIDIOk()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            ApartmentService apartmentService = new ApartmentService(context);
            string id=apartmentService.Create(1);
            Assert.Equal(1, context.Apartments.Where(x => x.Id == id).FirstOrDefault().Number);
        }
        [Fact]
        public void TestCreateWithExistingApartment()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            ApartmentService apartmentService = new ApartmentService(context);
            apartmentService.Create(1);
            Action act = () => apartmentService.Create(1);
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestGetAllApartmentsWithGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            ApartmentService apartmentService = new ApartmentService(context);
            ACMUser user = new ACMUser { AppartentNumber = 1 };
            Apartment apartment1 = new Apartment { Number = 1,User=user };
            Apartment apartment2 = new Apartment { Number = 2 };
            context.Apartments.Add(apartment1);
            context.Apartments.Add(apartment2);
            context.Users.Add(user);
            context.SaveChanges();
            List<Models.ApartmentListDTO> list = apartmentService.GetAllApartments();
            Assert.Equal(2, list.Count);
            Assert.Equal(1, list[0].Number);
            Assert.Equal(2, list[1].Number);
            Assert.Equal(1, list[0].RegisteredUsersCount);
            Assert.Equal(0, list[1].RegisteredUsersCount);
        }
        [Fact]
        public void TestGetAllApartmentsWithEmptyData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            ApartmentService apartmentService = new ApartmentService(context);
            List<Models.ApartmentListDTO> list = apartmentService.GetAllApartments();
            Assert.Empty(list);
        }
        [Fact]
        public void TestGetAppartmentsWithGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            ApartmentService apartmentService = new ApartmentService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            context.Apartments.Add(apartment1);
            context.Apartments.Add(apartment2);
            context.SaveChanges();
            List<Models.ApartmentListElementDTO> list = apartmentService.GetAppartments();
            Assert.Equal(2, list.Count);
            Assert.Equal("1", list[0].Number);
            Assert.Equal("2", list[1].Number);
        }
        [Fact]
        public void TestGetAppartmentsWithEmptyData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            ApartmentService apartmentService = new ApartmentService(context);
            List<Models.ApartmentListElementDTO> list = apartmentService.GetAppartments();
            Assert.Empty(list);
        }
        }
}