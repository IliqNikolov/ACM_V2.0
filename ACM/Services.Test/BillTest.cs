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
    public class BillTest
    {
        [Fact]
        public void TestBillAllApartmentsGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            context.Apartments.Add(apartment1);
            context.Apartments.Add(apartment2);
            context.SaveChanges();
            billService.BillAllApartments("beer", 10);
            Assert.Equal(2, context.Bills.Count());
            Assert.Equal(10, context.Bills.ToList()[0].Amount);
            Assert.Equal(10, context.Bills.ToList()[1].Amount);
            Assert.Equal("beer", context.Bills.ToList()[0].Text);
            Assert.Equal("beer", context.Bills.ToList()[1].Text);
        }
        [Fact]
        public void TestBillAllApartmentsEmptyTable()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            billService.BillAllApartments("beer", 10);
            Assert.Empty(context.Bills.ToList());
        }
        [Fact]
        public void TestBillOneApartmentGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            context.Apartments.Add(apartment1);
            context.SaveChanges();
            string billId=billService.BillOneApartment("1", "beer", 10);
            Assert.Equal(1, context.Bills.Count());
            Assert.Equal(billId, context.Bills.ToList()[0].Id);
            Assert.Equal(10, context.Bills.ToList()[0].Amount);
            Assert.Equal("beer", context.Bills.ToList()[0].Text);
        }
        [Fact]
        public void TestBillOneApartmentInvalidApartment()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Action act = () => billService.BillOneApartment("1", "beer", 10);
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestBillOneApartmentNullApartmentNumber()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Action act = () => billService.BillOneApartment(null, "beer", 10);
            Assert.Throws<InvalidOperationException>(act);
        }
        [Fact]
        public void TestDeleteBillWithGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Bill bill = new Bill { Amount = 10, Apartment = apartment1, Text = "beer" };
            context.Apartments.Add(apartment1);
            context.Bills.Add(bill);
            context.SaveChanges();
            bool output = billService.DeleteBill(bill.Id);
            Assert.True(output);
            Assert.Equal(0, context.Bills.Count());
        }
        [Fact]
        public void TestDeleteBillWithInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Bill bill = new Bill { Amount = 10, Apartment = apartment1, Text = "beer" };
            context.Apartments.Add(apartment1);
            context.Bills.Add(bill);
            context.SaveChanges();
            Action act = () => billService.DeleteBill(bill.Id + "Random String");
            Assert.Throws<ACMException>(act);
            Assert.Equal(1, context.Bills.Count());
        }
        [Fact]
        public void TestEditBillWithGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            Bill bill = new Bill { Amount = 10, Apartment = apartment1, Text = "beer" };
            context.Apartments.Add(apartment1);
            context.Apartments.Add(apartment2);
            context.Bills.Add(bill);
            context.SaveChanges();
            BillsViewModel model = new BillsViewModel {
                Id = bill.Id,
                Amount = "100",
                Apartment = 2,
                Ispayed = true,
                Text = "Alot of beer"
            };
            bool output = billService.EditBill(model);
            Assert.True(output);
            Assert.Equal(100, bill.Amount);
            Assert.Equal(2, bill.Apartment.Number);
            Assert.Equal("Alot of beer", bill.Text);
            Assert.True(bill.IsPayed);
        }
        [Fact]
        public void TestEditBillWithInvalidApartment()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Bill bill = new Bill { Amount = 10, Apartment = apartment1, Text = "beer" };
            context.Apartments.Add(apartment1);
            context.Bills.Add(bill);
            context.SaveChanges();
            BillsViewModel model = new BillsViewModel
            {
                Id = bill.Id,
                Amount = "100",
                Apartment = 2,
                Ispayed = true,
                Text = "Alot of beer"
            };
            Action act = () => billService.EditBill(model);
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestEditBillWithInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            Bill bill = new Bill { Amount = 10, Apartment = apartment1, Text = "beer" };
            context.Apartments.Add(apartment1);
            context.Apartments.Add(apartment2);
            context.Bills.Add(bill);
            context.SaveChanges();
            BillsViewModel model = new BillsViewModel
            {
                Id = bill.Id+"Random string",
                Amount = "100",
                Apartment = 2,
                Ispayed = true,
                Text = "Alot of beer"
            };
            Action act = () => billService.EditBill(model);
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestGetAllBills()
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
            context.Apartments.Add(apartment1);
            context.Apartments.Add(apartment2);
            context.Bills.Add(bill1);
            context.Bills.Add(bill2);
            context.SaveChanges();
            List<BillsViewModel> list = billService.GetAllBills();
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
        public void TestGetOneBillGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            BillService billService = new BillService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Bill bill = new Bill { Amount = 10, Apartment = apartment1, Text = "beer" };
            context.Apartments.Add(apartment1);
            context.Bills.Add(bill);
            context.SaveChanges();
            BillsViewModel newBill = billService.GetOneBill(bill.Id);
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
        public void TestGetWallOfShameListGoodData()
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
            context.Apartments.Add(apartment1);
            context.Apartments.Add(apartment2);
            context.Bills.Add(bill1);
            context.Bills.Add(bill2);
            context.SaveChanges();
            List<WallOfShameElementViewModel> list = billService.GetWallOfShameList();
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
            List<WallOfShameElementViewModel> list = billService.GetWallOfShameList();
            Assert.Empty(list);
        }
        [Fact]
        public void TestGetWallOfShameListAllBillsArePaid()
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
            context.Apartments.Add(apartment1);
            context.Apartments.Add(apartment2);
            context.Bills.Add(bill1);
            context.Bills.Add(bill2);
            context.SaveChanges();
            List<WallOfShameElementViewModel> list = billService.GetWallOfShameList();
            Assert.Empty(list);
        }
        [Fact]
        public void TestPayBillGoodData()
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
            context.Apartments.Add(apartment1);
            context.Bills.Add(bill1);
            context.SaveChanges();
            bool output = billService.PayBill(bill1.Id);
            Assert.True(output);
            Assert.True(bill1.IsPayed);
        }
        [Fact]
        public void TestPayBillBadId()
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
            context.Apartments.Add(apartment1);
            context.Bills.Add(bill1);
            context.SaveChanges();
            Action act = () => billService.PayBill(bill1.Id + "Random string");
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestPayBillPaidBill()
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
            context.Apartments.Add(apartment1);
            context.Bills.Add(bill1);
            context.SaveChanges();
            bool output= billService.PayBill(bill1.Id);
            Assert.False(output);
        }
    }    
}