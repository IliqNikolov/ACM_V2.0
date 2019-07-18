using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACM.Services
{
    public interface IUserService
    {
        string GerateCode(string userName);
        bool IsCodeValid(string code, string userName);
    }
}
