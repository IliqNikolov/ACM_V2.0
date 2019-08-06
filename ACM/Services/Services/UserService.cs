using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Models;
using Utilities;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly ACMDbContext context;

        public UserService(ACMDbContext context)
        {
            this.context = context;
        }
        public string GenerateCode(string userName)
        {
            string code =string.Join("", Guid.NewGuid().ToString().Take(4)).ToUpper();
            ACMUser user = context.Users
                .Where(x => x.UserName == userName)
                .FirstOrDefault();
            if (user==null)
            {
                throw new ACMException();
            }
                user.ExpectedCode = code;
            context.SaveChanges();
            return code;
        }

        public int GetApartmentNumber(string name)
        {
            ACMUser user = context.Users
                .Where(x => x.Email == name)
                .FirstOrDefault();
            if (user==null)
            {
                throw new ACMException();
            }
            return user.AppartentNumber;
        }

        public bool IsCodeValid(string code, string userName)
        {
            return context.Users.Any(x => x.UserName == userName && x.ExpectedCode == code);
        }
    }
}
