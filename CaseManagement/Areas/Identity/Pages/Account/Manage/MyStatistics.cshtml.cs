using CaseManagement.Models;
using CaseManagement.Services.Statistics;
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
        private readonly IUsersStatisticsService usersStatisticsService;

        public MyStatisticsModel(UserManager<ApplicationUser> userManager, IUsersStatisticsService usersStatisticsService)
        {
            this.userManager = userManager;
            this.usersStatisticsService = usersStatisticsService;
        }

        public string TimeFrameOutput { get; set; }

        public MyStatisticsOutputModel OutputModel { get; set; }

        public class MyStatisticsOutputModel
        {
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

        public async Task<IActionResult> OnGetAsync(string timeFrameInput)
        {
            TimeFrameOutput = timeFrameInput;

            string[] possibleFilters = new string[]
            {
                "today",
                "week",
                "month",
            };

            if (!possibleFilters.Contains(TimeFrameOutput))
            {
                TimeFrameOutput = "today";
            }

            string userId = userManager.GetUserId(User);

            switch (TimeFrameOutput)
            {
                case "today":
                    OutputModel = await usersStatisticsService.GetUserStatisticsForTodayAsync(userId);
                    break;

                case "week":
                    OutputModel = await usersStatisticsService.GetUserStatisticsForThisWeekAsync(userId);
                    break;

                case "month":
                    OutputModel = await usersStatisticsService.GetUserStatisticsForThisMonthAsync(userId);
                    break;
            }

            return Page();
        }
    }
}
