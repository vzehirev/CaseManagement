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
        public Task CreateCaseAsync(CreateCaseInputModel inputModel, string userId);
        public AllCasesOutputModel GetAllCases();
        public AllCasesOutputModel GetCaseByNumber(string caseNumber);
        public ViewUpdateCaseModel GetCaseById(int id);
        public Task UpdateCaseAsync(ViewUpdateCaseModel caseToUpdate);
    }
}
