using CaseManagement.ViewModels.Agents;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CaseManagement.Areas.Identity.Pages.Account.Manage.MyStatisticsModel;

namespace CaseManagement.Services.StatisticsAndReports
{
    public interface IAgentsStatisticsAndReportsService
    {
        public Task<MyStatisticsViewModel> GetAgentsStatisticsAsync(string userId, DateTime fromDate, DateTime toDate);

        public Task<IEnumerable<ReportsAgentsActivitiesSelectedAgentViewModel>> GetAgentsActivitiesReportsAsync(string userId, DateTime fromDate, DateTime toDate);
    }
}
