using System.ComponentModel.DataAnnotations;

namespace CaseManagement.ViewModels.Users
{
    public class ForgotPasswordIOModel
    {
        [Required]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
    }
}
