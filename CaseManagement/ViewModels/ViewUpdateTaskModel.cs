using System;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.ViewModels
{
    public class ViewUpdateTaskModel
    {
        public int Id { get; set; }

        [Required]
        public string Action { get; set; }

        [Required]
        public string NextAction { get; set; }

        public int? StatusId { get; set; }

        public string Status { get; set; }

        [Required]
        [Display(Name = "Case Subject")]
        public int? TypeId { get; set; }

        public string Type { get; set; }

        [Required]
        public string Comments { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CaseId { get; set; }
    }
}
