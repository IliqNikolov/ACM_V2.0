using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Models;
using Utilities;

namespace Services
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

        public List<CodeDTO> GetAllCodes()
        {
            return context.RegistrationCodes.Select(x => new CodeDTO
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
                throw new Utilities.ACMException();
            }
            context.RegistrationCodes.Remove(registrationCode);
            context.SaveChanges();
            return true;
        }

        public CodeDTO CreateARegistrationCode(string id)
        {
            Apartment apartment = context.Apartments
                .Where(x => x.Number == int.Parse(id))
                .FirstOrDefault();
            if (apartment == null)
            {
                throw new Utilities.ACMException();
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
            return new CodeDTO
            {
                ApartmentNumber = apartment.Number,
                Code = code
            };
        }
    }
}
