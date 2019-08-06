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
    public class SpendingTest
    {
        [Fact]
        public void TestCreateSpending()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SpendingService spendingService = new SpendingService(context);
            SpendingViewModel model = new SpendingViewModel
            {
                Amount = 10,
                Text = "beer",
                IsPayed = true
            };
            string id = spendingService.CreateSpending(model);
            Assert.Single(context.Spendings.ToList());
            Assert.True(context.Spendings.Any(x => x.Id == id));
            Assert.Equal("beer", context.Spendings.Where(x => x.Id == id).FirstOrDefault().Text);
            Assert.Equal(10, context.Spendings.Where(x => x.Id == id).FirstOrDefault().Amount);
            Assert.True(context.Spendings.Where(x => x.Id == id).FirstOrDefault().IsPayed);
        }
        [Fact]
        public void TestDeleteSpendingGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SpendingService spendingService = new SpendingService(context);
            Spending spending = new Spending
            {
                Amount = 10,
                Text = "beer",
                IsPayed = true
            };
            context.Spendings.Add(spending);
            context.SaveChanges();
            bool output = spendingService.DeleteSpending(spending.Id);
            Assert.True(output);
            Assert.Empty(context.Spendings.ToList());
        }
        [Fact]
        public void TestDeleteSpendingInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SpendingService spendingService = new SpendingService(context);
            Spending spending = new Spending
            {
                Amount = 10,
                Text = "beer",
                IsPayed = true
            };
            context.Spendings.Add(spending);
            context.SaveChanges();
            Action act = () => spendingService.DeleteSpending(spending.Id+"Random string");
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestEditSpedningGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SpendingService spendingService = new SpendingService(context);
            Spending spending = new Spending
            {
                Amount = 10,
                Text = "beer",
                IsPayed = true
            };
            context.Spendings.Add(spending);
            context.SaveChanges();
            SpendingViewModel model = new SpendingViewModel
            {
                Amount = 100,
                Text = "alot of beer",
                IsPayed = false,
                Id = spending.Id
            };
            bool output = spendingService.EditSpending(model);
            Assert.True(output);
            Assert.Equal(100, context.Spendings.Where(x => x.Id == spending.Id).FirstOrDefault().Amount);
            Assert.Equal("alot of beer", context.Spendings.Where(x => x.Id == spending.Id).FirstOrDefault().Text);
            Assert.False(context.Spendings.Where(x => x.Id == spending.Id).FirstOrDefault().IsPayed);
        }
        [Fact]
        public void TestEditSpedningInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SpendingService spendingService = new SpendingService(context);
            Spending spending = new Spending
            {
                Amount = 10,
                Text = "beer",
                IsPayed = true
            };
            context.Spendings.Add(spending);
            context.SaveChanges();
            SpendingViewModel model = new SpendingViewModel
            {
                Amount = 100,
                Text = "alot of beer",
                IsPayed = false,
                Id = spending.Id + "Random string"
            };
            Action act = () => spendingService.EditSpending(model);
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestGetAllSpendingsGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SpendingService spendingService = new SpendingService(context);
            Spending spending1 = new Spending
            {
                Amount = 10,
                Text = "beer1",
                IsPayed = true
            };
            Spending spending2 = new Spending
            {
                Amount = 20,
                Text = "beer2",
                IsPayed = false
            };
            context.Spendings.Add(spending1);
            context.Spendings.Add(spending2);
            context.SaveChanges();
            List<SpendingViewModel> output = spendingService.GetAllSpendings();
            Assert.Equal(2, output.Count);
            Assert.True(context.Spendings.Any(x => x.Id == spending1.Id));
            Assert.Equal(20, output[0].Amount);
            Assert.Equal("beer2", output[0].Text);
            Assert.False(output[0].IsPayed );
            Assert.True(context.Spendings.Any(x => x.Id == spending2.Id));
            Assert.Equal(10, output[1].Amount);
            Assert.Equal("beer1", output[1].Text);
            Assert.True(output[1].IsPayed);
        }
        [Fact]
        public void TestGetAllSpendingsEmptyTable()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SpendingService spendingService = new SpendingService(context);
            List<SpendingViewModel> output = spendingService.GetAllSpendings();
            Assert.Empty(output);
        }
        [Fact]
        public void TestGetOneSpendingGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SpendingService spendingService = new SpendingService(context);
            Spending spending = new Spending
            {
                Amount = 10,
                Text = "beer",
                IsPayed = true
            };
            context.Spendings.Add(spending);
            context.SaveChanges();
            SpendingViewModel output = spendingService.GetOneSpending(spending.Id);
            Assert.Equal(spending.Id, output.Id);
            Assert.Equal(10, output.Amount);
            Assert.Equal("beer", output.Text);
            Assert.True(output.IsPayed);

        }
        [Fact]
        public void TestGetOneSpendingInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SpendingService spendingService = new SpendingService(context);
            Spending spending = new Spending
            {
                Amount = 10,
                Text = "beer",
                IsPayed = true
            };
            context.Spendings.Add(spending);
            context.SaveChanges();
            Action act = () => spendingService.GetOneSpending(spending.Id + "Random string");
            Assert.Throws<ACMException>(act);
        }
    }
}