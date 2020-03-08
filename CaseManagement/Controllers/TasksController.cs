using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagement.Models;
using CaseManagement.Services.Tasks;
using CaseManagement.ViewModels.Input;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagement.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITasksService tasksService;
        private readonly UserManager<ApplicationUser> userManager;

        public TasksController(ITasksService tasksService, UserManager<ApplicationUser> userManager)
        {
            this.tasksService = tasksService;
            this.userManager = userManager;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskInputModel inputModel, int id)
        {
            var userId = this.userManager.GetUserId(this.User);
            inputModel.CaseId = id;
            await this.tasksService.CreateTaskAsync(inputModel, userId);

            return RedirectToAction("ViewUpdate", "Cases", new { id });
        }
    }
}