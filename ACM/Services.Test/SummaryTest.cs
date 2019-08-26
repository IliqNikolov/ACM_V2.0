using Data;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Services.Test
{
    public class SummaryTest  //The Final Boss
    {
        [Fact]
        public async Task TestFinancialSummaryGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SummaryService summaryService = new SummaryService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            Apartment apartment3 = new Apartment { Number = 3 };
            Apartment apartment4 = new Apartment { Number = 4 };
            Bill bill1 = new Bill { Amount = 10, Apartment = apartment1, IsPayed = true };
            Bill bill2 = new Bill { Amount = 20, Apartment = apartment2, IsPayed = true };
            Bill bill3 = new Bill { Amount = 30, Apartment = apartment3, IsPayed = false };
            Bill bill4 = new Bill { Amount = 40, Apartment = apartment4, IsPayed = false };
            Spending spending1 = new Spending{Amount = 100,Text = "beer1",IsPayed = true};
            Spending spending2 = new Spending{Amount = 200,Text = "beer2",IsPayed = true};
            Spending spending3 = new Spending{Amount = 300,Text = "beer3",IsPayed = false};
            Spending spending4 = new Spending{Amount = 400,Text = "beer4",IsPayed = false};
             await context.Apartments.AddAsync(apartment1);
             await context.Apartments.AddAsync(apartment2);
             await context.Apartments.AddAsync(apartment3);
             await context.Apartments.AddAsync(apartment4);
             await context.Bills.AddAsync(bill1);
             await context.Bills.AddAsync(bill2);
             await context.Bills.AddAsync(bill3);
             await context.Bills.AddAsync(bill4);
             await context.Spendings.AddAsync(spending1);
             await context.Spendings.AddAsync(spending2);
             await context.Spendings.AddAsync(spending3);
             await context.Spendings.AddAsync(spending4);
            await context.SaveChangesAsync();
            FinancialSummaryDTO output = summaryService.FinancialSummary();
            Assert.Equal(2, output.GoodHomeowners.Count);
            Assert.Equal(1, output.GoodHomeowners[0].ApartmentNumber);
            Assert.Equal(0, output.GoodHomeowners[0].Amount);
            Assert.Equal(2, output.GoodHomeowners[1].ApartmentNumber);
            Assert.Equal(0, output.GoodHomeowners[1].Amount);
            Assert.Equal(2, output.BadHomeowners.Count);
            Assert.Equal(3, output.BadHomeowners[1].ApartmentNumber);
            Assert.Equal(30, output.BadHomeowners[1].Amount);
            Assert.Equal(4, output.BadHomeowners[0].ApartmentNumber);
            Assert.Equal(40, output.BadHomeowners[0].Amount);
            Assert.Equal(2, output.PaidSpendings.Count);
            Assert.Equal(100, output.PaidSpendings[1].Amount);
            Assert.Equal("beer1", output.PaidSpendings[1].Text);
            Assert.Equal(200, output.PaidSpendings[0].Amount);
            Assert.Equal("beer2", output.PaidSpendings[0].Text);
            Assert.Equal(2, output.UnpaidSpendings.Count);
            Assert.Equal(300, output.UnpaidSpendings[1].Amount);
            Assert.Equal("beer3", output.UnpaidSpendings[1].Text);
            Assert.Equal(400, output.UnpaidSpendings[0].Amount);
            Assert.Equal("beer4", output.UnpaidSpendings[0].Text);
            Assert.Equal(30, output.Paid);
            Assert.Equal(70, output.ToBePaid);
            Assert.Equal(300, output.Spend);
            Assert.Equal(700, output.ToBeSpend);
            Assert.Equal(-900, output.CurrentBalance);
        }

        [Fact]
        public async Task TestFinancialSummaryEmptyBills()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SummaryService summaryService = new SummaryService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            Apartment apartment3 = new Apartment { Number = 3 };
            Apartment apartment4 = new Apartment { Number = 4 };
            Spending spending1 = new Spending { Amount = 100, Text = "beer1", IsPayed = true };
            Spending spending2 = new Spending { Amount = 200, Text = "beer2", IsPayed = true };
            Spending spending3 = new Spending { Amount = 300, Text = "beer3", IsPayed = false };
            Spending spending4 = new Spending { Amount = 400, Text = "beer4", IsPayed = false };
            await context.Apartments.AddAsync(apartment1);
            await context.Apartments.AddAsync(apartment2);
            await context.Apartments.AddAsync(apartment3);
            await context.Apartments.AddAsync(apartment4);
            await context.Spendings.AddAsync(spending1);
            await context.Spendings.AddAsync(spending2);
            await context.Spendings.AddAsync(spending3);
            await context.Spendings.AddAsync(spending4);
            await context.SaveChangesAsync();
            FinancialSummaryDTO output = summaryService.FinancialSummary();
            Assert.Equal(4, output.GoodHomeowners.Count);
            Assert.Empty(output.BadHomeowners);
            Assert.Equal(2, output.PaidSpendings.Count);
            Assert.Equal(100, output.PaidSpendings[1].Amount);
            Assert.Equal("beer1", output.PaidSpendings[1].Text);
            Assert.Equal(200, output.PaidSpendings[0].Amount);
            Assert.Equal("beer2", output.PaidSpendings[0].Text);
            Assert.Equal(2, output.UnpaidSpendings.Count);
            Assert.Equal(300, output.UnpaidSpendings[1].Amount);
            Assert.Equal("beer3", output.UnpaidSpendings[1].Text);
            Assert.Equal(400, output.UnpaidSpendings[0].Amount);
            Assert.Equal("beer4", output.UnpaidSpendings[0].Text);
            Assert.Equal(0, output.Paid);
            Assert.Equal(0, output.ToBePaid);
            Assert.Equal(300, output.Spend);
            Assert.Equal(700, output.ToBeSpend);
            Assert.Equal(-1000, output.CurrentBalance);
        }

        [Fact]
        public async Task TestFinancialSummaryEmptyBillsEmptyApartments()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SummaryService summaryService = new SummaryService(context);
            Spending spending1 = new Spending { Amount = 100, Text = "beer1", IsPayed = true };
            Spending spending2 = new Spending { Amount = 200, Text = "beer2", IsPayed = true };
            Spending spending3 = new Spending { Amount = 300, Text = "beer3", IsPayed = false };
            Spending spending4 = new Spending { Amount = 400, Text = "beer4", IsPayed = false };
            await context.Spendings.AddAsync(spending1);
            await context.Spendings.AddAsync(spending2);
            await context.Spendings.AddAsync(spending3);
            await context.Spendings.AddAsync(spending4);
            await context.SaveChangesAsync();
            FinancialSummaryDTO output = summaryService.FinancialSummary();
            Assert.Empty(output.GoodHomeowners);
            Assert.Empty(output.BadHomeowners);
            Assert.Equal(2, output.PaidSpendings.Count);
            Assert.Equal(100, output.PaidSpendings[1].Amount);
            Assert.Equal("beer1", output.PaidSpendings[1].Text);
            Assert.Equal(200, output.PaidSpendings[0].Amount);
            Assert.Equal("beer2", output.PaidSpendings[0].Text);
            Assert.Equal(2, output.UnpaidSpendings.Count);
            Assert.Equal(300, output.UnpaidSpendings[1].Amount);
            Assert.Equal("beer3", output.UnpaidSpendings[1].Text);
            Assert.Equal(400, output.UnpaidSpendings[0].Amount);
            Assert.Equal("beer4", output.UnpaidSpendings[0].Text);
            Assert.Equal(0, output.Paid);
            Assert.Equal(0, output.ToBePaid);
            Assert.Equal(300, output.Spend);
            Assert.Equal(700, output.ToBeSpend);
            Assert.Equal(-1000, output.CurrentBalance);
        }

        [Fact]
        public async Task TestFinancialSummaryEmptySpendings()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SummaryService summaryService = new SummaryService(context);
            Apartment apartment1 = new Apartment { Number = 1 };
            Apartment apartment2 = new Apartment { Number = 2 };
            Apartment apartment3 = new Apartment { Number = 3 };
            Apartment apartment4 = new Apartment { Number = 4 };
            Bill bill1 = new Bill { Amount = 10, Apartment = apartment1, IsPayed = true };
            Bill bill2 = new Bill { Amount = 20, Apartment = apartment2, IsPayed = true };
            Bill bill3 = new Bill { Amount = 30, Apartment = apartment3, IsPayed = false };
            Bill bill4 = new Bill { Amount = 40, Apartment = apartment4, IsPayed = false };
            await context.Apartments.AddAsync(apartment1);
            await context.Apartments.AddAsync(apartment2);
            await context.Apartments.AddAsync(apartment3);
            await context.Apartments.AddAsync(apartment4);
            await context.Bills.AddAsync(bill1);
            await context.Bills.AddAsync(bill2);
            await context.Bills.AddAsync(bill3);
            await context.Bills.AddAsync(bill4);
            await context.SaveChangesAsync();
            FinancialSummaryDTO output = summaryService.FinancialSummary();
            Assert.Equal(2, output.GoodHomeowners.Count);
            Assert.Equal(1, output.GoodHomeowners[0].ApartmentNumber);
            Assert.Equal(0, output.GoodHomeowners[0].Amount);
            Assert.Equal(2, output.GoodHomeowners[1].ApartmentNumber);
            Assert.Equal(0, output.GoodHomeowners[1].Amount);
            Assert.Equal(2, output.BadHomeowners.Count);
            Assert.Equal(3, output.BadHomeowners[1].ApartmentNumber);
            Assert.Equal(30, output.BadHomeowners[1].Amount);
            Assert.Equal(4, output.BadHomeowners[0].ApartmentNumber);
            Assert.Equal(40, output.BadHomeowners[0].Amount);
            Assert.Empty(output.PaidSpendings);
            Assert.Empty(output.UnpaidSpendings);
            Assert.Equal(30, output.Paid);
            Assert.Equal(70, output.ToBePaid);
            Assert.Equal(0, output.Spend);
            Assert.Equal(0, output.ToBeSpend);
            Assert.Equal(100, output.CurrentBalance);
        }
    }
}