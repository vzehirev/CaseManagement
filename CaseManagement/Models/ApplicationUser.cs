using CaseManagement.Models.CaseModels;
using CaseManagement.Models.TaskModels;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CaseManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Case> Cases { get; set; } = new HashSet<Case>();
        public ICollection<CaseTask> Tasks { get; set; } = new HashSet<CaseTask>();
    }
}
