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
        Task<string> BillOneApartment(string id, string text, decimal amount);
        Task BillAllApartments(string text, decimal amount);
        BillsDTO GetOneBill(string id);
        Task<bool> EditBill(BillsDTO model);
        Task<bool> DeleteBill(string id);
        Task<bool> PayBill(string id);
        List<WallOfShameElementViewModel> GetWallOfShameList();
    }
}
