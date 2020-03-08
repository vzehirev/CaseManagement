using CaseManagement.Data;
using CaseManagement.Models;
using CaseManagement.Models.CaseModels;
using CaseManagement.ViewModels;
using CaseManagement.ViewModels.Input;
using CaseManagement.ViewModels.Output;
using Microsoft.AspNetCore.Identity;
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
        public async Task CreateCaseAsync(CreateCaseInputModel inputModel, string userId)
        {
            var caseToAdd = new Case
            {
                Number = inputModel.Number,
                Subject = inputModel.Subject,
                Description = inputModel.Description,
                CreatedOn = DateTime.UtcNow,
                UserId = userId
            };

            await this.dbContext.Cases.AddAsync(caseToAdd);
            await this.dbContext.SaveChangesAsync();
        }

        public AllCasesOutputModel GetAllCases()
        {
            var allCases = this.dbContext.Cases
                .Select(c => new CaseOutputModel
                {
                    Number = c.Number,
                    Priority = c.Priority.Priority,
                    Status = c.Status.Status,
                    CreatedOn = c.CreatedOn,
                    Id = c.Id,
                    Owner = c.User.Email,
                    Subject = c.Subject
                })
                .ToArray();

            var result = new AllCasesOutputModel
            {
                Cases = allCases
            };

            return result;
        }

        public ViewUpdateCaseModel GetCaseById(int id)
        {
            var outputModel = this.dbContext.Cases
                .Select(c => new ViewUpdateCaseModel
                {
                    Id = c.Id,
                    Number = c.Number,
                    Priority = c.Priority.Priority,
                    Status = c.Status.Status,
                    CreatedOn = c.CreatedOn,
                    Subject = c.Subject,
                    Description = c.Description,
                    Type = c.Type.Type,
                    Phase = c.Phase.Phase,
                    Tasks = c.Tasks.Select(t => new TaskOutputModel
                    {
                        Id = t.Id,
                        CreatedOn = t.CreatedOn,
                        Type = t.Type.Type,
                        Status = t.Status.Status,
                        Owner = t.User.Email
                    }).ToArray()
                })
                .Where(c => c.Id == id)
                .FirstOrDefault();

            return outputModel;
        }

        public AllCasesOutputModel GetCaseByNumber(string caseNumber)
        {
            var allCases = this.dbContext.Cases
                .Where(c => c.Number == caseNumber)
                .Select(c => new CaseOutputModel
                {
                    Number = c.Number,
                    Priority = c.Priority.Priority,
                    Status = c.Status.Status,
                    CreatedOn = c.CreatedOn,
                    Id = c.Id,
                    Owner = c.User.Email,
                    Subject = c.Subject
                })
                .ToArray();

            var result = new AllCasesOutputModel
            {
                Cases = allCases
            };

            return result;
        }

        public async Task UpdateCaseAsync(ViewUpdateCaseModel inputModel)
        {
            var caseRecordToUpdate = this.dbContext.Cases
                .FirstOrDefault(c => c.Id == inputModel.Id);

            caseRecordToUpdate.Number = inputModel.Number;
            caseRecordToUpdate.Description = inputModel.Description;
            caseRecordToUpdate.Subject = inputModel.Subject;
            caseRecordToUpdate.LastModified = DateTime.UtcNow;
            caseRecordToUpdate.StatusId = inputModel.StatusId;
            caseRecordToUpdate.TypeId = inputModel.TypeId;
            caseRecordToUpdate.PriorityId = inputModel.PriorityId;
            caseRecordToUpdate.PhaseId = inputModel.PhaseId;

            this.dbContext.Cases.Update(caseRecordToUpdate);

            await this.dbContext.SaveChangesAsync();
        }
    }
}
