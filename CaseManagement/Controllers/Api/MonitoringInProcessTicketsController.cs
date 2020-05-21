using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagement.Services.Monitoring;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagement.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitoringInProcessTicketsController : ControllerBase
    {
        private readonly IMonitoringService monitoringService;

        public MonitoringInProcessTicketsController(IMonitoringService monitoringService)
        {
            this.monitoringService = monitoringService;
        }

        public async Task<IActionResult> GetAllInProcessTickets()
        {
            var result = await this.monitoringService.GetInProcessTicketsAsync();

            return new JsonResult(result);
        }
    }
}