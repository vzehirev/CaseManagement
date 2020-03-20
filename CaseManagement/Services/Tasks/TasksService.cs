using CaseManagement.Data;
using CaseManagement.Models;
using CaseManagement.Models.TaskModels;
using CaseManagement.ViewModels.Tasks;
using CaseManagement.ViewModels.Tasks.Input;
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
                Comments = inputModel.Comments,
            };

            this.dbContext.Tasks.Add(taskToAdd);
            var saveResult = await this.dbContext.SaveChangesAsync();

            return saveResult;
        }

        public async Task<ICollection<Models.TaskModels.TaskStatus>> GetAllTaskStatusesAsync()
        {
            return await this.dbContext.TaskStatuses.ToArrayAsync();
        }

        public async Task<ICollection<TaskType>> GetAllTaskTypesAsync()
        {
            return await this.dbContext.TaskTypes.ToArrayAsync();
        }

        public async Task<ViewUpdateTaskIOModel> GetTaskByIdAsync(int id)
        {
            var outputModel = await this.dbContext.Tasks
                .Select(t => new ViewUpdateTaskIOModel
                {
                    Id = t.Id,
                    Action = t.Action,
                    Comments = t.Comments,
                    CreatedOn = t.CreatedOn,
                    NextAction = t.NextAction,
                    StatusId = t.Status.Id,
                    TypeId = t.Type.Id,
                    CaseId = t.CaseId,
                    TaskTypes = this.dbContext.TaskTypes.ToArray(),
                    TaskStatuses = this.dbContext.TaskStatuses.ToArray(),
                })
                .Where(t => t.Id == id)
                .FirstOrDefaultAsync();

            return outputModel;
        }

        public async Task<int> UpdateTaskAsync(ViewUpdateTaskIOModel inputModel, string userId)
        {
            var taskRecordToUpdate = await this.dbContext.Tasks
                   .FirstOrDefaultAsync(t => t.Id == inputModel.Id);

            List<FieldModification> fieldModifications = new List<FieldModification>();

            if (taskRecordToUpdate.Comments != inputModel.Comments)
            {
                fieldModifications.Add(new FieldModification
                {
                    FieldName = "Comments",
                    OldValue = taskRecordToUpdate.Comments,
                    NewValue = inputModel.Comments,
                });
            }

            if (taskRecordToUpdate.TypeId != inputModel.TypeId)
            {
                fieldModifications.Add(new FieldModification
                {
                    FieldName = "Type",
                    OldValue = await this.dbContext.TaskTypes.Where(tt => tt.Id == taskRecordToUpdate.TypeId).Select(tt => tt.Type).FirstOrDefaultAsync(),
                    NewValue = await this.dbContext.TaskTypes.Where(tt => tt.Id == inputModel.TypeId).Select(tt => tt.Type).FirstOrDefaultAsync(),
                });
            }

            if (taskRecordToUpdate.StatusId != inputModel.StatusId)
            {
                fieldModifications.Add(new FieldModification
                {
                    FieldName = "Status",
                    OldValue = await this.dbContext.TaskStatuses.Where(ts => ts.Id == taskRecordToUpdate.StatusId).Select(ts => ts.Status).FirstOrDefaultAsync(),
                    NewValue = await this.dbContext.TaskStatuses.Where(ts => ts.Id == inputModel.StatusId).Select(ts => ts.Status).FirstOrDefaultAsync(),
                });
            }

            if (taskRecordToUpdate.Action != inputModel.Action)
            {
                fieldModifications.Add(new FieldModification
                {
                    FieldName = "Action",
                    OldValue = taskRecordToUpdate.Action,
                    NewValue = inputModel.Action,
                });
            }

            if (taskRecordToUpdate.NextAction != inputModel.NextAction)
            {
                fieldModifications.Add(new FieldModification
                {
                    FieldName = "Next action",
                    OldValue = taskRecordToUpdate.NextAction,
                    NewValue = inputModel.NextAction,
                });
            }

            taskRecordToUpdate.Comments = inputModel.Comments;
            taskRecordToUpdate.TypeId = inputModel.TypeId;
            taskRecordToUpdate.LastModified = DateTime.UtcNow;
            taskRecordToUpdate.StatusId = inputModel.StatusId;
            taskRecordToUpdate.Action = inputModel.Action;
            taskRecordToUpdate.NextAction = inputModel.NextAction;

            if (fieldModifications.Count > 0)
            {
                var modificationLogRecord = new TaskModificationLogRecord
                {
                    ModificationTime = DateTime.UtcNow,
                    UserId = userId,
                    TaskId = taskRecordToUpdate.Id,
                    ModifiedFields = fieldModifications,
                };

                this.dbContext.TaskModificationLogRecords.Add(modificationLogRecord);
            }

            this.dbContext.Tasks.Update(taskRecordToUpdate);

            var saveResult = await this.dbContext.SaveChangesAsync();

            return saveResult;
        }
    }
}
