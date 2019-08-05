using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Data;
using Models;
using Data;

namespace Services
{
    public class ApartmentService : IApartmentServise
    {
        private readonly ACMDbContext context;

        public ApartmentService(ACMDbContext context)
        {
            this.context = context;
        }

        public string Create(int number)
        {
            if (context.Apartments.Any(x=>x.Number==number))
            {
                return null;
            }
            Apartment apartment = new Apartment { Number = number };
            context.Apartments
                .Add(apartment);
            context.SaveChanges();
            return apartment.Id;
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


        public List<ApartmentListElementViewModel> GetAppartments()
        {
            return context.Apartments
                .Select(x => new ApartmentListElementViewModel
            {
                Id = x.Number.ToString(),
                Number = x.Number.ToString()
            })
                .ToList();
        }
    }
}
