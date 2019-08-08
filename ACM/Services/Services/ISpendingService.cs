using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface ISpendingService
    {
        List<SpendingDTO> GetAllSpendings();
        Task<string> CreateSpending(SpendingDTO model);
        SpendingDTO GetOneSpending(string id);
        Task<bool> EditSpending(SpendingDTO model);
        Task<bool> DeleteSpending(string id);
    }
}
