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
    public class HomeownerTest
    {
        [Fact]
        public async Task TestAdminDeleteIdeaGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            Idea idea = new Idea { Id = "1" };
            await context.AddAsync(idea);
            await context.SaveChangesAsync();
            bool output = await homeownerSevice.AdminDeleteIdea("1");
            Assert.True(output);
            Assert.Empty(context.Ideas.ToList());
        }
        [Fact]
        public async Task TestAdminDeleteIdeaInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            Idea idea = new Idea { Id = "1" };
            await context.AddAsync(idea);
            await context.SaveChangesAsync();
            await Assert.ThrowsAsync<ACMException>(() =>  homeownerSevice.AdminDeleteIdea("2"));
        }
        [Fact]
        public async Task TestAllGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            await context.Users.AddAsync(user);
            await context.Ideas.AddAsync(idea1);
            await context.Ideas.AddAsync(idea2);
            await context.SaveChangesAsync();
            var list = homeownerSevice.All();
            Assert.Equal(2, list.Count);
            Assert.Equal("1", list[1].Id);
            Assert.Equal("idea1", list[1].Text);
            Assert.Equal("gosho@abv.bg", list[1].UserName);
            Assert.Equal("gosho", list[1].Name);
            Assert.Equal("2", list[0].Id);
            Assert.Equal("idea2", list[0].Text);
            Assert.Equal("gosho@abv.bg", list[0].UserName);
            Assert.Equal("gosho", list[0].Name);
        }
        [Fact]
        public void TestAllEmptyTable()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            var list = homeownerSevice.All();
            Assert.Empty(list);
        }
        [Fact]
        public async Task TestCreateGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            string id = await homeownerSevice.Create("beer", "gosho@abv.bg");
            Assert.Single(context.Ideas.ToList());
            Assert.Equal("beer", context.Ideas
                .Where(x => x.Id == id)
                .FirstOrDefault()
                .Text);
            Assert.Equal("gosho@abv.bg", context.Ideas
                .Where(x => x.Id == id)
                .FirstOrDefault()
                .User.Email);
        }
        [Fact]
        public async Task TestCreateInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg" };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            await Assert.ThrowsAsync<ACMException>(() 
                => homeownerSevice.Create("beer", "NOT gosho@abv.bg"));
        }
        [Fact]
        public async Task TestDeleteIdeaGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            await context.Users.AddAsync(user);
            await context.Ideas.AddAsync(idea1);
            await context.Ideas.AddAsync(idea2);
            await context.SaveChangesAsync();
            bool output = await homeownerSevice.DeleteIdea(idea1.Id, user.Email);
            Assert.True(output);
            Assert.Single(context.Ideas.ToList());
            Assert.True(context.Ideas.Any(x => x.Id == idea2.Id));
        }
        [Fact]
        public async Task TestDeleteIdeaInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            await context.Users.AddAsync(user);
            await context.Ideas.AddAsync(idea1);
            await context.Ideas.AddAsync(idea2);
            await context.SaveChangesAsync();
            await Assert.ThrowsAsync<ACMException>(() 
                => homeownerSevice.DeleteIdea(idea1.Id, user.Email + "Random string"));
        }
        [Fact]
        public async Task TestDeleteIdeaInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            await context.Users.AddAsync(user);
            await context.Ideas.AddAsync(idea1);
            await context.Ideas.AddAsync(idea2);
            await context.SaveChangesAsync();
            await Assert.ThrowsAsync<ACMException>(() 
                => homeownerSevice.DeleteIdea(idea1.Id + "Random string", user.Email));
        }
        [Fact]
        public async Task TestEditIdeaGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            await context.Users.AddAsync(user);
            await context.Ideas.AddAsync(idea1);
            await context.Ideas.AddAsync(idea2);
            await context.SaveChangesAsync();
            bool output = await homeownerSevice.EditIdea(idea1.Id, user.Email, "Edited text");
            Assert.True(output);
            Assert.Equal("Edited text", context.Ideas
                .Where(x => x.Id == idea1.Id)
                .FirstOrDefault()
                .Text);
        }
        [Fact]
        public async Task TestEditIdeaInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            await context.Users.AddAsync(user);
            await context.Ideas.AddAsync(idea1);
            await context.Ideas.AddAsync(idea2);
            await context.SaveChangesAsync();
            await Assert.ThrowsAsync<ACMException>(() => homeownerSevice
            .EditIdea(idea1.Id, user.Email + "Random string", "Edited text"));
        }
        [Fact]
        public async Task TestEditIdeaInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            await context.Users.AddAsync(user);
            await context.Ideas.AddAsync(idea1);
            await context.Ideas.AddAsync(idea2);
            await context.SaveChangesAsync();
            await Assert.ThrowsAsync<ACMException>(() => homeownerSevice
                .EditIdea(idea1.Id + "Random string", user.Email, "Edited text"));
        }
        [Fact]
        public async Task TestGetIdeaGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            await context.Users.AddAsync(user);
            await context.Ideas.AddAsync(idea1);
            await context.Ideas.AddAsync(idea2);
            await context.SaveChangesAsync();
            EditIdeaDTO output = homeownerSevice.GetIdea(idea1.Id, user.Email);
            Assert.Equal(idea1.Text,output.Text);
            Assert.Equal(idea1.Id,output.Id);
        }
        [Fact]
        public async Task TestGetIdeaInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            await context.Users.AddAsync(user);
            await context.Ideas.AddAsync(idea1);
            await context.Ideas.AddAsync(idea2);
            await context.SaveChangesAsync();
            Action act = () => homeownerSevice
            .GetIdea(idea1.Id, user.Email + "Random string");
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public async Task TestGetIdeaInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            await context.Users.AddAsync(user);
            await context.Ideas.AddAsync(idea1);
            await context.Ideas.AddAsync(idea2);
            await context.SaveChangesAsync();
            Action act = () => homeownerSevice
            .GetIdea(idea1.Id + "Random string", user.Email);
            Assert.Throws<ACMException>(act);
        }
    }
}