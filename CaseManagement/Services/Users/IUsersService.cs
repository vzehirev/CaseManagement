using CaseManagement.Models;
using CaseManagement.ViewModels.Agents;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.Users
{
    public interface IUsersService
    {
        public UserManager<ApplicationUser> UserManager { get; }

        Task<bool> ResetUserPasswordByIdAsync(string userId);

        Task<bool> ResetUserPasswordByEmailAsync(string userEmail);

        Task<bool> UpdateUserLastActivityDateAsync(string userId);

        Task<IEnumerable<ReportsRegisteredAgentsAgentViewModel>> GetAllAgentsLastActivityAsync();

        Task<IEnumerable<ReportsAgentsActivitiesAgentViewModel>> GetAllAgentsIdAndFullNameAsync();
    }
}
