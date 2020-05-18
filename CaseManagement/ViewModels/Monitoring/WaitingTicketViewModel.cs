using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.Monitoring
{
    public class WaitingTicketViewModel
    {
        public DateTime? UploadTimeIST { get; set; }

        public int HoldHours { get; set; }

        public double? TicketId { get; set; }

        public DateTime? ReportedDate { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public string WaitingReason { get; set; }

        public string Subject { get; set; }

        public string Assigned { get; set; }

        public string ChangedBy { get; set; }

        public DateTime? ResumeAt { get; set; }

        public string Notes { get; set; }
    }
}
