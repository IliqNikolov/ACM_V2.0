using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
