using CaseManagement.Models.TaskModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models.CaseModels
{
    public class Case
    {
        public int Id { get; set; }
        [Required]
        public string CaseNum { get; set; }
        [Required]
        public string CaseSubject { get; set; }
        [Required]
        public string CaseDescription { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? CaseEndTime { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int? CaseTypeId { get; set; }
        public CaseType CaseType { get; set; }
        public int? CasePhaseId { get; set; }
        public CasePhase CasePhase { get; set; }
        public int? CaseStatusId { get; set; }
        public CaseStatus CaseStatus { get; set; }
        public int? CasePriorityId { get; set; }
        public CasePriority CasePriority { get; set; }
        public int? ServiceAreaId { get; set; }
        public ServiceArea ServiceArea { get; set; }
        public int? ServiceId { get; set; }
        public Service Service { get; set; }
        public ICollection<Task> Tasks { get; set; } = new HashSet<Task>();
    }
}
