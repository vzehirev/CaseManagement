using CaseManagement.Models.CaseModels;
using CaseManagement.ViewModels;
using CaseManagement.ViewModels.Input;
using CaseManagement.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.Cases
{
    public interface ICasesService
    {
        public Task<int> CreateCaseAsync(CreateCaseInputModel inputModel, string userId);
        public Task<AllCasesOutputModel> GetAllCasesAsync();
        public Task<AllCasesOutputModel> GetCaseByNumberAsync(string caseNumber);
        public Task<ViewUpdateCaseModel> GetCaseByIdAsync(int id);
        public Task<int> UpdateCaseAsync(ViewUpdateCaseModel inputModel);
    }
}
