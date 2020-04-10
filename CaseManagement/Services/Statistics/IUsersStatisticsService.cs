using System.Threading.Tasks;
using static CaseManagement.Areas.Identity.Pages.Account.Manage.MyStatisticsModel;

namespace CaseManagement.Services.Statistics
{
    public interface IUsersStatisticsService
    {
        public Task<MyStatisticsOutputModel> GetUserStatisticsForTodayAsync(string userId);

        public Task<MyStatisticsOutputModel> GetUserStatisticsForThisWeekAsync(string userId);

        public Task<MyStatisticsOutputModel> GetUserStatisticsForThisMonthAsync(string userId);
    }
}
