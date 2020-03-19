using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagement.Models;
using CaseManagement.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagement.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult ForgotPassword(ForgotPasswordIOModel outputModel)
        {
            outputModel.ResetSuccessful = (bool?)this.TempData["ResetSuccessful"];

            return View(outputModel);
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string userEmail)
        {
            if (string.IsNullOrWhiteSpace(userEmail))
            {
                this.TempData["ResetSuccessful"] = false;

                return RedirectToAction("ForgotPassword");
            }

            var user = await this.userManager.FindByEmailAsync(userEmail.Trim());

            if (user == null)
            {
                this.TempData["ResetSuccessful"] = false;

                return RedirectToAction("ForgotPassword");
            }

            await userManager.RemovePasswordAsync(user);
            await this.userManager.AddPasswordAsync(user, "P@55word");

            this.TempData["ResetSuccessful"] = true;

            return RedirectToAction("ForgotPassword");
        }
    }
}