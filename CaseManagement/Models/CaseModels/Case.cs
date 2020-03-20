using CaseManagement.Models.TaskModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models.CaseModels
{
    public class Case
    {
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Subject { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastModified { get; set; }

        public DateTime? EndTime { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int? TypeId { get; set; }

        public virtual CaseType Type { get; set; }

        public int? PhaseId { get; set; }

        public virtual CasePhase Phase { get; set; }

        public int? StatusId { get; set; }

        public virtual CaseStatus Status { get; set; }

        public int? PriorityId { get; set; }

        public virtual CasePriority Priority { get; set; }

        public int? ServiceAreaId { get; set; }

        public virtual ServiceArea ServiceArea { get; set; }

        public int? ServiceId { get; set; }

        public virtual Service Service { get; set; }

        public virtual ICollection<CaseTask> Tasks { get; set; } = new HashSet<CaseTask>();

        public virtual ICollection<CaseModificationLogRecord> CaseModificationLogRecords { get; set; } = new HashSet<CaseModificationLogRecord>();
    }
}
