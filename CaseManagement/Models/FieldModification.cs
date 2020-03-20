using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models
{
    public class FieldModification
    {
        public int Id { get; set; }

        [Required]
        public string FieldName { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }
    }
}
