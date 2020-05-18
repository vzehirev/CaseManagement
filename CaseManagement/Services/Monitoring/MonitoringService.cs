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
            var result = await this.dbContext.DCMOpsMonitoring
                .Where(x => x.Queue == "DATA CENTER MANAGEMENT OPERATIONS CENTER"
                    && (x.Status == "In Process" || x.Status == "New"))
                .OrderByDescending(x => x.UpdatedDate)
                .Select(x => new InProcessTicketViewModel
                {
                    UploadTimeIST = x.UploadTimeIST,
                    TicketId = x.TicketID,
                    ReportedDate = x.ReportedDate,
                    Priority = x.Priority.Trim(),
                    Status = x.Status.Trim(),
                    WaitingReason = x.WaitingReason.Trim(),
                    Subject = x.Subject.Trim(),
                    Assigned = x.Assigned.Trim(),
                    ChangedBy = x.Changedby.Trim(),
                    ResumeAt = x.Resumeat,
                    Notes = x.Notes.Trim(),
                })
                .ToArrayAsync();

            result = result.GroupBy(x => x.TicketId)
                .Select(x => new InProcessTicketViewModel
                {
                    UploadTimeIST = x.Select(x => x.UploadTimeIST).FirstOrDefault(),
                    TicketId = x.Key,
                    ReportedDate = x.Select(x => x.ReportedDate).FirstOrDefault(),
                    Priority = x.Select(x => x.Priority).FirstOrDefault(),
                    Status = x.Select(x => x.Status).FirstOrDefault(),
                    WaitingReason = x.Select(x => x.WaitingReason).FirstOrDefault(),
                    Subject = x.Select(x => x.Subject).FirstOrDefault(),
                    Assigned = x.Select(x => x.Assigned).FirstOrDefault(),
                    ChangedBy = x.Select(x => x.ChangedBy).FirstOrDefault(),
                    ResumeAt = x.Select(x => x.ResumeAt).FirstOrDefault(),
                    Notes = x.Select(x => x.Notes).FirstOrDefault(),
                })
                .OrderBy(x => x.UploadTimeIST)
                .ThenBy(x => x.Priority)
                .ToArray();

            return result;
        }

        public async Task<IEnumerable<WaitingTicketViewModel>> GetWaitingTicketsAsync()
        {
            var result = await this.dbContext.DCMOpsMonitoring
                .Where(x => x.Queue == "DATA CENTER MANAGEMENT OPERATIONS CENTER"
                    && x.Status == "Waiting")
                .OrderByDescending(x => x.UpdatedDate)
                .Select(x => new WaitingTicketViewModel
                {
                    UploadTimeIST = x.UploadTimeIST,
                    HoldHours = x.HoldHours,
                    TicketId = x.TicketID,
                    ReportedDate = x.ReportedDate,
                    Priority = x.Priority.Trim(),
                    Status = x.Status.Trim(),
                    WaitingReason = x.WaitingReason.Trim(),
                    Subject = x.Subject.Trim(),
                    Assigned = x.Assigned.Trim(),
                    ChangedBy = x.Changedby.Trim(),
                    ResumeAt = x.Resumeat,
                    Notes = x.Notes.Trim(),
                })
                .ToArrayAsync();

            result = result.GroupBy(x => x.TicketId)
                .Select(x => new WaitingTicketViewModel
                {
                    UploadTimeIST = x.Select(x => x.UploadTimeIST).FirstOrDefault(),
                    HoldHours = x.Select(x => x.HoldHours).FirstOrDefault(),
                    TicketId = x.Key,
                    ReportedDate = x.Select(x => x.ReportedDate).FirstOrDefault(),
                    Priority = x.Select(x => x.Priority).FirstOrDefault(),
                    Status = x.Select(x => x.Status).FirstOrDefault(),
                    WaitingReason = x.Select(x => x.WaitingReason).FirstOrDefault(),
                    Subject = x.Select(x => x.Subject).FirstOrDefault(),
                    Assigned = x.Select(x => x.Assigned).FirstOrDefault(),
                    ChangedBy = x.Select(x => x.ChangedBy).FirstOrDefault(),
                    ResumeAt = x.Select(x => x.ResumeAt).FirstOrDefault(),
                    Notes = x.Select(x => x.Notes).FirstOrDefault(),
                })
                .OrderBy(x => x.Priority)
                .ToArray();

            return result;
        }
    }
}
