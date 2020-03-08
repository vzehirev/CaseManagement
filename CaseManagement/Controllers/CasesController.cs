using System;
using System.Linq;
using System.Threading.Tasks;
using CaseManagement.Models;
using CaseManagement.Services.Cases;
using CaseManagement.ViewModels;
using CaseManagement.ViewModels.Input;
using CaseManagement.ViewModels.Output;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagement.Controllers
{
    public class CasesController : Controller
    {
        private readonly ICasesService casesService;
        private readonly UserManager<ApplicationUser> userManager;

        public CasesController(ICasesService casesService, UserManager<ApplicationUser> userManager)
        {
            this.casesService = casesService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var outputModel = this.casesService.GetAllCases();
            outputModel.Cases = outputModel.Cases.OrderByDescending(c => c.CreatedOn).ToArray();
            return View(outputModel);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCaseInputModel inputModel)
        {
            var userId = this.userManager.GetUserId(this.User);

            await this.casesService.CreateCaseAsync(inputModel, userId);

            return RedirectToAction("Index");
        }
        public IActionResult ViewUpdate(int id)
        {
            var outputModel = this.casesService.GetCaseById(id);

            if (outputModel == null)
            {
                return RedirectToAction("Index");
            }

            outputModel.Tasks = outputModel.Tasks.OrderByDescending(t => t.CreatedOn).ToArray();

            return View(outputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ViewUpdateCaseModel inputModel)
        {
            await this.casesService.UpdateCaseAsync(inputModel);

            return RedirectToAction("Index");
        }

        public IActionResult SearchCase(string caseNumber)
        {
            if (string.IsNullOrWhiteSpace(caseNumber))
            {
                return RedirectToAction("Index");
            }

            var outputModel = this.casesService.GetCaseByNumber(caseNumber);
            outputModel.Cases = outputModel.Cases.OrderByDescending(c => c.CreatedOn).ToArray();

            return View("Index", outputModel);
        }
    }
}