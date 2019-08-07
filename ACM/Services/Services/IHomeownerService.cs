using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IHomeownerService
    {
        string Create(string text, string name);
        List<IdeaDTO> All();
        bool EditIdea(string id, string userName, string text);
        EditIdeaDTO GetIdea(string id, string userName);
        bool DeleteIdea(string id, string userName);
        bool AdminDeleteIdea(string id);
    }
}
