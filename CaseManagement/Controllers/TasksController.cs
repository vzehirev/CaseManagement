using CaseManagement.Models;
using CaseManagement.Services.Tasks;
using CaseManagement.ViewModels.Tasks;
using CaseManagement.ViewModels.Tasks.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CaseManagement.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITasksService tasksService;

        public TasksController(UserManager<ApplicationUser> userManager, ITasksService tasksService)
        {
            this.userManager = userManager;
            this.tasksService = tasksService;
        }

        public async Task<IActionResult> Create()
        {
            var model = new CreateTaskInputModel
            {
                // Populate drop-down menus' options
                TaskTypes = await this.tasksService.GetAllTaskTypesAsync(),
                TaskStatuses = await this.tasksService.GetAllTaskStatusesAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskInputModel inputModel, int id)
        {
            inputModel.CaseId = id;

            if (!this.ModelState.IsValid)
            {
                // Populate drop-down menus' options and return create page to edit data and re-submit
                inputModel.TaskTypes = await this.tasksService.GetAllTaskTypesAsync();
                inputModel.TaskStatuses = await this.tasksService.GetAllTaskStatusesAsync();

                return this.View(inputModel);
            }

            var userId = this.userManager.GetUserId(this.User);
            var createResult = await this.tasksService.CreateTaskAsync(inputModel, userId);

            if (createResult > 0)
            {
                this.TempData["TaskCreatedSuccessfully"] = true;

                return LocalRedirect($"/Cases/ViewUpdate/{inputModel.CaseId}#tasks-table");
            }

            return View("Error", new ErrorViewModel());
        }

        public async Task<IActionResult> ViewUpdate(int id)
        {
            var outputModel = await this.tasksService.GetTaskByIdAsync(id);

            return View(outputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ViewUpdateTaskIOModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Error", new ErrorViewModel());
            }

            var userId = this.userManager.GetUserId(this.User);
            var updateResult = await this.tasksService.UpdateTaskAsync(inputModel, userId);

            if (updateResult > 0)
            {
                this.TempData["TaskUpdatedSuccessfully"] = true;

            }

            return LocalRedirect($"/Cases/ViewUpdate/{inputModel.CaseId}#tasks-table");
        }
    }
}