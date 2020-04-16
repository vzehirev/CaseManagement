using CaseManagement.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CaseManagement.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersService usersService;
        private readonly IConfiguration configuration;

        public UsersController(UsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string userEmail)
        {
            await usersService.ResetUserPasswordByEmailAsync(userEmail.Trim());

            TempData["PasswordResetSuccessful"] = true;

            return LocalRedirect("/");
        }

        [Authorize(Roles = "Lead")]
        public async Task<IActionResult> ResetAgentPassword(string userId)
        {
            await usersService.ResetUserPasswordByIdAsync(userId);

            TempData["AgentPasswordResetSuccessful"] = true;

            return LocalRedirect("/Reports");
        }
    }
}