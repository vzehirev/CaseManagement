using CaseManagement.Models.CaseModels;
using System;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models.TaskModels
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public string TaskAction { get; set; }
        [Required]
        public string NextAction { get; set; }
        [Required]
        public string Comments { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? CaseEndTime { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int CaseId { get; set; }
        public Case Case { get; set; }
        public int? TaskTypeId { get; set; }
        public TaskType TaskType { get; set; }
        public int? TaskStatusId { get; set; }
        public TaskStatus TaskStatus { get; set; }
    }
}
