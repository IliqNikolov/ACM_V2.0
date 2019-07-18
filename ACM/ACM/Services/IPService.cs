using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Data;

namespace ACM.Services
{
    public class IPService : IIPService
    {
        private readonly ACMDbContext context;

        public IPService(ACMDbContext context)
        {
            this.context = context;
        }
        public void Create(ACMUser user, string ipStr)
        {
            context.IPs.Add(new IP { User = user, IpString = ipStr });
            context.SaveChanges();
        }
    }
}
