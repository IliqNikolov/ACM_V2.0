using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Areas.Administration.Models;
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
        public List<CodeViewModel> GetAllCodes()
        {
            return context.RegistrationCodes.Select(x => new CodeViewModel
            {
                ApartmentNumber = x.Apartment.Number,
                Code = x.Code
            }).OrderBy(x => x.ApartmentNumber)
                .ToList();
        }
        public bool DeleteCode(string code)
        {
            RegistrationCode registrationCode = context.RegistrationCodes.Where(x => x.Code == code).FirstOrDefault();
            if (registrationCode == null)
            {
                return false;
            }
            context.RegistrationCodes.Remove(registrationCode);
            context.SaveChanges();
            return true;
        }

        public CodeViewModel CreateARegistrationCode(string id)
        {
            Apartment apartment = context.Apartments
                .Where(x => x.Number == int.Parse(id))
                .FirstOrDefault();
            if (apartment == null)
            {
                return null;
            }
            string code;
            do
            {
                code = apartment.Number + "_" + string.Join("", Guid.NewGuid().ToString().Take(4)).ToUpper();
            } while (context.RegistrationCodes.Any(x => x.Code == code));
            context.RegistrationCodes.Add(new RegistrationCode
            {
                Apartment = apartment,
                Code = code
            });
            context.SaveChanges();
            return new CodeViewModel
            {
                ApartmentNumber = apartment.Number,
                Code = code
            };
        }
    }
}
