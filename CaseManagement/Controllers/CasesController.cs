using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagement.Models;
using CaseManagement.Models.CaseModels;
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
            outputModel.Cases = outputModel.Cases.OrderByDescending(c => c.CreationTime).ToArray();
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

            var caseToAdd = new Case
            {
                CaseNum = inputModel.CaseNum,
                CaseSubject = inputModel.CaseSubject,
                CaseDescription = inputModel.CaseDescription,
                CreationTime = DateTime.UtcNow,
                UserId = userId
            };

            await this.casesService.AddCaseAsync(caseToAdd);

            return RedirectToAction("Index");
        }
        public IActionResult ViewEdit(int id)
        {
            var outputModel = this.casesService.GetCaseById(id);

            if (outputModel == null)
            {
                return RedirectToAction("Index");
            }

            return View(outputModel);
        }
        public IActionResult Edit(ViewEditCaseModel model)
        {
            var outputModel = this.casesService.GetCaseById(model.Id);

            if (outputModel == null)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}