using System.Threading.Tasks;
using CaseManagement.Models;
using CaseManagement.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CaseManagement.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public UsersController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string userEmail)
        {
            var user = await this.userManager.FindByEmailAsync(userEmail.Trim());

            await this.userManager.RemovePasswordAsync(user);
            await this.userManager.AddPasswordAsync(user, this.configuration["DefaultResetPassword"]);

            this.TempData["PasswordResetSuccessful"] = true;

            return LocalRedirect("/");
        }
    }
}