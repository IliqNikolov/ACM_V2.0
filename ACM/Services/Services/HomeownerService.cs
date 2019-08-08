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

        public async Task<bool> AdminDeleteIdea(string id)
        {
            Idea idea = context.Ideas
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (idea == null)
            {
                throw new Utilities.ACMException();
            }
            context.Ideas.Remove(idea);
            await context.SaveChangesAsync();
            return true;
        }

        public List<IdeaDTO> All()
        {
            return context.Ideas
                .Select(x => new IdeaDTO(x,x.User.FullName,x.User.Email))
                .OrderByDescending(x=>x.Date)
                .ToList() ;
        }

        public async Task<string> Create(string text, string name)
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
            await context.Ideas.AddAsync(idea);
            await context.SaveChangesAsync();
            return idea.Id;
        }

        public async Task<bool> DeleteIdea(string id, string userName)
        {
            Idea idea = context.Ideas
                .Where(x => x.Id == id && x.User.Email == userName)
                .FirstOrDefault();
            if (idea == null)
            {
                throw new Utilities.ACMException();
            }
            context.Ideas.Remove(idea);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditIdea(string id, string userName, string text)
        {
            Idea idea = context.Ideas
                .Where(x => x.Id == id && x.User.Email == userName)
                .FirstOrDefault();
            if (idea==null)
            {
                throw new Utilities.ACMException();
            }
            idea.Text = text;
            await context.SaveChangesAsync();
            return true;
        }

        public EditIdeaDTO GetIdea(string id, string userName)
        {
            EditIdeaDTO idea = context.Ideas
                .Where(x => x.Id == id && x.User.Email == userName)
                .Select(x => new EditIdeaDTO
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
