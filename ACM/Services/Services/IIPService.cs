using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IIPService
    {
        string Create(IpViewModel ipViewModel);
        bool IsNewIp(string name,string ip);

        void AddNewIp(string name, string ip);
    }
}
