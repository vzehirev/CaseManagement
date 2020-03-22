using CaseManagement.Models;
using CaseManagement.Services.Cases;
using CaseManagement.ViewModels.Cases;
using CaseManagement.ViewModels.Cases.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Controllers
{
    [Authorize]
    public class CasesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICasesService casesService;

        public CasesController(UserManager<ApplicationUser> userManager, ICasesService casesService)
        {
            this.userManager = userManager;
            this.casesService = casesService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            if (page < 1)
            {
                return this.RedirectToAction("Index", new { page = 1 });
            }

            const int casesPerPage = 10;

            int skip = (page - 1) * casesPerPage;

            var outputModel = await this.casesService.GetCasesAsync(skip, casesPerPage);

            // If there are no results and need for paging just return model with empty Cases collection and don't do any paging logic
            if (outputModel.AllCases == 0)
            {
                return this.View(outputModel);
            }

            outputModel.LastPage = (int)Math.Ceiling((decimal)outputModel.AllCases / casesPerPage);

            if (page > outputModel.LastPage)
            {
                return this.RedirectToAction("Index", new { page = outputModel.LastPage });
            }

            outputModel.CurrentPage = page;

            return View(outputModel);
        }

        public async Task<IActionResult> Create()
        {
            var model = new CreateCaseInputModel
            {
                // Populate drop-down menus' options
                CaseTypes = await this.casesService.GetAllCaseTypesAsync(),
                CaseStatuses = await this.casesService.GetAllCaseStatusesAsync(),
                CasePriorities = await this.casesService.GetAllCasePrioritiesAsync(),
                CaseServices = await this.casesService.GetAllCaseServicesAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCaseInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                // Populate drop-down menus' options and return create page to edit data and re-submit
                inputModel.CaseTypes = await this.casesService.GetAllCaseTypesAsync();
                inputModel.CaseStatuses = await this.casesService.GetAllCaseStatusesAsync();
                inputModel.CasePriorities = await this.casesService.GetAllCasePrioritiesAsync();
                inputModel.CaseServices = await this.casesService.GetAllCaseServicesAsync();

                return this.View(inputModel);
            }

            var userId = this.userManager.GetUserId(this.User);
            var createResult = await this.casesService.CreateCaseAsync(inputModel, userId);

            if (createResult > 0)
            {
                this.TempData["CaseCreatedSuccesffully"] = true;

                return RedirectToAction("ViewUpdate", new { id = createResult });
            }

            return View("Error", new ErrorViewModel());
        }

        public async Task<IActionResult> ViewUpdate(int id, int page = 1)
        {
            if (page < 1)
            {
                return this.RedirectToAction("ViewUpdate", new { id, page = 1 });
            }

            const int tasksPerPage = 1;

            int skip = (page - 1) * tasksPerPage;

            var outputModel = await this.casesService.GetCaseByIdAsync(id, skip, tasksPerPage);

            // If there are no results and need for paging just return model with empty Cases collection and don't do any paging logic
            if (outputModel.AllTasks == 0)
            {
                return this.View(outputModel);
            }

            outputModel.LastTasksPage = (int)Math.Ceiling((decimal)outputModel.AllTasks / tasksPerPage);

            if (page > outputModel.LastTasksPage)
            {
                return this.RedirectToAction("ViewUpdate", new { id, page = outputModel.LastTasksPage });
            }

            outputModel.CurrentTasksPage = page;

            return View(outputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ViewUpdateCaseIOModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Error", new ErrorViewModel());
            }

            var userId = this.userManager.GetUserId(this.User);
            var updateResult = await this.casesService.UpdateCaseAsync(inputModel, userId);

            if (updateResult > 0)
            {
                this.TempData["CaseUpdatedSuccessfully"] = true;
            }

            return RedirectToAction("ViewUpdate", new { id = inputModel.Id });
        }

        public async Task<IActionResult> SearchCase(string caseNumber)
        {

            if (string.IsNullOrWhiteSpace(caseNumber))
            {
                return RedirectToAction("Index");
            }

            var outputModel = await this.casesService.GetCasesByNumberAsync(caseNumber.Trim());
            outputModel.Results = outputModel.Results.OrderByDescending(c => c.CreatedOn).ToArray();

            return View("SearchCaseResults", outputModel);
        }
    }
}