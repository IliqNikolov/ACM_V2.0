using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Models;
using Utilities;

namespace Services
{
    public class IPService : IIPService
    {
        private readonly ACMDbContext context;

        public IPService(ACMDbContext context)
        {
            this.context = context;
        }

        public string AddNewIp(string name, string ip)
        {
            ACMUser user = context.Users.Where(x => x.UserName == name).FirstOrDefault();
            if (user==null)
            {
                throw new ACMException();
            }
            IP newIp = new IP { User = user, IpString = ip };
            context.IPs.Add(newIp);
            context.SaveChanges();
            return newIp.Id;
        }

        public string Create(IpDTO ipViewModel)
        {
            if (ipViewModel.User==null)
            {
                throw new ACMException();
            }
            IP iP = new IP { User = ipViewModel.User, IpString = ipViewModel.Ip };
            context.IPs.Add(iP);
            context.SaveChanges();
            return iP.Id;
        }

        public bool IsNewIp(string name,string ip)
        {
            return !context.IPs.Any(x => x.User.UserName ==name && x.IpString == ip);
        }
    }
}
