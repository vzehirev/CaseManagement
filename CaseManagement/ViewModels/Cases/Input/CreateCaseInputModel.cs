using CaseManagement.Models.CaseModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.ViewModels.Cases.Input
{
    public class CreateCaseInputModel
    {
        [Required]
        [Display(Name = "Number")]
        public string Number { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        [Display(Name = "Priority")]
        public int PriorityId { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        public int? TypeId { get; set; }

        public int? PhaseId { get; set; }

        public int? ServiceId { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public IEnumerable<CaseStatus> CaseStatuses { get; set; }

        public IEnumerable<CasePriority> CasePriorities { get; set; }

        public IEnumerable<CaseType> CaseTypes { get; set; }

        public IEnumerable<Service> CaseServices { get; set; }
    }
}
