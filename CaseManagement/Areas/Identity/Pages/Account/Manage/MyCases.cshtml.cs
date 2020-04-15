using CaseManagement.Models;
using CaseManagement.Services;
using CaseManagement.ViewModels.Cases.Input;
using CaseManagement.ViewModels.Cases.Output;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CaseManagement.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public partial class MyCasesModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly CasesTableInputToOutputModelService casesTableInputToOutputModelService;

        public MyCasesModel(UserManager<ApplicationUser> userManager,
            CasesTableInputToOutputModelService casesTableInputToOutputModelService)
        {
            this.userManager = userManager;
            this.casesTableInputToOutputModelService = casesTableInputToOutputModelService;
        }

        public AllCasesOutputModel outputModel { get; set; }

        public async Task<IActionResult> OnGetAsync(CasesIndexInputModel inputModel)
        {
            string userId = userManager.GetUserId(User);

            outputModel = await casesTableInputToOutputModelService.InputToOutputModelAsync(inputModel, userId);

            // If there are no results and need for paging just return model with empty Cases collection and don't do any paging logic
            if (outputModel.LastPage == 0)
            {
                return Page();
            }

            if (inputModel.PageNumber > outputModel.LastPage)
            {
                return RedirectToPage("MyCases", new { page = outputModel.LastPage });
            }

            outputModel.CurrentPage = inputModel.PageNumber;

            return Page();
        }
    }
}
