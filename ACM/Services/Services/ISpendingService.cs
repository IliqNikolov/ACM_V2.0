using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface ISpendingService
    {
        List<SpendingViewModel> GetAllSpendings();
        string CreateSpending(SpendingViewModel model);
        SpendingViewModel GetOneSpending(string id);
        bool EditSpending(SpendingViewModel model);
        bool DeleteSpending(string id);
    }
}
