using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Models;

namespace ACM.Services
{
    public interface IHomeownerService
    {
        void Create(string text, string name);
        List<IdeaViewModel> All();
        bool EditIdea(string id, string userName, string text);
        EditIdeaViewModel GetIdea(string id, string userName);
        bool DeleteIdea(string id, string userName);
    }
}
