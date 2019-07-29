using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Areas.Administration.Models;
using ACM.Data;
using ACM.Models;

namespace ACM.Services
{
    public class ApartmentService : IApartmentServise
    {
        private readonly ACMDbContext context;

        public ApartmentService(ACMDbContext context)
        {
            this.context = context;
        }

        public bool Create(int number)
        {
            if (context.Apartments.Any(x=>x.Number==number))
            {
                return false;
            }
            context.Apartments
                .Add(new Apartment { Number = number });
            context.SaveChanges();
            return true;
        }

        public CodeViewModel CreateARegistrationCode(string id)
        {
            Apartment apartment = context.Apartments
                .Where(x => x.Id == id)
                .FirstOrDefault();
            if (apartment==null)
            {
                return null;
            }
            string code;
            do
            {
                code=apartment.Number+"_"+ string.Join("", Guid.NewGuid().ToString().Take(4)).ToUpper();
            } while (context.RegistrationCodes.Any(x=>x.Code==code));
            context.RegistrationCodes.Add(new RegistrationCode
            {
                Apartment = apartment,
                Code = code
            });
            context.SaveChanges();
            return new CodeViewModel
            {
                ApartmentNumber=apartment.Number,
                Code=code
            };
        }

        public bool DeleteCode(string code)
        {
            RegistrationCode  registrationCode = context.RegistrationCodes.Where(x => x.Code == code).FirstOrDefault();
            if (registrationCode==null)
            {
                return false;
            }
            context.RegistrationCodes.Remove(registrationCode);
            context.SaveChanges();
            return true;
        }

        public List<ApartmentListViewModel> GetAllApartments()
        {
            return context.Apartments
                .Select(x => new ApartmentListViewModel
            {
                Number = x.Number,
                Id=x.Id,
                RegisteredUsersCount = context.Users
                .Where(y => y.AppartentNumber == x.Number)
                .Count()
            }).OrderBy(x=>x.Number)
            .ToList();
        }

        public List<CodeViewModel> GetAllCodes()
        {
            return context.RegistrationCodes.Select(x => new CodeViewModel
            {
                ApartmentNumber = x.Apartment.Number,
                Code = x.Code
            }).OrderBy(x=>x.ApartmentNumber)
                .ToList();
        }

        public List<ApartmentListElementViewModel> GetAppartments()
        {
            return context.Apartments
                .Select(x => new ApartmentListElementViewModel
            {
                Id = x.Id,
                Number = x.Number.ToString()
            })
                .ToList();
        }
    }
}
