using CaseManagement.Data;
using CaseManagement.Models.TaskModels;
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
    }
}
