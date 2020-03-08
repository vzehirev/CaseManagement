using CaseManagement.ViewModels;
using CaseManagement.ViewModels.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.Tasks
{
    public interface ITasksService
    {
        public Task CreateTaskAsync(CreateTaskInputModel inputModel, string userId);
        public ViewUpdateTaskModel GetTaskById(int id);
        public Task<int> UpdateTaskAsync(ViewUpdateTaskModel caseToUpdate);
    }
}
