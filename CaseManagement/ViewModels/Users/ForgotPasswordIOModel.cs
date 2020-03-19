using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.Users
{
    public class ForgotPasswordIOModel
    {
        [Required]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }

        public bool? ResetSuccessful { get; set; }
    }
}
