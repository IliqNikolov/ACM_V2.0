using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;

namespace Models
{
    public class IpViewModel
    {
        public IpViewModel(ACMUser user, string ip)
        {
            User = user;
            Ip = ip;
        }

        public ACMUser User { get; set; }

        public string Ip { get; set; }
    }
}
