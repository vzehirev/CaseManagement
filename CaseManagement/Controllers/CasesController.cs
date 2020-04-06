using CaseManagement.Models;
using CaseManagement.Services.Cases;
using CaseManagement.ViewModels.Cases;
using CaseManagement.ViewModels.Cases.Input;
using CaseManagement.ViewModels.Cases.Output;
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

        public async Task<IActionResult> Index(CasesIndexInputModel inputModel)
        {
            if (inputModel.Page < 1)
            {
                inputModel.Page = 1;
            }

            string[] possibleOrders = new[]
            {
                "CreatedOn-desc",
                "CreatedOn-asc",
                "Status-desc",
                "Status-asc",
                "Priority-desc",
                "Priority-asc",
            };

            if (!possibleOrders.Contains(inputModel.OrderBy))
            {
                inputModel.OrderBy = possibleOrders.First();
            }

            const int casesPerPage = 10;

            int skip = (inputModel.Page - 1) * casesPerPage;

            if (inputModel.SelectedStatuses == null)
            {
                inputModel.SelectedStatuses = await casesService.GetAllCaseStatusesIdsAsync();
            }

            if (inputModel.SelectedPriorities == null)
            {
                inputModel.SelectedPriorities = await casesService.GetAllCasePrioritiesIdsAsync();
            }

            AllCasesOutputModel outputModel = await casesService
                .GetCasesAsync(skip, casesPerPage, inputModel.OrderBy, inputModel.SelectedStatuses, inputModel.SelectedPriorities);

            outputModel.OrderedBy = inputModel.OrderBy;
            outputModel.SelectedStatuses = inputModel.SelectedStatuses;
            outputModel.SelectedPriorities = inputModel.SelectedPriorities;

            // If there are no results and need for paging just return model with empty Cases collection and don't do any paging logic
            if (outputModel.AllCases == 0)
            {
                return View(outputModel);
            }

            outputModel.LastPage = (int)Math.Ceiling((double)outputModel.AllCases / casesPerPage);

            if (inputModel.Page > outputModel.LastPage)
            {
                return RedirectToAction("Index", new { page = outputModel.LastPage });
            }

            outputModel.CurrentPage = inputModel.Page;

            return View(outputModel);
        }

        public async Task<IActionResult> Create()
        {
            CreateCaseInputModel model = new CreateCaseInputModel
            {
                // Populate drop-down menus' options
                CaseTypes = await casesService.GetAllCaseTypesAsync(),
                CaseStatuses = await casesService.GetAllCaseStatusesAsync(),
                CasePriorities = await casesService.GetAllCasePrioritiesAsync(),
                CaseServices = await casesService.GetAllCaseServicesAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCaseInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                // Populate drop-down menus' options and return create page to edit data and re-submit
                inputModel.CaseTypes = await casesService.GetAllCaseTypesAsync();
                inputModel.CaseStatuses = await casesService.GetAllCaseStatusesAsync();
                inputModel.CasePriorities = await casesService.GetAllCasePrioritiesAsync();
                inputModel.CaseServices = await casesService.GetAllCaseServicesAsync();

                return View(inputModel);
            }

            string userId = userManager.GetUserId(User);
            int createResult = await casesService.CreateCaseAsync(inputModel, userId);

            if (createResult > 0)
            {
                TempData["CaseCreatedSuccesffully"] = true;

                return RedirectToAction("ViewUpdate", new { id = createResult });
            }

            return View("Error", new ErrorViewModel());
        }

        public async Task<IActionResult> ViewUpdate(int id, int page = 1)
        {
            page = page >= 1 ? page : 1;

            const int tasksPerPage = 10;

            int skip = (page - 1) * tasksPerPage;

            ViewUpdateCaseIOModel outputModel = await casesService.GetCaseByIdAsync(id, skip, tasksPerPage);

            // If there are no results and need for paging just return model with empty Cases collection and don't do any paging logic
            if (outputModel.AllTasks == 0)
            {
                return View(outputModel);
            }

            outputModel.LastTasksPage = (int)Math.Ceiling((decimal)outputModel.AllTasks / tasksPerPage);

            if (page > outputModel.LastTasksPage)
            {
                return RedirectToAction("ViewUpdate", new { id, page = outputModel.LastTasksPage });
            }

            outputModel.CurrentTasksPage = page;

            return View(outputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ViewUpdateCaseIOModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Error", new ErrorViewModel());
            }

            string userId = userManager.GetUserId(User);
            int updateResult = await casesService.UpdateCaseAsync(inputModel, userId);

            if (updateResult > 0)
            {
                TempData["CaseUpdatedSuccessfully"] = true;
            }

            return RedirectToAction("ViewUpdate", new { id = inputModel.Id });
        }

        public async Task<IActionResult> SearchCase(string caseNumber)
        {

            if (string.IsNullOrWhiteSpace(caseNumber))
            {
                return RedirectToAction("Index");
            }

            ViewModels.Cases.Output.SearchCaseResultsOutputModel outputModel = await casesService.GetCasesByNumberAsync(caseNumber.Trim());
            outputModel.Results = outputModel.Results.OrderByDescending(c => c.CreatedOn).ToArray();

            return View("SearchCaseResults", outputModel);
        }
    }
}