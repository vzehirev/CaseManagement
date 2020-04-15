using CaseManagement.Services.Cases;
using CaseManagement.ViewModels.Cases.Input;
using CaseManagement.ViewModels.Cases.Output;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services
{
    public class CasesTableInputToOutputModelService
    {
        private readonly ICasesService casesService;

        public CasesTableInputToOutputModelService(ICasesService casesService)
        {
            this.casesService = casesService;
        }

        public async Task<AllCasesOutputModel> InputToOutputModelAsync(CasesIndexInputModel inputModel, string userId = null)
        {
            if (inputModel.PageNumber < 1)
            {
                inputModel.PageNumber = 1;
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

            int skip = (inputModel.PageNumber - 1) * casesPerPage;

            if (inputModel.SelectedStatuses == null)
            {
                inputModel.SelectedStatuses = await casesService.GetAllCaseStatusesIdsAsync();
            }

            if (inputModel.SelectedPriorities == null)
            {
                inputModel.SelectedPriorities = await casesService.GetAllCasePrioritiesIdsAsync();
            }

            AllCasesOutputModel outputModel = await casesService
                .GetCasesAsync(skip, casesPerPage, inputModel.OrderBy, inputModel.SelectedStatuses, inputModel.SelectedPriorities, userId);

            outputModel.OrderedBy = inputModel.OrderBy;
            outputModel.SelectedStatuses = inputModel.SelectedStatuses;
            outputModel.SelectedPriorities = inputModel.SelectedPriorities;
            outputModel.LastPage = (int)Math.Ceiling((double)outputModel.AllCases / casesPerPage);

            return outputModel;
        }
    }
}
