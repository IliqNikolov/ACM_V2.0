using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Data;
using ACM.Models;

namespace ACM.Services
{
    public class HomeownerSevice : IHomeownerService
    {
        private readonly ACMDbContext context;

        public HomeownerSevice(ACMDbContext context)
        {
            this.context = context;
        }

        public List<IdeaViewModel> All()
        {
            return context.Ideas.Select(x => new IdeaViewModel(x,x.User.FullName,x.User.Email)).OrderByDescending(x=>x.Date).ToList() ;
        }

        public void Create(string text, string name)
        {
            ACMUser user = context.Users.Where(x => x.Email == name).FirstOrDefault();
            context.Ideas.Add(new Idea
            {
                Text = text,
                User = user
            });
            context.SaveChanges();
        }

        public bool DeleteIdea(string id, string userName)
        {
            Idea idea = context.Ideas
                .Where(x => x.Id == id && x.User.Email == userName)
                .FirstOrDefault();
            if (idea == null)
            {
                return false;
            }
            context.Ideas.Remove(idea);
            context.SaveChanges();
            return true;
        }

        public bool EditIdea(string id, string userName, string text)
        {
            Idea idea = context.Ideas
                .Where(x => x.Id == id && x.User.Email == userName)
                .FirstOrDefault();
            if (idea==null)
            {
                return false;
            }
            idea.Text = text;
            context.SaveChanges();
            return true;
        }

        public EditIdeaViewModel GetIdea(string id, string userName)
        {

            return context.Ideas
                .Where(x => x.Id == id && x.User.Email == userName)
                .Select(x=> new EditIdeaViewModel {
                    Id =x.Id,
                    Text=x.Text
            }).FirstOrDefault();
        }
    }
}
