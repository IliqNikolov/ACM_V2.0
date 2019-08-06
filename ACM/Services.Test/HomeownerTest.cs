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
    public class HomeownerTest
    {
        [Fact]
        public void TestAdminDeleteIdeaGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            Idea idea = new Idea { Id = "1" };
            context.Add(idea);
            context.SaveChanges();
            bool output = homeownerSevice.AdminDeleteIdea("1");
            Assert.True(output);
            Assert.Empty(context.Ideas.ToList());
        }
        [Fact]
        public void TestAdminDeleteIdeaInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            Idea idea = new Idea { Id = "1" };
            context.Add(idea);
            context.SaveChanges();
            Action act = () => homeownerSevice.AdminDeleteIdea("2");
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestAllGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            context.Users.Add(user);
            context.Ideas.Add(idea1);
            context.Ideas.Add(idea2);
            context.SaveChanges();
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
        public void TestCreateGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg" };
            context.Users.Add(user);
            context.SaveChanges();
            string id = homeownerSevice.Create("beer", "gosho@abv.bg");
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
        public void TestCreateInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg" };
            context.Users.Add(user);
            context.SaveChanges();
            Action act = () => homeownerSevice.Create("beer", "NOT gosho@abv.bg");
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestDeleteIdeaGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            context.Users.Add(user);
            context.Ideas.Add(idea1);
            context.Ideas.Add(idea2);
            context.SaveChanges();
            bool output = homeownerSevice.DeleteIdea(idea1.Id, user.Email);
            Assert.True(output);
            Assert.Single(context.Ideas.ToList());
            Assert.True(context.Ideas.Any(x => x.Id == idea2.Id));
        }
        [Fact]
        public void TestDeleteIdeaInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            context.Users.Add(user);
            context.Ideas.Add(idea1);
            context.Ideas.Add(idea2);
            context.SaveChanges();
            Action act = () => homeownerSevice.DeleteIdea(idea1.Id, user.Email+"Random string");
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestDeleteIdeaInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            context.Users.Add(user);
            context.Ideas.Add(idea1);
            context.Ideas.Add(idea2);
            context.SaveChanges();
            Action act = () => homeownerSevice.DeleteIdea(idea1.Id + "Random string", user.Email);
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestEditIdeaGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            context.Users.Add(user);
            context.Ideas.Add(idea1);
            context.Ideas.Add(idea2);
            context.SaveChanges();
            bool output = homeownerSevice.EditIdea(idea1.Id, user.Email, "Edited text");
            Assert.True(output);
            Assert.Equal("Edited text", context.Ideas
                .Where(x => x.Id == idea1.Id)
                .FirstOrDefault()
                .Text);
        }
        [Fact]
        public void TestEditIdeaInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            context.Users.Add(user);
            context.Ideas.Add(idea1);
            context.Ideas.Add(idea2);
            context.SaveChanges();
            Action act = () => homeownerSevice
            .EditIdea(idea1.Id, user.Email+"Random string", "Edited text");
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestEditIdeaInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            context.Users.Add(user);
            context.Ideas.Add(idea1);
            context.Ideas.Add(idea2);
            context.SaveChanges();
            Action act = () => homeownerSevice
            .EditIdea(idea1.Id + "Random string", user.Email, "Edited text");
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestGetIdeaGoodData()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            context.Users.Add(user);
            context.Ideas.Add(idea1);
            context.Ideas.Add(idea2);
            context.SaveChanges();
            EditIdeaViewModel output = homeownerSevice.GetIdea(idea1.Id, user.Email);
            Assert.Equal(idea1.Text,output.Text);
            Assert.Equal(idea1.Id,output.Id);
        }
        [Fact]
        public void TestGetIdeaInvalidUser()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            context.Users.Add(user);
            context.Ideas.Add(idea1);
            context.Ideas.Add(idea2);
            context.SaveChanges();
            Action act = () => homeownerSevice.GetIdea(idea1.Id, user.Email + "Random string");
            Assert.Throws<ACMException>(act);
        }
        [Fact]
        public void TestGetIdeaInvalidId()
        {
            ACMDbContext context = ACMDbContextInMemoryFactory.InitializeContext();
            HomeownerSevice homeownerSevice = new HomeownerSevice(context);
            ACMUser user = new ACMUser { Email = "gosho@abv.bg", FullName = "gosho" };
            Idea idea1 = new Idea { Id = "1", User = user, Text = "idea1" };
            Idea idea2 = new Idea { Id = "2", User = user, Text = "idea2" };
            context.Users.Add(user);
            context.Ideas.Add(idea1);
            context.Ideas.Add(idea2);
            context.SaveChanges();
            Action act = () => homeownerSevice.GetIdea(idea1.Id + "Random string", user.Email);
            Assert.Throws<ACMException>(act);
        }
    }
}