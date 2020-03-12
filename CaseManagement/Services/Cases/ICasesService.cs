using CaseManagement.Models.CaseModels;
using CaseManagement.ViewModels;
using CaseManagement.ViewModels.Input;
using CaseManagement.ViewModels.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseManagement.Services.Cases
{
    public interface ICasesService
    {
        public Task<int> CreateCaseAsync(CreateCaseInputModel inputModel, string userId);

        public Task<AllCasesOutputModel> GetAllCasesAsync();

        public Task<AllCasesOutputModel> GetCaseByNumberAsync(string caseNumber);

        public Task<ViewUpdateCaseModel> GetCaseByIdAsync(int id);

        public Task<int> UpdateCaseAsync(ViewUpdateCaseModel inputModel, string userId);

        public Task<ICollection<CaseType>> GetAllCaseTypesAsync();

        public Task<ICollection<CaseStatus>> GetAllCaseStatusesAsync();

        public Task<ICollection<CasePriority>> GetAllCasePrioritiesAsync();

        public Task<ICollection<Service>> GetAllCaseServicesAsync();
    }
}
