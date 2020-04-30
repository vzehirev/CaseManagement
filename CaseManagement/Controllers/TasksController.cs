using CaseManagement.Models;
using CaseManagement.Services.Tasks;
using CaseManagement.Services.Users;
using CaseManagement.ViewModels.Tasks;
using CaseManagement.ViewModels.Tasks.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CaseManagement.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ITasksService tasksService;

        public TasksController(IUsersService usersService, ITasksService tasksService)
        {
            this.usersService = usersService;
            this.tasksService = tasksService;
        }

        public async Task<IActionResult> Create()
        {
            CreateTaskInputModel model = new CreateTaskInputModel
            {
                // Populate drop-down menus' options
                TaskTypes = await tasksService.GetAllTaskTypesAsync(),
                TaskStatuses = await tasksService.GetAllTaskStatusesAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskInputModel inputModel, int id)
        {
            inputModel.CaseId = id;

            if (!ModelState.IsValid)
            {
                // Populate drop-down menus' options and return create page to edit data and re-submit
                inputModel.TaskTypes = await tasksService.GetAllTaskTypesAsync();
                inputModel.TaskStatuses = await tasksService.GetAllTaskStatusesAsync();

                return View(inputModel);
            }

            string userId = usersService.UserManager.GetUserId(User);
            int createResult = await tasksService.CreateTaskAsync(inputModel, userId);

            if (createResult > 0)
            {
                await usersService.UpdateUserLastActivityDateAsync(userId);

                TempData["TaskCreatedSuccessfully"] = true;

                return LocalRedirect($"/Cases/ViewUpdate/{inputModel.CaseId}#tasks-table");
            }

            return View("Error", new ErrorViewModel());
        }

        public async Task<IActionResult> ViewUpdate(int id)
        {
            ViewUpdateTaskIOModel outputModel = await tasksService.GetTaskByIdAsync(id);

            return View(outputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ViewUpdateTaskIOModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Error", new ErrorViewModel());
            }

            string userId = usersService.UserManager.GetUserId(User);
            int updateResult = await tasksService.UpdateTaskAsync(inputModel, userId);

            if (updateResult > 0)
            {
                await usersService.UpdateUserLastActivityDateAsync(userId);

                TempData["TaskUpdatedSuccessfully"] = true;
            }

            return LocalRedirect($"/Cases/ViewUpdate/{inputModel.CaseId}#tasks-table");
        }
    }
}