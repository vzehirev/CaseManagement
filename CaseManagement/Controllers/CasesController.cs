using CaseManagement.Models;
using CaseManagement.Services.Cases;
using CaseManagement.ViewModels;
using CaseManagement.ViewModels.Input;
using CaseManagement.ViewModels.Output;
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
        private readonly ICasesService casesService;
        private readonly UserManager<ApplicationUser> userManager;

        public CasesController(ICasesService casesService, UserManager<ApplicationUser> userManager)
        {
            this.casesService = casesService;
            this.userManager = userManager;
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
                CasePriorities = await this.casesService.GetAllCasePrioritiesAsync(),
                CaseStatuses = await this.casesService.GetAllCaseStatusesAsync(),
                CaseTypes = await this.casesService.GetAllCaseTypesAsync(),
                CaseServices = await this.casesService.GetAllCaseServicesAsync(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCaseInputModel inputModel)
        {
            var userId = this.userManager.GetUserId(this.User);
            var createResult = await this.casesService.CreateCaseAsync(inputModel, userId);

            if (createResult > 0)
            {
                return RedirectToAction("ViewUpdate", new { id = createResult });
            }

            return View("Error", new ErrorViewModel());
        }

        public async Task<IActionResult> ViewUpdate(int id)
        {
            var outputModel = await this.casesService.GetCaseByIdAsync(id);
            outputModel.Tasks = outputModel.Tasks.OrderByDescending(t => t.CreatedOn).ToArray();

            outputModel.CaseUpdatedSuccessfully = (bool?)this.TempData["CaseUpdatedSuccessfully"];

            outputModel.TaskCreatedSuccessfully = (bool?)this.TempData["TaskCreatedSuccessfully"];

            outputModel.TaskUpdatedSuccessfully = (bool?)this.TempData["TaskUpdatedSuccessfully"];

            return View(outputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ViewUpdateCaseModel inputModel)
        {
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

            caseNumber = caseNumber.Trim();

            var outputModel = await this.casesService.GetCaseByNumberAsync(caseNumber);
            outputModel.Cases = outputModel.Cases.OrderByDescending(c => c.CreatedOn).ToArray();

            return View("Index", outputModel);
        }
        public async Task<IActionResult> CaseUpdates(int caseId)
        {
            var outputModel = await this.casesService.GetCaseUpdatesAsync(caseId);

            return View(outputModel);
        }
    }
}