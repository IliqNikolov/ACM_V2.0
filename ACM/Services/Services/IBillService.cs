using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IBillService
    {
        List<BillsViewModel> GetAllBills();
        string BillOneApartment(string id, string text, decimal amount);
        void BillAllApartments(string text, decimal amount);
        BillsViewModel GetOneBill(string id);
        bool EditBill(BillsViewModel model);
        bool DeleteBill(string id);
        bool PayBill(string id);
        List<WallOfShameElementViewModel> GetWallOfShameList();
    }
}
