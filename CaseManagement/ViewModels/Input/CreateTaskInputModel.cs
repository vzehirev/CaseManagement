using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.Input
{
    public class CreateTaskInputModel
    {
        public int? TypeId { get; set; }

        public string Type { get; set; }

        public int? StatusId { get; set; }

        public string Status { get; set; }

        [Required]
        public string Action { get; set; }

        [Required]
        [Display(Name = "Next action")]
        public string NextAction { get; set; }

        [Required]
        public string Comments { get; set; }

        public int CaseId { get; set; }
    }
}
