using System.ComponentModel.DataAnnotations;

namespace CaseManagement.ViewModels.Input
{
    public class CreateCaseInputModel
    {
        [Required]
        [Display(Name = "Case Number")]
        public string Number { get; set; }

        public int? StatusId { get; set; }

        public string Status { get; set; }

        public int? PriorityId { get; set; }

        public string Priority { get; set; }

        [Required]
        [Display(Name = "Case Subject")]
        public string Subject { get; set; }

        public int? TypeId { get; set; }

        public string Type { get; set; }

        public int? PhaseId { get; set; }

        public string Phase { get; set; }

        [Required]
        [Display(Name = "Case Description")]
        public string Description { get; set; }
    }
}
