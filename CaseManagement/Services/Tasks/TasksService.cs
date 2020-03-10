using CaseManagement.Data;
using CaseManagement.Models.TaskModels;
using CaseManagement.ViewModels;
using CaseManagement.ViewModels.Input;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.Tasks
{
    public class TasksService : ITasksService
    {
        private readonly ApplicationDbContext dbContext;

        public TasksService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateTaskAsync(CreateTaskInputModel inputModel, string userId)
        {
            var taskToAdd = new CaseTask
            {
                CreatedOn = DateTime.UtcNow,
                UserId = userId,
                CaseId = inputModel.CaseId,
                TypeId = inputModel.TypeId,
                StatusId = inputModel.StatusId,
                Action = inputModel.Action,
                NextAction = inputModel.NextAction,
                Comments = inputModel.Comments
            };

            this.dbContext.Tasks.Add(taskToAdd);
            var saveResult = await this.dbContext.SaveChangesAsync();

            return saveResult;
        }

        public async Task<ViewUpdateTaskModel> GetTaskByIdAsync(int id)
        {
            var outputModel = await this.dbContext.Tasks
                .Select(t => new ViewUpdateTaskModel
                {
                    Id = t.Id,
                    Action = t.Action,
                    Comments = t.Comments,
                    CreatedOn = t.CreatedOn,
                    NextAction = t.NextAction,
                    Status = t.Status.Status,
                    Type = t.Type.Type,
                    CaseId = t.CaseId
                })
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            return outputModel;
        }

        public async Task<int> UpdateTaskAsync(ViewUpdateTaskModel inputModel)
        {
            var taskRecordToUpdate = await this.dbContext.Tasks
                   .FirstOrDefaultAsync(t => t.Id == inputModel.Id);

            taskRecordToUpdate.Comments = inputModel.Comments;
            taskRecordToUpdate.TypeId = inputModel.TypeId;
            taskRecordToUpdate.LastModified = DateTime.UtcNow;
            taskRecordToUpdate.StatusId = inputModel.StatusId;
            taskRecordToUpdate.Action = inputModel.Action;
            taskRecordToUpdate.NextAction = inputModel.NextAction;

            this.dbContext.Tasks.Update(taskRecordToUpdate);

            var saveResult = await this.dbContext.SaveChangesAsync();

            return saveResult;
        }
    }
}
