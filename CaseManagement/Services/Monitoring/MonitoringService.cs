using CaseManagement.Data;
using CaseManagement.ViewModels.Monitoring;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.Monitoring
{
    public class MonitoringService : IMonitoringService
    {
        private readonly ApplicationDbContext dbContext;

        public MonitoringService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<InProcessTicketViewModel>> GetInProcessTicketsAsync()
        {
            var inProcessTickets = await this.dbContext.DCMOpsMonitoring
                .Where(x => x.Queue == "DATA CENTER MANAGEMENT OPERATIONS CENTER"
                    && (x.Status == "In Process" || x.Status == "New"))
                .OrderByDescending(x => x.SNo)
                .ToArrayAsync();

            var result = inProcessTickets.GroupBy(x => x.TicketID)
                .Select(x => new InProcessTicketViewModel
                {
                    UploadTimeIST = x.Select(x => x.UploadTimeIST).FirstOrDefault() == null ? ""
                        : x.Select(x => (DateTime)x.UploadTimeIST).First().ToString("dd-MMM-yyyy HH:mm"),
                    TicketId = x.Key,
                    ReportedDate = x.Select(x => x.ReportedDate).FirstOrDefault() == null ? ""
                        : x.Select(x => (DateTime)x.ReportedDate).First().ToString("dd-MMM-yyyy HH:mm"),
                    Priority = x.Select(x => x.Priority).FirstOrDefault().Trim(),
                    Status = x.Select(x => x.Status).FirstOrDefault().Trim(),
                    WaitingReason = x.Select(x => x.WaitingReason).FirstOrDefault().Trim(),
                    Subject = x.Select(x => x.Subject).FirstOrDefault().Trim(),
                    Assigned = x.Select(x => x.Assigned).FirstOrDefault().Trim(),
                    ChangedBy = x.Select(x => x.Changedby).FirstOrDefault().Trim(),
                    ResumeAt = x.Select(x => x.Resumeat).FirstOrDefault() == null ? ""
                        : x.Select(x => (DateTime)x.Resumeat).First().ToString("dd-MMM-yyyy HH:mm"),
                    Notes = x.Select(x => x.Notes).FirstOrDefault().Trim(),
                })
                .OrderBy(x => x.UploadTimeIST)
                .ThenBy(x => x.Priority)
                .ToArray();

            return result;
        }

        public async Task<IEnumerable<WaitingTicketViewModel>> GetWaitingTicketsAsync()
        {
            var waitingTickets = await this.dbContext.DCMOpsMonitoring
                .Where(x => x.Queue == "DATA CENTER MANAGEMENT OPERATIONS CENTER"
                    && x.Status == "Waiting")
                .OrderByDescending(x => x.SNo)
                .ToArrayAsync();

            var result = waitingTickets.GroupBy(x => x.TicketID)
                .Select(x => new WaitingTicketViewModel
                {
                    UploadTimeIST = x.Select(x => x.UploadTimeIST).FirstOrDefault() == null ? ""
                        : x.Select(x => (DateTime)x.UploadTimeIST).First().ToString("dd-MMM-yyyy HH:mm"),
                    HoldHours = x.Select(x => x.HoldHours).FirstOrDefault(),
                    TicketId = x.Key,
                    ReportedDate = x.Select(x => x.ReportedDate).FirstOrDefault() == null ? ""
                        : x.Select(x => (DateTime)x.ReportedDate).First().ToString("dd-MMM-yyyy HH:mm"),
                    Priority = x.Select(x => x.Priority).FirstOrDefault().Trim(),
                    Status = x.Select(x => x.Status).FirstOrDefault().Trim(),
                    WaitingReason = x.Select(x => x.WaitingReason).FirstOrDefault().Trim(),
                    Subject = x.Select(x => x.Subject).FirstOrDefault().Trim(),
                    Assigned = x.Select(x => x.Assigned).FirstOrDefault().Trim(),
                    ChangedBy = x.Select(x => x.Changedby).FirstOrDefault().Trim(),
                    ResumeAt = x.Select(x => x.Resumeat).FirstOrDefault() == null ? ""
                        : x.Select(x => (DateTime)x.Resumeat).First().ToString("dd-MMM-yyyy HH:mm"),
                    Notes = x.Select(x => x.Notes).FirstOrDefault().Trim(),
                })
                .OrderBy(x => x.Priority)
                .ToArray();

            return result;
        }
    }
}
