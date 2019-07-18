using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Models;

namespace ACM.Services
{
    public interface IIPService
    {
        void Create(IpViewModel ipViewModel);
        bool IsNewIp(string name,string ip);

        void AddNewIp(string name, string ip);
    }
}
