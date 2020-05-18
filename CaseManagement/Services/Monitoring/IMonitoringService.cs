using CaseManagement.ViewModels.Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.Monitoring
{
    public interface IMonitoringService
    {
        Task<IEnumerable<InProcessTicketViewModel>> GetInProcessTicketsAsync();

        Task<IEnumerable<WaitingTicketViewModel>> GetWaitingTicketsAsync();
    }
}
