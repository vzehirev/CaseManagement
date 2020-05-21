using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Models.DCMOpsMonitoringTable
{
    public class DCMOpsMonitoringRow
    {
        [Key, Required]
        public int SNo { get; set; }

        public double? TicketID { get; set; }

        public DateTime? ReportedDate { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public string Qstatus { get; set; }

        public string WaitingReason { get; set; }

        public string Subject { get; set; }

        public string Notes { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public string TicketType { get; set; }

        public string Queue { get; set; }

        public string Assigned { get; set; }

        public DateTime? Resumeat { get; set; }

        public int? TTESFlag { get; set; }

        public int? RTPUFlag { get; set; }

        public string Changedby { get; set; }

        public DateTime? UploadTimeIST { get; set; }

        [NotMapped]
        public int HoldHours
        {
            get
            {
                    return (int)Math.Ceiling(((TimeSpan)(Resumeat - UpdatedDate)).TotalHours);
            }
        }

        [NotMapped]
        public int StatusDuration
        {
            get
            {
                var nowInIST = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                return ((TimeSpan)(nowInIST - UploadTimeIST)).Minutes;
            }
        }
    }
}
