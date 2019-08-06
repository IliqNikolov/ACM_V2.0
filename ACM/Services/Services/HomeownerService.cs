using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Data;
using Models;
using Data;
using Utilities;

namespace Services
{
    public class HomeownerSevice : IHomeownerService
    {
        private readonly ACMDbContext context;

        public HomeownerSevice(ACMDbContext context)
        {
            this.context = context;
        }

        public bool AdminDeleteIdea(string id)
        {
            Idea idea = context.Ideas
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (idea == null)
            {
                throw new Utilities.ACMException();
            }
            context.Ideas.Remove(idea);
            context.SaveChanges();
            return true;
        }

        public List<IdeaViewModel> All()
        {
            return context.Ideas.Select(x => new IdeaViewModel(x,x.User.FullName,x.User.Email)).OrderByDescending(x=>x.Date).ToList() ;
        }

        public string Create(string text, string name)
        {
            ACMUser user = context.Users.Where(x => x.Email == name).FirstOrDefault();
            if (user==null)
            {
                throw new ACMException();
            }
            Idea idea = new Idea
            {
                Text = text,
                User = user
            };
            context.Ideas.Add(idea);
            context.SaveChanges();
            return idea.Id;
        }

        public bool DeleteIdea(string id, string userName)
        {
            Idea idea = context.Ideas
                .Where(x => x.Id == id && x.User.Email == userName)
                .FirstOrDefault();
            if (idea == null)
            {
                throw new Utilities.ACMException();
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
                throw new Utilities.ACMException();
            }
            idea.Text = text;
            context.SaveChanges();
            return true;
        }

        public EditIdeaViewModel GetIdea(string id, string userName)
        {
            EditIdeaViewModel idea = context.Ideas
                .Where(x => x.Id == id && x.User.Email == userName)
                .Select(x => new EditIdeaViewModel
                {
                    Id = x.Id,
                    Text = x.Text
                }).FirstOrDefault();
            if (idea==null)
            {
                throw new ACMException();
            }
            return idea;
        }
    }
}
