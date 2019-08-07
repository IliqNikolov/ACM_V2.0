using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IBillService
    {
        List<BillsDTO> GetAllBills();
        string BillOneApartment(string id, string text, decimal amount);
        void BillAllApartments(string text, decimal amount);
        BillsDTO GetOneBill(string id);
        bool EditBill(BillsDTO model);
        bool DeleteBill(string id);
        bool PayBill(string id);
        List<WallOfShameElementViewModel> GetWallOfShameList();
    }
}
