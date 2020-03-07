using CaseManagement.Models.CaseModels;
using CaseManagement.ViewModels;
using CaseManagement.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.Cases
{
    public interface ICasesService
    {
        public Task AddCaseAsync(Case caseToAdd);
        public AllCasesOutputModel GetAllCases();
        public ViewEditCaseModel GetCaseById(int id);
        public Task UpdateCase(ViewEditCaseModel model);
    }
}
