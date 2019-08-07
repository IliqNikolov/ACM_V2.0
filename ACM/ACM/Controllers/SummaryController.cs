using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACM.Controllers
{
    public class SummaryController : Controller
    {
        private readonly ISummaryService summaryService;

        public SummaryController(ISummaryService summaryService)
        {
            this.summaryService = summaryService;
        }
        [Authorize]
        public IActionResult Financial()
        {
            FinancialSummaryDTO summary = summaryService.FinancialSummary();
            return View(summary);
        }
    }
}
