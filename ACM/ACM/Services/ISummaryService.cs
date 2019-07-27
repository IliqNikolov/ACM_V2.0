using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACM.Models;

namespace ACM.Services
{
    public interface ISummaryService
    {
        FinancialSummaryViewModel FinancialSummary();
    }
}
