using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Models;

namespace Services
{
    public interface IUserService
    {
        string GenerateCode(string userName);
        bool IsCodeValid(string code, string userName);
        int GetApartmentNumber(string name);
        bool IsUserValid(string email);
        ACMUser GetOneUser(string email);
    }
}
