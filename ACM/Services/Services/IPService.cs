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

        public async Task<string> AddNewIp(string name, string ip)
        {
            ACMUser user = context.Users.Where(x => x.UserName == name).FirstOrDefault();
            if (user==null)
            {
                throw new ACMException();
            }
            IP newIp = new IP { User = user, IpString = ip };
            await context.IPs.AddAsync(newIp);
            await context.SaveChangesAsync();
            return newIp.Id;
        }

        public async Task<string> Create(IpDTO ipViewModel)
        {
            if (ipViewModel.User==null)
            {
                throw new ACMException();
            }
            IP iP = new IP { User = ipViewModel.User, IpString = ipViewModel.Ip };
            await context.IPs.AddAsync(iP);
            await context.SaveChangesAsync();
            return iP.Id;
        }

        public bool IsNewIp(string name,string ip)
        {
            return !context.IPs.Any(x => x.User.UserName ==name && x.IpString == ip);
        }
    }
}
