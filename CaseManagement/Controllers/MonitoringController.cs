using CaseManagement.Services.Monitoring;
using CaseManagement.ViewModels.Monitoring;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CaseManagement.Controllers
{
    public class MonitoringController : Controller
    {
        private readonly IMonitoringService monitoringService;

        public MonitoringController(IMonitoringService monitoringService)
        {
            this.monitoringService = monitoringService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new MonitoringIndexViewModel();
            viewModel.InProcessTickets = await this.monitoringService.GetInProcessTicketsAsync();
            viewModel.WaitingTickets = await this.monitoringService.GetWaitingTicketsAsync();
            return View(viewModel);
        }
    }
}