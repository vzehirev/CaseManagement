using CaseManagement.Services.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CaseManagement.Controllers
{
    [Authorize(Roles = "Lead")]
    public class ReportsController : Controller
    {
        private readonly IReportsService reportsService;

        public ReportsController(IReportsService reportsService)
        {
            this.reportsService = reportsService;
        }

        [Route("/Reports")]
        [Route("/Reports/RegisteredAgents")]
        public async Task<IActionResult> RegisteredAgents()
        {
            ViewModels.Agents.AllAgentsOutputModel outputModel = await reportsService.GetAllAgentsAsync();

            return View(outputModel);
        }
    }
}