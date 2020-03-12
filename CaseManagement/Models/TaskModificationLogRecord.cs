using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Models
{
    public class TaskModificationLogRecord
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int TaskId { get; set; }

        [Required]
        public DateTime ModificationTime { get; set; }

        public ICollection<FieldModification> ModifiedFields { get; set; } = new HashSet<FieldModification>();
    }
}
