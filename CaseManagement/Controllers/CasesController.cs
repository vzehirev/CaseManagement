using CaseManagement.Models;
using CaseManagement.Services.Cases;
using CaseManagement.ViewModels.Cases;
using CaseManagement.ViewModels.Cases.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            var outputModel = await this.casesService.GetAllCasesAsync();
            outputModel.Cases = outputModel.Cases.OrderByDescending(c => c.CreatedOn).ToArray();

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

        public async Task<IActionResult> ViewUpdate(int id)
        {
            var outputModel = await this.casesService.GetCaseByIdAsync(id);
            outputModel.Tasks = outputModel.Tasks.OrderByDescending(t => t.CreatedOn).ToArray();

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