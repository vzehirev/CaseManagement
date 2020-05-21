using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.Monitoring
{
    public class WaitingTicketViewModel
    {
        public string UploadTimeIST { get; set; }

        public int HoldHours { get; set; }

        public double? TicketId { get; set; }

        public string ReportedDate { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public string WaitingReason { get; set; }

        public string Subject { get; set; }

        public string Assigned { get; set; }

        public string ChangedBy { get; set; }

        public string ResumeAt { get; set; }

        public string Notes { get; set; }
    }
}
