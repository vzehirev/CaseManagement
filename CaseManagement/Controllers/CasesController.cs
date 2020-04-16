using CaseManagement.Models;
using CaseManagement.Services;
using CaseManagement.Services.Announcements;
using CaseManagement.Services.Cases;
using CaseManagement.Services.Users;
using CaseManagement.ViewModels.Cases;
using CaseManagement.ViewModels.Cases.Input;
using CaseManagement.ViewModels.Cases.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Controllers
{
    [Authorize]
    public class CasesController : Controller
    {
        private readonly UsersService usersService;
        private readonly ICasesService casesService;
        private readonly CasesTableInputToOutputModelService casesTableInputToOutputModelService;
        private readonly IAnnouncementsService announcementsService;

        public CasesController(UsersService usersService,
            ICasesService casesService,
            CasesTableInputToOutputModelService casesTableInputToOutputModelService,
            IAnnouncementsService announcementsService)
        {
            this.usersService = usersService;
            this.casesService = casesService;
            this.casesTableInputToOutputModelService = casesTableInputToOutputModelService;
            this.announcementsService = announcementsService;
        }

        public async Task<IActionResult> Index(CasesIndexInputModel inputModel)
        {
            AllCasesOutputModel outputModel = await casesTableInputToOutputModelService.InputToOutputModelAsync(inputModel);

            if (outputModel.LastPage == 0)
            {
                return View(outputModel);
            }

            if (inputModel.PageNumber > outputModel.LastPage)
            {
                return RedirectToAction("Index", new { page = outputModel.LastPage });
            }

            outputModel.CurrentPage = inputModel.PageNumber;
            outputModel.Announcements = await announcementsService.GetAnnouncementsAsync();
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

            string userId = usersService.GetUserId(User);

            int createResult = await casesService.CreateCaseAsync(inputModel, userId);

            if (createResult > 0)
            {
                await usersService.UpdateUserLastActivityDateAsync(userId);

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

            string userId = usersService.GetUserId(User);
            int updateResult = await casesService.UpdateCaseAsync(inputModel, userId);

            if (updateResult > 0)
            {
                await usersService.UpdateUserLastActivityDateAsync(userId);

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