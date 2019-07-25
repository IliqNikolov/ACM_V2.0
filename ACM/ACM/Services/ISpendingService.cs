using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Models;

namespace ACM.Services
{
    public interface ISpendingService
    {
        List<SpendingViewModel> GetAllSpendings();
        void CreateSpending(SpendingViewModel model);
        SpendingViewModel GetOneSpending(string id);
        bool EditSpending(SpendingViewModel model);
        bool DeleteSpending(string id);
    }
}
