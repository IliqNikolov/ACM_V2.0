using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACM.Services
{
    public interface IIPService
    {
        void Create(ACMUser user, string ip);
    }
}
