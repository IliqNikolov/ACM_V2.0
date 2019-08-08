using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Data;
using Models;
using Data;
using Utilities;

namespace Services
{
    public class ApartmentService : IApartmentServise
    {
        private readonly ACMDbContext context;

        public ApartmentService(ACMDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Create(int number)
        {
            if (context.Apartments.Any(x=>x.Number==number))
            {
                throw new ACMException();
            }
            Apartment apartment = new Apartment { Number = number };
            await context.Apartments
                .AddAsync(apartment);
            await context.SaveChangesAsync();
            return apartment.Id;
        }

        public List<ApartmentListDTO> GetAllApartments()
        {
            return context.Apartments
                .Select(x => new ApartmentListDTO
            {
                Number = x.Number,
                Id=x.Id,
                RegisteredUsersCount = context.Users
                .Where(y => y.AppartentNumber == x.Number)
                .Count()
            }).OrderBy(x=>x.Number)
            .ToList();
        }


        public List<ApartmentListElementDTO> GetAppartments()
        {
            return context.Apartments
                .Select(x => new ApartmentListElementDTO
            {
                Id = x.Number.ToString(),
                Number = x.Number.ToString()
            })
                .ToList();
        }
    }
}
