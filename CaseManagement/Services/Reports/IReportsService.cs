using CaseManagement.ViewModels.Agents;
using System.Threading.Tasks;

namespace CaseManagement.Services.Reports
{
    public interface IReportsService
    {
        Task<AllAgentsOutputModel> GetAllAgentsAsync();
    }
}
