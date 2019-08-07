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
        string CreateSpending(SpendingDTO model);
        SpendingDTO GetOneSpending(string id);
        bool EditSpending(SpendingDTO model);
        bool DeleteSpending(string id);
    }
}
