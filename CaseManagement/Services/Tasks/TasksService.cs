using CaseManagement.Data;
using CaseManagement.Models.TaskModels;
using CaseManagement.ViewModels;
using CaseManagement.ViewModels.Input;
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
        public async Task CreateTaskAsync(CreateTaskInputModel inputModel, string userId)
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

            await this.dbContext.Tasks.AddAsync(taskToAdd);
            await this.dbContext.SaveChangesAsync();
        }

        public ViewUpdateTaskModel GetTaskById(int id)
        {
            var outputModel = this.dbContext.Tasks
                .Select(t => new ViewUpdateTaskModel
                {
                    Id = t.Id,
                    Action = t.Action,
                    Comments = t.Comments,
                    CreatedOn = t.CreatedOn,
                    NextAction = t.NextAction,
                    Status = t.Status.Status,
                    Type = t.Type.Type
                })
                .Where(t => t.Id == id)
                .FirstOrDefault();

            return outputModel;
        }

        public async Task<int> UpdateTaskAsync(ViewUpdateTaskModel inputModel)
        {
            var taskRecordToUpdate = this.dbContext.Tasks
                   .FirstOrDefault(t => t.Id == inputModel.Id);

            taskRecordToUpdate.Comments = inputModel.Comments;
            taskRecordToUpdate.TypeId = inputModel.TypeId;
            taskRecordToUpdate.LastModified = DateTime.UtcNow;
            taskRecordToUpdate.StatusId = inputModel.StatusId;
            taskRecordToUpdate.Action = inputModel.Action;
            taskRecordToUpdate.NextAction = inputModel.NextAction;

            this.dbContext.Tasks.Update(taskRecordToUpdate);

            await this.dbContext.SaveChangesAsync();

            return taskRecordToUpdate.CaseId;
        }
    }
}
