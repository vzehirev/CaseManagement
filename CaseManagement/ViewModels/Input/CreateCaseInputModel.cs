using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.Input
{
    public class CreateCaseInputModel
    {
        [Required]
        [Display(Name = "Case Number")]
        public string CaseNum { get; set; }
        public string CaseStatus { get; set; }
        public string CasePriority { get; set; }
        [Required]
        [Display(Name = "Case Subject")]
        public string CaseSubject { get; set; }
        public string CaseType { get; set; }
        public string CasePhase { get; set; }
        [Required]
        [Display(Name = "Case Description")]
        public string CaseDescription { get; set; }
    }
}
