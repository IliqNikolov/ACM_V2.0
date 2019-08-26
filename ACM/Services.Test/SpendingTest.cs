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
    public class SpendingTest
    {
        [Fact]
        public async Task TestCreateSpending()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SpendingService spendingService = new SpendingService(context);
            SpendingDTO model = new SpendingDTO
            {
                Amount = 10,
                Text = "beer",
                IsPayed = true
            };
            string id = await spendingService.CreateSpending(model);
            Assert.Single(context.Spendings.ToList());
            Assert.True(context.Spendings.Any(x => x.Id == id));
            Assert.Equal("beer", context.Spendings.Where(x => x.Id == id).FirstOrDefault().Text);
            Assert.Equal(10, context.Spendings.Where(x => x.Id == id).FirstOrDefault().Amount);
            Assert.True(context.Spendings.Where(x => x.Id == id).FirstOrDefault().IsPayed);
        }

        [Fact]
        public async Task TestDeleteSpendingGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SpendingService spendingService = new SpendingService(context);
            Spending spending = new Spending
            {
                Amount = 10,
                Text = "beer",
                IsPayed = true
            };
            await context.Spendings.AddAsync(spending);
            await context.SaveChangesAsync();
            bool output = await spendingService.DeleteSpending(spending.Id);
            Assert.True(output);
            Assert.Empty(context.Spendings.ToList());
        }

        [Fact]
        public async Task TestDeleteSpendingInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SpendingService spendingService = new SpendingService(context);
            Spending spending = new Spending
            {
                Amount = 10,
                Text = "beer",
                IsPayed = true
            };
            await context.Spendings.AddAsync(spending);
            await context.SaveChangesAsync();
            await Assert.ThrowsAsync<ACMException>(()
                 => spendingService.DeleteSpending(spending.Id + "Random string"));
        }

        [Fact]
        public async Task TestEditSpedningGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SpendingService spendingService = new SpendingService(context);
            Spending spending = new Spending
            {
                Amount = 10,
                Text = "beer",
                IsPayed = true
            };
            await context.Spendings.AddAsync(spending);
            await context.SaveChangesAsync();
            SpendingDTO model = new SpendingDTO
            {
                Amount = 100,
                Text = "alot of beer",
                IsPayed = false,
                Id = spending.Id
            };
            bool output = await spendingService.EditSpending(model);
            Assert.True(output);
            Assert.Equal(100, context.Spendings.Where(x => x.Id == spending.Id).FirstOrDefault().Amount);
            Assert.Equal("alot of beer", context.Spendings.Where(x => x.Id == spending.Id).FirstOrDefault().Text);
            Assert.False(context.Spendings.Where(x => x.Id == spending.Id).FirstOrDefault().IsPayed);
        }

        [Fact]
        public async Task TestEditSpedningInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SpendingService spendingService = new SpendingService(context);
            Spending spending = new Spending
            {
                Amount = 10,
                Text = "beer",
                IsPayed = true
            };
            await context.Spendings.AddAsync(spending);
            await context.SaveChangesAsync();
            SpendingDTO model = new SpendingDTO
            {
                Amount = 100,
                Text = "alot of beer",
                IsPayed = false,
                Id = spending.Id + "Random string"
            };
            await Assert.ThrowsAsync<ACMException>(() => spendingService.EditSpending(model));
        }

        [Fact]
        public async Task TestGetAllSpendingsGoodData()
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
            await context.Spendings.AddAsync(spending2);
            await context.Spendings.AddAsync(spending1);
            await context.SaveChangesAsync();
            List<SpendingDTO> output = spendingService.GetAllSpendings();
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
            List<SpendingDTO> output = spendingService.GetAllSpendings();
            Assert.Empty(output);
        }

        [Fact]
        public async Task TestGetOneSpendingGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SpendingService spendingService = new SpendingService(context);
            Spending spending = new Spending
            {
                Amount = 10,
                Text = "beer",
                IsPayed = true
            };
            await context.Spendings.AddAsync(spending);
            await context.SaveChangesAsync();
            SpendingDTO output = spendingService.GetOneSpending(spending.Id);
            Assert.Equal(spending.Id, output.Id);
            Assert.Equal(10, output.Amount);
            Assert.Equal("beer", output.Text);
            Assert.True(output.IsPayed);

        }

        [Fact]
        public async Task TestGetOneSpendingInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            SpendingService spendingService = new SpendingService(context);
            Spending spending = new Spending
            {
                Amount = 10,
                Text = "beer",
                IsPayed = true
            };
            await context.Spendings.AddAsync(spending);
            await context.SaveChangesAsync();
            Action act = () => spendingService
            .GetOneSpending(spending.Id + "Random string");
            Assert.Throws<ACMException>(act);
        }
    }
}