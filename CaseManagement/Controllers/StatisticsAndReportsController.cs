using CaseManagement.Helpers;
using CaseManagement.Services.StatisticsAndReports;
using CaseManagement.Services.Users;
using CaseManagement.ViewModels.Agents;
using CaseManagement.ViewModels.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.VisualBasic;
using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace CaseManagement.Controllers
{
    [Authorize(Roles = "Lead")]
    public class StatisticsAndReportsController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IAgentsStatisticsAndReportsService usersStatisticsService;

        public StatisticsAndReportsController(IUsersService usersService,
            IAgentsStatisticsAndReportsService usersStatisticsService)
        {
            this.usersService = usersService;
            this.usersStatisticsService = usersStatisticsService;
        }

        public async Task<IActionResult> RegisteredAgents()
        {
            var viewModel = new RegisteredAgentsViewModel
            {
                AllAgents = await this.usersService.GetAllAgentsLastActivityAsync()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> AgentsActivities(AgentsActivitiesViewModel viewModel)
        {
            DateTime fromDate;
            DateTime toDate;

            if (viewModel.FromDate != null && viewModel.ToDate != null)
            {
                // Make fromDate's = viewModel.FromDate with time of 00:00.
                fromDate = viewModel.FromDate.Value
                    .AddMilliseconds(-viewModel.FromDate.Value.TimeOfDay.TotalMilliseconds);

                // Make toDate's = viewModel.ToDate with time of 23:59.
                toDate = viewModel.ToDate.Value
                    .AddDays(1)
                    .AddMilliseconds(-viewModel.ToDate.Value.TimeOfDay.TotalMilliseconds - 1);
            }
            else
            {
                fromDate = CalculateFromAndToDatesByTimeFrameEnum.CalculateFromDate(viewModel.TimeFrame);
                toDate = CalculateFromAndToDatesByTimeFrameEnum.CalculateToDate(viewModel.TimeFrame);
            }

            viewModel.SelectedAgents = await this.usersStatisticsService
                .GetAgentsActivitiesReportsAsync(viewModel.UserId, fromDate, toDate);

            viewModel.AllAgents = await this.usersService.GetAllAgentsIdAndFullNameAsync();

            return View(viewModel);
        }
    }
}