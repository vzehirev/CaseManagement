using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Models
{
    public class FieldModification
    {
        public int Id { get; set; }

        [Required]
        public string FieldName { get; set; }

        [Required]
        public string OldValue { get; set; }

        [Required]
        public string NewValue { get; set; }
    }
}
