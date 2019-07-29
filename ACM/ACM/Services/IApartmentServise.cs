using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Areas.Administration.Models;
using ACM.Models;

namespace ACM.Services
{
    public interface IApartmentServise
    {
        List<ApartmentListElementViewModel> GetAppartments();
        bool Create(int number);
        List<ApartmentListViewModel> GetAllApartments();
        CodeViewModel CreateARegistrationCode(string id);
        List<CodeViewModel> GetAllCodes();
        bool DeleteCode(string code);

    }
}
