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
    public class MonitoringWaitingTicketsController : ControllerBase
    {
        private readonly IMonitoringService monitoringService;

        public MonitoringWaitingTicketsController(IMonitoringService monitoringService)
        {
            this.monitoringService = monitoringService;
        }

        public async Task<IActionResult> GetAllWaitingTickets()
        {
            var result = await this.monitoringService.GetWaitingTicketsAsync();

            return new JsonResult(result);
        }
    }
}