using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models.TaskModels
{
    public class TaskModificationLogRecord
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public CaseTask Task { get; set; }

        public int TaskId { get; set; }

        [Required]
        public DateTime ModificationTime { get; set; }

        public virtual ICollection<FieldModification> ModifiedFields { get; set; } = new HashSet<FieldModification>();
    }
}
