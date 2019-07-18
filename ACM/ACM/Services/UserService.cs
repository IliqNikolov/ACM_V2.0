using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Data;

namespace ACM.Services
{
    public class UserService : IUserService
    {
        private readonly ACMDbContext context;

        public UserService(ACMDbContext context)
        {
            this.context = context;
        }
        public string GerateCode(string userName)
        {
            string code =string.Join("", Guid.NewGuid().ToString().Take(4)).ToUpper();
            context.Users
                .Where(x => x.UserName == userName)
                .FirstOrDefault()
                .ExpectedCode = code;
            context.SaveChanges();
            return code;
        }

        public bool IsCodeValid(string code, string userName)
        {
            return context.Users.Any(x => x.UserName == userName && x.ExpectedCode == code);
        }
    }
}
