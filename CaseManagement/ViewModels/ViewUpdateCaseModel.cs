using CaseManagement.Models.CaseModels;
using CaseManagement.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.ViewModels
{
    public class ViewUpdateCaseModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Case Number")]
        public string Number { get; set; }

        public int? StatusId { get; set; }

        public int? PriorityId { get; set; }

        [Required]
        [Display(Name = "Case Subject")]
        public string Subject { get; set; }

        public int? TypeId { get; set; }

        public int? PhaseId { get; set; }

        public int? ServiceId { get; set; }

        [Display(Name = "Case Description")]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public IEnumerable<CaseStatus> CaseStatuses { get; set; }

        public IEnumerable<CasePriority> CasePriorities { get; set; }

        public IEnumerable<CaseType> CaseTypes { get; set; }

        public IEnumerable<Service> CaseServices { get; set; }

        public TaskOutputModel[] Tasks { get; set; }

        public bool? CaseUpdatedSuccessfully { get; set; }

        public bool? TaskUpdatedSuccessfully { get; set; }

        public bool? TaskCreatedSuccessfully { get; set; }
    }
}