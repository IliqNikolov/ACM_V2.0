using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Data;

namespace ACM.Services
{
    public class CodeService : ICodeService
    {
        private readonly ACMDbContext context;

        public CodeService(ACMDbContext context)
        {
            this.context = context;
        }

        public bool IsCodeValid(string code)
        {
            return context.RegistrationCodes.Any(x => x.Code == code);
        }

        public void RemoveCode(string code)
        {
            RegistrationCode codeToRemove = context.RegistrationCodes.Where(x => x.Code == code).FirstOrDefault();

            context.RegistrationCodes.Remove(codeToRemove);

            context.SaveChanges();
        }
    }
}
