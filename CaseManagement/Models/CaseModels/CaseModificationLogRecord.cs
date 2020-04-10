using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models.CaseModels
{
    public class CaseModificationLogRecord
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int CaseId { get; set; }

        public virtual Case Case { get; set; }

        [Required]
        public DateTime ModificationTime { get; set; }

        public virtual ICollection<FieldModification> ModifiedFields { get; set; } = new HashSet<FieldModification>();
    }
}
