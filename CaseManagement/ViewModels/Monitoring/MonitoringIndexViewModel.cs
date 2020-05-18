using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.Monitoring
{
    public class MonitoringIndexViewModel
    {
        public IEnumerable<InProcessTicketViewModel> InProcessTickets { get; set; }

        public IEnumerable<WaitingTicketViewModel> WaitingTickets { get; set; }
    }
}
