using CaseManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

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
            ApplicationUser user = await userManager.FindByEmailAsync(userEmail.Trim());

            await userManager.RemovePasswordAsync(user);
            await userManager.AddPasswordAsync(user, configuration["DefaultResetPassword"]);

            TempData["PasswordResetSuccessful"] = true;

            return LocalRedirect("/");
        }
    }
}