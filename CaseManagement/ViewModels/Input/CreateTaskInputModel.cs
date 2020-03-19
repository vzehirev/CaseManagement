using CaseManagement.Models.CaseModels;
using CaseManagement.Models.TaskModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.ViewModels.Input
{
    public class CreateTaskInputModel
    {
        public int? TypeId { get; set; }

        public int? StatusId { get; set; }

        [Required]
        public string Action { get; set; }

        [Required]
        [Display(Name = "Next action")]
        public string NextAction { get; set; }

        public string Comments { get; set; }

        public IEnumerable<TaskType> TaskTypes { get; set; }

        public IEnumerable<TaskStatus> TaskStatuses { get; set; }

        public int CaseId { get; set; }
    }
}
