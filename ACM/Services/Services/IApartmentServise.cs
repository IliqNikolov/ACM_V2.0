using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IApartmentServise
    {
        List<ApartmentListElementViewModel> GetAppartments();
        string Create(int number);
        List<ApartmentListViewModel> GetAllApartments();


    }
}
