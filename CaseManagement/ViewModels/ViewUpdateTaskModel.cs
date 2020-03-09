using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
