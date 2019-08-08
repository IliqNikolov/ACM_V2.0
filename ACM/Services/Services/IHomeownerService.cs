using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IHomeownerService
    {
        Task<string> Create(string text, string name);
        List<IdeaDTO> All();
        Task<bool> EditIdea(string id, string userName, string text);
        EditIdeaDTO GetIdea(string id, string userName);
        Task<bool> DeleteIdea(string id, string userName);
        Task<bool> AdminDeleteIdea(string id);
    }
}
