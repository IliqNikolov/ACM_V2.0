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
    public class BillTest
    {
        [Fact]
        public async Task TestBillAllApartmentsGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            await context.Apartments.AddAsync(apartment1);
            await context.Apartments.AddAsync(apartment2);
            await context.SaveChangesAsync();
            await billService.BillAllApartments("beer", 10);
            Assert.Equal(2, context.Bills.Count());
            Assert.Equal(10, context.Bills.ToList()[0].Amount);
            Assert.Equal(10, context.Bills.ToList()[1].Amount);
            Assert.Equal("beer", context.Bills.ToList()[0].Text);
            Assert.Equal("beer", context.Bills.ToList()[1].Text);
        }
        [Fact]
        public async Task TestBillAllApartmentsEmptyTableAsync()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            await billService.BillAllApartments("beer", 10);
            Assert.Empty(context.Bills.ToList());
        }
        [Fact]
        public async Task TestBillOneApartmentGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            await context.Apartments.AddAsync(apartment1);
            await context.SaveChangesAsync();
            string billId= await billService.BillOneApartment("1", "beer", 10);
            Assert.Equal(1, context.Bills.Count());
            Assert.Equal(billId, context.Bills.ToList()[0].Id);
            Assert.Equal(10, context.Bills.ToList()[0].Amount);
            Assert.Equal("beer", context.Bills.ToList()[0].Text);
        }
        [Fact]
        public async Task TestBillOneApartmentInvalidApartment()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            await Assert.ThrowsAsync<ACMException>(() =>  billService.BillOneApartment("1", "beer", 10));
        }
        [Fact]
        public async Task TestBillOneApartmentNullApartmentNumber()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            await Assert.ThrowsAsync<InvalidOperationException>(() => billService.BillOneApartment(null, "beer", 10));
        }
        [Fact]
        public async Task TestDeleteBillWithGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Bill bill = new Bill { Amount = 10, Apartment = apartment1, Text = "beer" };
            await context.Apartments.AddAsync(apartment1);
            await context.Bills.AddAsync(bill);
            await context.SaveChangesAsync();
            bool output = await billService.DeleteBill(bill.Id);
            Assert.True(output);
            Assert.Equal(0, context.Bills.Count());
        }
        [Fact]
        public async Task TestDeleteBillWithInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Bill bill = new Bill { Amount = 10, Apartment = apartment1, Text = "beer" };
            await context.Apartments.AddAsync(apartment1);
            await context.Bills.AddAsync(bill);
            await context.SaveChangesAsync();
            await Assert.ThrowsAsync<ACMException>(() => billService.DeleteBill(bill.Id + "Random String"));
            Assert.Equal(1, context.Bills.Count());
        }
        [Fact]
        public async Task TestEditBillWithGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            Bill bill = new Bill { Amount = 10, Apartment = apartment1, Text = "beer" };
            await context.Apartments.AddAsync(apartment1);
            await context.Apartments.AddAsync(apartment2);
            await context.Bills.AddAsync(bill);
            await context.SaveChangesAsync();
            BillsDTO model = new BillsDTO {
                Id = bill.Id,
                Amount = "100",
                Apartment = 2,
                Ispayed = true,
                Text = "Alot of beer"
            };
            bool output = await billService.EditBill(model);
            Assert.True(output);
            Assert.Equal(100, bill.Amount);
            Assert.Equal(2, bill.Apartment.Number);
            Assert.Equal("Alot of beer", bill.Text);
            Assert.True(bill.IsPayed);
        }
        [Fact]
        public async Task TestEditBillWithInvalidApartment()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Bill bill = new Bill { Amount = 10, Apartment = apartment1, Text = "beer" };
            await context.Apartments.AddAsync(apartment1);
            await context.Bills.AddAsync(bill);
            await context.SaveChangesAsync();
            BillsDTO model = new BillsDTO
            {
                Id = bill.Id,
                Amount = "100",
                Apartment = 2,
                Ispayed = true,
                Text = "Alot of beer"
            };
            await Assert.ThrowsAsync<ACMException>(() => billService.EditBill(model));
        }
        [Fact]
        public async Task TestEditBillWithInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            Bill bill = new Bill { Amount = 10, Apartment = apartment1, Text = "beer" };
            await context.Apartments.AddAsync(apartment1);
            await context.Apartments.AddAsync(apartment2);
            await context.Bills.AddAsync(bill);
            await context.SaveChangesAsync();
            BillsDTO model = new BillsDTO
            {
                Id = bill.Id+"Random string",
                Amount = "100",
                Apartment = 2,
                Ispayed = true,
                Text = "Alot of beer"
            };
            await Assert.ThrowsAsync<ACMException>(() =>  billService.EditBill(model));
        }
        [Fact]
        public async Task TestGetAllBills()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            Bill bill1 = new Bill
            {
                Amount = 10,
                Apartment = apartment1,
                Text = "beer",
                IsPayed = true,
        };
            Bill bill2 = new Bill
            {
                Amount = 1,
                Apartment = apartment2,
                Text = "beer2",
                IsPayed = false,
            };
            await context.Apartments.AddAsync(apartment1);
            await context.Apartments.AddAsync(apartment2);
            await context.Bills.AddAsync(bill1);
            await context.Bills.AddAsync(bill2);
            await context.SaveChangesAsync();
            List<BillsDTO> list = billService.GetAllBills();
            Assert.Equal(2, list.Count);
            Assert.Equal(bill2.Id, list[0].Id);
            Assert.Equal(bill2.Apartment.Number, list[0].Apartment);
            Assert.Equal(bill2.Amount.ToString(), list[0].Amount);
            Assert.Equal(bill2.IssuedOn, list[0].Date);
            Assert.Equal(bill2.Text, list[0].Text);
            Assert.True(list[1].Ispayed);
            Assert.Equal(bill1.Id, list[1].Id);
            Assert.Equal(bill1.Apartment.Number, list[1].Apartment);
            Assert.Equal(bill1.Amount.ToString(), list[1].Amount);
            Assert.Equal(bill1.IssuedOn, list[1].Date);
            Assert.Equal(bill1.Text, list[1].Text);
            Assert.False(list[0].Ispayed);
        }
        [Fact]
        public async Task TestGetOneBillGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Bill bill = new Bill { Amount = 10, Apartment = apartment1, Text = "beer" };
            await context.Apartments.AddAsync(apartment1);
            await context.Bills.AddAsync(bill);
            await context.SaveChangesAsync();
            BillsDTO newBill = billService.GetOneBill(bill.Id);
            Assert.Equal(bill.Id, newBill.Id);
            Assert.Equal(bill.Apartment.Number, newBill.Apartment);
            Assert.Equal(bill.Amount.ToString(), newBill.Amount);
            Assert.Equal(bill.IssuedOn, newBill.Date);
            Assert.Equal(bill.Text, newBill.Text);
            Assert.False(newBill.Ispayed);
        }
        [Fact]
        public void TestGetOneBillInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Action act = () => billService.GetOneBill("id");
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public async Task TestGetWallOfShameListGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            Bill bill1 = new Bill
            {
                Amount = 10,
                Apartment = apartment1,
                Text = "beer",
                IsPayed = false,
            };
            Bill bill2 = new Bill
            {
                Amount = 1,
                Apartment = apartment1,
                Text = "beer2",
                IsPayed = false,
            };
            await context.Apartments.AddAsync(apartment1);
            await context.Apartments.AddAsync(apartment2);
            await context.Bills.AddAsync(bill1);
            await context.Bills.AddAsync(bill2);
            await context.SaveChangesAsync();
            List<WallOfShameElementDTO> list = billService.GetWallOfShameList();
            Assert.Single(list);
            Assert.Equal(11, list[0].Amount);
            Assert.Equal(2, list[0].NumberOfUnpaidBills);
            Assert.Equal(1, list[0].ApartmentNumber);

        }
        [Fact]
        public void TestGetWallOfShameListEmptyTable()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            List<WallOfShameElementDTO> list = billService.GetWallOfShameList();
            Assert.Empty(list);
        }
        [Fact]
        public async Task TestGetWallOfShameListAllBillsArePaid()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            Bill bill1 = new Bill
            {
                Amount = 10,
                Apartment = apartment1,
                Text = "beer",
                IsPayed = true,
            };
            Bill bill2 = new Bill
            {
                Amount = 1,
                Apartment = apartment1,
                Text = "beer2",
                IsPayed = true,
            };
            await context.Apartments.AddAsync(apartment1);
            await context.Apartments.AddAsync(apartment2);
            await context.Bills.AddAsync(bill1);
            await context.Bills.AddAsync(bill2);
            await context.SaveChangesAsync();
            List<WallOfShameElementDTO> list = billService.GetWallOfShameList();
            Assert.Empty(list);
        }
        [Fact]
        public async Task TestPayBillGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Bill bill1 = new Bill
            {
                Amount = 10,
                Apartment = apartment1,
                Text = "beer",
                IsPayed = false,
            };          
            await context.Apartments.AddAsync(apartment1);
            await context.Bills.AddAsync(bill1);
            await context.SaveChangesAsync();
            bool output = await billService.PayBill(bill1.Id);
            Assert.True(output);
            Assert.True(bill1.IsPayed);
        }
        [Fact]
        public async Task TestPayBillBadId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Bill bill1 = new Bill
            {
                Amount = 10,
                Apartment = apartment1,
                Text = "beer",
                IsPayed = false,
            };
            await context.Apartments.AddAsync(apartment1);
            await context.Bills.AddAsync(bill1);
            await context.SaveChangesAsync();
            await Assert.ThrowsAsync<ACMException>(() => billService.PayBill(bill1.Id + "Random string"));
        }
        [Fact]
        public async Task TestPayBillPaidBill()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Bill bill1 = new Bill
            {
                Amount = 10,
                Apartment = apartment1,
                Text = "beer",
                IsPayed = true,
            };
            await context.Apartments.AddAsync(apartment1);
            await context.Bills.AddAsync(bill1);
            await context.SaveChangesAsync();
            bool output= await billService.PayBill(bill1.Id);
            Assert.False(output);
        }
    }    
}