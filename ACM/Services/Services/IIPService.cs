using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IIPService
    {
        Task<string> Create(IpDTO ipViewModel);
        bool IsNewIp(string name,string ip);
        Task<string> AddNewIp(string name, string ip);
    }
}
