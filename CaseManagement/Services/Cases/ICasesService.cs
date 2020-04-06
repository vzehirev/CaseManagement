using CaseManagement.Models.CaseModels;
using CaseManagement.ViewModels.Cases;
using CaseManagement.ViewModels.Cases.Input;
using CaseManagement.ViewModels.Cases.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseManagement.Services.Cases
{
    public interface ICasesService
    {
        public Task<int> CreateCaseAsync(CreateCaseInputModel inputModel, string userId);

        public Task<AllCasesOutputModel> GetCasesAsync(int skip, int take, string orderBy, int[] selectedStatuses, int[] selectedPriorities);

        public Task<SearchCaseResultsOutputModel> GetCasesByNumberAsync(string caseNumber);

        public Task<ViewUpdateCaseIOModel> GetCaseByIdAsync(int id, int skipTasks, int takeTasks);

        public Task<int> UpdateCaseAsync(ViewUpdateCaseIOModel inputModel, string userId);

        public Task<ICollection<CaseType>> GetAllCaseTypesAsync();

        public Task<ICollection<CaseStatus>> GetAllCaseStatusesAsync();

        public Task<ICollection<CasePriority>> GetAllCasePrioritiesAsync();

        public Task<ICollection<Service>> GetAllCaseServicesAsync();

        public Task<string> GetCaseNumberByIdAsync(int caseId);

        public Task<int[]> GetAllCaseStatusesIdsAsync();

        public Task<int[]> GetAllCasePrioritiesIdsAsync();
    }
}
