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
