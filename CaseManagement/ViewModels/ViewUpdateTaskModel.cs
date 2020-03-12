using CaseManagement.Models.TaskModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.ViewModels
{
    public class ViewUpdateTaskModel
    {
        public int Id { get; set; }

        [Required]
        public string Action { get; set; }

        [Required]
        [Display(Name = "Task Next action")]
        public string NextAction { get; set; }

        public int? StatusId { get; set; }

        public int? TypeId { get; set; }

        [Required]
        public string Comments { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<TaskType> TaskTypes { get; set; }

        public IEnumerable<TaskStatus> TaskStatuses { get; set; }

        public int CaseId { get; set; }
    }
}
