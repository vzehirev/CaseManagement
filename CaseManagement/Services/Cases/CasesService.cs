using CaseManagement.Data;
using CaseManagement.Models;
using CaseManagement.Models.CaseModels;
using CaseManagement.ViewModels;
using CaseManagement.ViewModels.Input;
using CaseManagement.ViewModels.Output;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> CreateCaseAsync(CreateCaseInputModel inputModel, string userId)
        {
            var caseToAdd = new Case
            {
                Number = inputModel.Number,
                Subject = inputModel.Subject,
                Description = inputModel.Description,
                CreatedOn = DateTime.UtcNow,
                UserId = userId
            };

            this.dbContext.Cases.Add(caseToAdd);
            var saveResult = await this.dbContext.SaveChangesAsync();

            return saveResult;
        }

        public async Task<AllCasesOutputModel> GetAllCasesAsync()
        {
            var allCases = await this.dbContext.Cases
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
                .ToArrayAsync();

            var result = new AllCasesOutputModel
            {
                Cases = allCases
            };

            return result;
        }

        public async Task<ViewUpdateCaseModel> GetCaseByIdAsync(int id)
        {
            var outputModel = await this.dbContext.Cases
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
                .FirstOrDefaultAsync();

            return outputModel;
        }

        public async Task<AllCasesOutputModel> GetCaseByNumberAsync(string caseNumber)
        {
            var allCases = await this.dbContext.Cases
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
                .ToArrayAsync();

            var result = new AllCasesOutputModel
            {
                Cases = allCases
            };

            return result;
        }

        public async Task<int> UpdateCaseAsync(ViewUpdateCaseModel inputModel)
        {
            var caseRecordToUpdate = await this.dbContext.Cases
                .FirstOrDefaultAsync(c => c.Id == inputModel.Id);

            caseRecordToUpdate.Number = inputModel.Number;
            caseRecordToUpdate.Description = inputModel.Description;
            caseRecordToUpdate.Subject = inputModel.Subject;
            caseRecordToUpdate.LastModified = DateTime.UtcNow;
            caseRecordToUpdate.StatusId = inputModel.StatusId;
            caseRecordToUpdate.TypeId = inputModel.TypeId;
            caseRecordToUpdate.PriorityId = inputModel.PriorityId;
            caseRecordToUpdate.PhaseId = inputModel.PhaseId;

            this.dbContext.Cases.Update(caseRecordToUpdate);
            var saveResult = await this.dbContext.SaveChangesAsync();

            return saveResult;
        }
    }
}
