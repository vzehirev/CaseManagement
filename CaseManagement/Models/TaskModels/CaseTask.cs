using CaseManagement.Models.CaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models.TaskModels
{
    public class CaseTask
    {
        public int Id { get; set; }

        [Required]
        public string Action { get; set; }

        [Required]
        public string NextAction { get; set; }

        public string Comments { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastModified { get; set; }

        public DateTime? EndTime { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int CaseId { get; set; }

        public virtual Case Case { get; set; }

        public int? TypeId { get; set; }

        public virtual TaskType Type { get; set; }

        public int? StatusId { get; set; }

        public virtual TaskStatus Status { get; set; }

        public virtual ICollection<TaskModificationLogRecord> TaskModificationLogRecords { get; set; } = new HashSet<TaskModificationLogRecord>();
    }
}
