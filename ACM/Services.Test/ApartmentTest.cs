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
    public class ApartmentTest
    {
        [Fact]
        public async Task TestCreateWithGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            ApartmentService apartmentService = new ApartmentService(context);
            await apartmentService.Create(1);
            Assert.Equal(1, context.Apartments.Count());
        }
        [Fact]
        public async Task TestCreateIfTheIDIOk()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            ApartmentService apartmentService = new ApartmentService(context);
            string id= await apartmentService.Create(1);
            Assert.Equal(1, context.Apartments.Where(x => x.Id == id).FirstOrDefault().Number);
        }
        [Fact]
        public async Task TestCreateWithExistingApartment()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            ApartmentService apartmentService = new ApartmentService(context);
            await apartmentService.Create(1);
            await Assert.ThrowsAsync<ACMException>(() => apartmentService.Create(1));
        }
        [Fact]
        public async Task TestGetAllApartmentsWithGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            ApartmentService apartmentService = new ApartmentService(context);
            ACMUser user = new ACMUser { AppartentNumber = 1 };
            Apartment apartment1 = new Apartment { Number = 1,User=user };
            Apartment apartment2 = new Apartment { Number = 2 };
            await context.Apartments.AddAsync(apartment1);
            await context.Apartments.AddAsync(apartment2);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
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
        public async Task TestGetAppartmentsWithGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            ApartmentService apartmentService = new ApartmentService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            await context.Apartments.AddAsync(apartment1);
            await context.Apartments.AddAsync(apartment2);
            await context.SaveChangesAsync();
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