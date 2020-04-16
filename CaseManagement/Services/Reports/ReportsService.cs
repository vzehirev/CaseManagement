using CaseManagement.Data;
using CaseManagement.ViewModels.Agents;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.Reports
{
    public class ReportsService : IReportsService
    {
        private readonly ApplicationDbContext dbContext;

        public ReportsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<AllAgentsOutputModel> GetAllAgentsAsync()
        {
            AgentOutputModel[] allAgents = await dbContext.Users
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .Select(u => new AgentOutputModel
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    LastActivityDate = u.LastActivity,
                })
                .ToArrayAsync();

            AllAgentsOutputModel outputModel = new AllAgentsOutputModel
            {
                Agents = allAgents,
            };

            return outputModel;
        }
    }
}
