﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Data;
using ACM.Models;

namespace ACM.Services
{
    public class IPService : IIPService
    {
        private readonly ACMDbContext context;

        public IPService(ACMDbContext context)
        {
            this.context = context;
        }

        public void AddNewIp(string name, string ip)
        {
            context.IPs.Add(new IP { User = context.Users.Where(x => x.UserName == name).FirstOrDefault(), IpString = ip });
            context.SaveChanges();
        }

        public void Create(IpViewModel ipViewModel)
        {
            context.IPs.Add(new IP { User = ipViewModel.User, IpString = ipViewModel.Ip});
            context.SaveChanges();
        }

        public bool IsNewIp(string name,string ip)
        {
            return !context.IPs.Any(x => x.User.UserName ==name && x.IpString == ip);
        }
    }
}
