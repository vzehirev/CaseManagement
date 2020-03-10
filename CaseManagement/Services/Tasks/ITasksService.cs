using CaseManagement.ViewModels;
using CaseManagement.ViewModels.Input;
using System.Threading.Tasks;

namespace CaseManagement.Services.Tasks
{
    public interface ITasksService
    {
        public Task<int> CreateTaskAsync(CreateTaskInputModel inputModel, string userId);

        public Task<ViewUpdateTaskModel> GetTaskByIdAsync(int id);

        public Task<int> UpdateTaskAsync(ViewUpdateTaskModel caseToUpdate);
    }
}
