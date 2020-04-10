using CaseManagement.Models.CaseModels;
using CaseManagement.Models.TaskModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CaseManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Case> Cases { get; set; } = new HashSet<Case>();

        public virtual ICollection<CaseTask> Tasks { get; set; } = new HashSet<CaseTask>();

        public virtual ICollection<CaseModificationLogRecord> ModifiedCases { get; set; } = new HashSet<CaseModificationLogRecord>();

        public virtual ICollection<TaskModificationLogRecord> ModifiedTasks { get; set; } = new HashSet<TaskModificationLogRecord>();
    }
}
