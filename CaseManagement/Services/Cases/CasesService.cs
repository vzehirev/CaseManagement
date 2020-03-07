using CaseManagement.Data;
using CaseManagement.Models.CaseModels;
using CaseManagement.ViewModels;
using CaseManagement.ViewModels.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.Cases
{
    public class CasesService : ICasesService
    {
        private readonly ApplicationDbContext dbContext;

        public CasesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddCaseAsync(Case caseToAdd)
        {
            await this.dbContext.Cases.AddAsync(caseToAdd);
            await this.dbContext.SaveChangesAsync();
        }

        public AllCasesOutputModel GetAllCases()
        {
            var allCases = this.dbContext.Cases
                .Select(c => new CaseOutputModel
                {
                    CaseNumber = c.CaseNum,
                    CasePriority = c.CasePriority.Priority,
                    CaseStatus = c.CaseStatus.Status,
                    CreationTime = c.CreationTime,
                    Id = c.Id,
                    Owner = c.User.Email,
                    Subject = c.CaseSubject
                })
                .ToArray();

            var result = new AllCasesOutputModel
            {
                Cases = allCases
            };

            return result;
        }

        public ViewEditCaseModel GetCaseById(int id)
        {
            var outputModel = this.dbContext.Cases
                .Select(c => new ViewEditCaseModel
                {
                    Id = c.Id,
                    CaseNum = c.CaseNum,
                    CasePriority = c.CasePriority.Priority,
                    CaseStatus = c.CaseStatus.Status,
                    CreationTime = c.CreationTime,
                    CaseSubject = c.CaseSubject,
                    CaseDescription = c.CaseDescription,
                    CaseType = c.CaseType.Type,
                    CasePhase = c.CasePhase.Phase
                })
                .Where(c => c.Id == id)
                .FirstOrDefault();

            return outputModel;
        }

        public Task UpdateCase(ViewEditCaseModel model)
        {
            var caseToUpdate = this.dbContext.Cases.Find(model.Id);

            throw new NotImplementedException();
        }
    }
}
