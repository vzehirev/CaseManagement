using CaseManagement.Enums;
using CaseManagement.Helpers;
using CaseManagement.Models;
using CaseManagement.Services.StatisticsAndReports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public partial class MyStatisticsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAgentsStatisticsAndReportsService agentsStatisticsAndReportsService;

        public MyStatisticsModel(UserManager<ApplicationUser> userManager,
            IAgentsStatisticsAndReportsService agentsStatisticsAndReportsService)
        {
            this.userManager = userManager;
            this.agentsStatisticsAndReportsService = agentsStatisticsAndReportsService;
        }


        public MyStatisticsViewModel OutputModel { get; set; }

        public class MyStatisticsViewModel
        {
            public TimeFrameEnum TimeFrameOutput { get; set; }

            public int CreatedCasesLowPriority { get; set; }

            public int CreatedCasesNormalPriority { get; set; }

            public int CreatedCasesUrgentPriority { get; set; }

            public int CreatedCasesImmediatePriority { get; set; }

            public int CreatedCasesNaPriority { get; set; }

            public int UpdatedCasesLowPriority { get; set; }

            public int UpdatedCasesNormalPriority { get; set; }

            public int UpdatedCasesUrgentPriority { get; set; }

            public int UpdatedCasesImmediatePriority { get; set; }

            public int UpdatedCasesNaPriority { get; set; }

            public int ClosedCasesLowPriority { get; set; }

            public int ClosedCasesNormalPriority { get; set; }

            public int ClosedCasesUrgentPriority { get; set; }

            public int ClosedCasesImmediatePriority { get; set; }

            public int ClosedCasesNaPriority { get; set; }

            public int CreatedTasks { get; set; }

            public int UpdatedTasks { get; set; }

            public int ClosedTasks { get; set; }

            public int TotalCreatedCases =>
                CreatedCasesLowPriority
                + CreatedCasesNormalPriority
                + CreatedCasesUrgentPriority
                + CreatedCasesImmediatePriority
                + CreatedCasesNaPriority;

            public int TotalUpdatedCases =>
                UpdatedCasesLowPriority
                + UpdatedCasesNormalPriority
                + UpdatedCasesUrgentPriority
                + UpdatedCasesImmediatePriority
                + UpdatedCasesNaPriority;

            public int TotalClosedCases =>
                ClosedCasesLowPriority
                + ClosedCasesNormalPriority
                + ClosedCasesUrgentPriority
                + ClosedCasesImmediatePriority
                + ClosedCasesNaPriority;
        }

        public async Task<IActionResult> OnGetAsync(TimeFrameEnum timeFrame)
        {
            string userId = userManager.GetUserId(User);

            var fromDate = CalculateFromAndToDatesByTimeFrameEnum.CalculateFromDate(timeFrame);
            var toDate = CalculateFromAndToDatesByTimeFrameEnum.CalculateToDate(timeFrame);

            OutputModel = await agentsStatisticsAndReportsService.GetAgentsStatisticsAsync(userId, fromDate, toDate);
            OutputModel.TimeFrameOutput = timeFrame;

            return Page();
        }
    }
}
