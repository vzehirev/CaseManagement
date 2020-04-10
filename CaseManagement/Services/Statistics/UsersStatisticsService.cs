using CaseManagement.Areas.Identity.Pages.Account.Manage;
using CaseManagement.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.Statistics
{
    public class UsersStatisticsService : IUsersStatisticsService
    {
        private readonly ApplicationDbContext dbContext;

        public UsersStatisticsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MyStatisticsModel.MyStatisticsOutputModel> GetUserStatisticsForTodayAsync(string userId)
        {
            DateTime today = DateTime.UtcNow.Date;
            int thisMonth = DateTime.UtcNow.Month;
            int thisYear = DateTime.UtcNow.Year;

            MyStatisticsModel.MyStatisticsOutputModel result = await dbContext.Users
                .Where(u => u.Id == userId)
                .Select(u => new MyStatisticsModel.MyStatisticsOutputModel
                {
                    CreatedCasesLowPriority = u.Cases
                        .Where(c => c.Priority.Priority == "Low"
                            && c.CreatedOn.Date == today
                            && c.CreatedOn.Month == thisMonth
                            && c.CreatedOn.Year == thisYear)
                        .Count(),

                    CreatedCasesNormalPriority = u.Cases
                        .Where(c => c.Priority.Priority == "Normal"
                            && c.CreatedOn.Date == today
                            && c.CreatedOn.Month == thisMonth
                            && c.CreatedOn.Year == thisYear)
                        .Count(),

                    CreatedCasesUrgentPriority = u.Cases
                        .Where(c => c.Priority.Priority == "Urgent"
                            && c.CreatedOn.Date == today
                            && c.CreatedOn.Month == thisMonth
                            && c.CreatedOn.Year == thisYear)
                        .Count(),

                    CreatedCasesImmediatePriority = u.Cases
                        .Where(c => c.Priority.Priority == "Immediate"
                            && c.CreatedOn.Date == today
                            && c.CreatedOn.Month == thisMonth
                            && c.CreatedOn.Year == thisYear)
                        .Count(),

                    CreatedCasesNaPriority = u.Cases
                        .Where(c => c.Priority.Priority == "N/A"
                            && c.CreatedOn.Date == today
                            && c.CreatedOn.Month == thisMonth
                            && c.CreatedOn.Year == thisYear)
                        .Count(),

                    UpdatedCasesLowPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Low"
                            && mc.ModificationTime.Date == today
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    UpdatedCasesNormalPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Normal"
                            && mc.ModificationTime.Date == today
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    UpdatedCasesUrgentPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Urgent"
                            && mc.ModificationTime.Date == today
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    UpdatedCasesImmediatePriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Immediate"
                            && mc.ModificationTime.Date == today
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    UpdatedCasesNaPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "N/A"
                            && mc.ModificationTime.Date == today
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    ClosedCasesLowPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Low" && (mc.Case.Status.Status == "Closed" || mc.Case.Status.Status == "Resolved")
                            && mc.ModificationTime.Date == today
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    ClosedCasesNormalPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Normal" && (mc.Case.Status.Status == "Closed" || mc.Case.Status.Status == "Resolved")
                            && mc.ModificationTime.Date == today
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    ClosedCasesUrgentPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Urgent" && (mc.Case.Status.Status == "Closed" || mc.Case.Status.Status == "Resolved")
                            && mc.ModificationTime.Date == today
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    ClosedCasesImmediatePriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Immediate" && (mc.Case.Status.Status == "Closed" || mc.Case.Status.Status == "Resolved")
                            && mc.ModificationTime.Date == today
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    ClosedCasesNaPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "N/A" && (mc.Case.Status.Status == "Closed" || mc.Case.Status.Status == "Resolved")
                            && mc.ModificationTime.Date == today
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    CreatedTasks = u.Tasks
                        .Where(t => t.CreatedOn.Date == today
                            && t.CreatedOn.Month == thisMonth
                            && t.CreatedOn.Year == thisYear)
                        .Count(),

                    UpdatedTasks = u.ModifiedTasks
                        .Where(mt => mt.ModificationTime.Date == today
                            && mt.ModificationTime.Month == thisMonth
                            && mt.ModificationTime.Year == thisYear)
                        .Count(),

                    ClosedTasks = u.ModifiedTasks
                        .Where(mt => mt.Task.Status.Status == "COMPLETED" || mt.Task.Status.Status == "FAILED"
                            && mt.ModificationTime.Date == today
                            && mt.ModificationTime.Month == thisMonth
                            && mt.ModificationTime.Year == thisYear)
                        .Count(),
                })
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<MyStatisticsModel.MyStatisticsOutputModel> GetUserStatisticsForThisMonthAsync(string userId)
        {
            int thisMonth = DateTime.UtcNow.Month;
            int thisYear = DateTime.UtcNow.Year;

            MyStatisticsModel.MyStatisticsOutputModel result = await dbContext.Users
                .Where(u => u.Id == userId)
                .Select(u => new MyStatisticsModel.MyStatisticsOutputModel
                {
                    CreatedCasesLowPriority = u.Cases
                        .Where(c => c.Priority.Priority == "Low"
                            && c.CreatedOn.Month == thisMonth
                            && c.CreatedOn.Year == thisYear)
                        .Count(),

                    CreatedCasesNormalPriority = u.Cases
                        .Where(c => c.Priority.Priority == "Normal"
                            && c.CreatedOn.Month == thisMonth
                            && c.CreatedOn.Year == thisYear)
                        .Count(),

                    CreatedCasesUrgentPriority = u.Cases
                        .Where(c => c.Priority.Priority == "Urgent"
                            && c.CreatedOn.Month == thisMonth
                            && c.CreatedOn.Year == thisYear)
                        .Count(),

                    CreatedCasesImmediatePriority = u.Cases
                        .Where(c => c.Priority.Priority == "Immediate"
                            && c.CreatedOn.Month == thisMonth
                            && c.CreatedOn.Year == thisYear)
                        .Count(),

                    CreatedCasesNaPriority = u.Cases
                        .Where(c => c.Priority.Priority == "N/A"
                            && c.CreatedOn.Month == thisMonth
                            && c.CreatedOn.Year == thisYear)
                        .Count(),

                    UpdatedCasesLowPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Low"
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    UpdatedCasesNormalPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Normal"
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    UpdatedCasesUrgentPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Urgent"
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    UpdatedCasesImmediatePriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Immediate"
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    UpdatedCasesNaPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "N/A"
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    ClosedCasesLowPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Low" && (mc.Case.Status.Status == "Closed" || mc.Case.Status.Status == "Resolved")
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    ClosedCasesNormalPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Normal" && (mc.Case.Status.Status == "Closed" || mc.Case.Status.Status == "Resolved")
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    ClosedCasesUrgentPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Urgent" && (mc.Case.Status.Status == "Closed" || mc.Case.Status.Status == "Resolved")
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    ClosedCasesImmediatePriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Immediate" && (mc.Case.Status.Status == "Closed" || mc.Case.Status.Status == "Resolved")
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    ClosedCasesNaPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "N/A" && (mc.Case.Status.Status == "Closed" || mc.Case.Status.Status == "Resolved")
                            && mc.ModificationTime.Month == thisMonth
                            && mc.ModificationTime.Year == thisYear)
                        .Count(),

                    CreatedTasks = u.Tasks
                        .Where(t => t.CreatedOn.Month == thisMonth
                            && t.CreatedOn.Year == thisYear)
                        .Count(),

                    UpdatedTasks = u.ModifiedTasks
                        .Where(mt => mt.ModificationTime.Month == thisMonth
                            && mt.ModificationTime.Year == thisYear)
                        .Count(),

                    ClosedTasks = u.ModifiedTasks
                        .Where(mt => mt.Task.Status.Status == "COMPLETED" || mt.Task.Status.Status == "FAILED"
                            && mt.ModificationTime.Month == thisMonth
                            && mt.ModificationTime.Year == thisYear)
                        .Count(),
                })
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<MyStatisticsModel.MyStatisticsOutputModel> GetUserStatisticsForThisWeekAsync(string userId)
        {
            DateTime startOfWeek = DateTime.Now.StartOfWeek();
            DateTime endOfWeek = DateTime.Now.EndOfWeek();

            MyStatisticsModel.MyStatisticsOutputModel result = await dbContext.Users
                .Where(u => u.Id == userId)
                .Select(u => new MyStatisticsModel.MyStatisticsOutputModel
                {
                    CreatedCasesLowPriority = u.Cases
                        .Where(c => c.Priority.Priority == "Low"
                            && c.CreatedOn >= startOfWeek
                            && c.CreatedOn <= endOfWeek)
                        .Count(),

                    CreatedCasesNormalPriority = u.Cases
                        .Where(c => c.Priority.Priority == "Normal"
                            && c.CreatedOn >= startOfWeek
                            && c.CreatedOn <= endOfWeek)
                        .Count(),

                    CreatedCasesUrgentPriority = u.Cases
                        .Where(c => c.Priority.Priority == "Urgent"
                            && c.CreatedOn >= startOfWeek
                            && c.CreatedOn <= endOfWeek)
                        .Count(),

                    CreatedCasesImmediatePriority = u.Cases
                        .Where(c => c.Priority.Priority == "Immediate"
                            && c.CreatedOn >= startOfWeek
                            && c.CreatedOn <= endOfWeek)
                        .Count(),

                    CreatedCasesNaPriority = u.Cases
                        .Where(c => c.Priority.Priority == "N/A"
                            && c.CreatedOn >= startOfWeek
                            && c.CreatedOn <= endOfWeek)
                        .Count(),

                    UpdatedCasesLowPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Low"
                            && mc.ModificationTime >= startOfWeek
                            && mc.ModificationTime <= endOfWeek)
                        .Count(),

                    UpdatedCasesNormalPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Normal"
                            && mc.ModificationTime >= startOfWeek
                            && mc.ModificationTime <= endOfWeek)
                        .Count(),

                    UpdatedCasesUrgentPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Urgent"
                            && mc.ModificationTime >= startOfWeek
                            && mc.ModificationTime <= endOfWeek)
                        .Count(),

                    UpdatedCasesImmediatePriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Immediate"
                            && mc.ModificationTime >= startOfWeek
                            && mc.ModificationTime <= endOfWeek)
                        .Count(),

                    UpdatedCasesNaPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "N/A"
                            && mc.ModificationTime >= startOfWeek
                            && mc.ModificationTime <= endOfWeek)
                        .Count(),

                    ClosedCasesLowPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Low" && (mc.Case.Status.Status == "Closed" || mc.Case.Status.Status == "Resolved")
                            && mc.ModificationTime >= startOfWeek
                            && mc.ModificationTime <= endOfWeek)
                        .Count(),

                    ClosedCasesNormalPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Normal" && (mc.Case.Status.Status == "Closed" || mc.Case.Status.Status == "Resolved")
                            && mc.ModificationTime >= startOfWeek
                            && mc.ModificationTime <= endOfWeek)
                        .Count(),

                    ClosedCasesUrgentPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Urgent" && (mc.Case.Status.Status == "Closed" || mc.Case.Status.Status == "Resolved")
                            && mc.ModificationTime >= startOfWeek
                            && mc.ModificationTime <= endOfWeek)
                        .Count(),

                    ClosedCasesImmediatePriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "Immediate" && (mc.Case.Status.Status == "Closed" || mc.Case.Status.Status == "Resolved")
                            && mc.ModificationTime >= startOfWeek
                            && mc.ModificationTime <= endOfWeek)
                        .Count(),

                    ClosedCasesNaPriority = u.ModifiedCases
                        .Where(mc => mc.Case.Priority.Priority == "N/A" && (mc.Case.Status.Status == "Closed" || mc.Case.Status.Status == "Resolved")
                            && mc.ModificationTime >= startOfWeek
                            && mc.ModificationTime <= endOfWeek)
                        .Count(),

                    CreatedTasks = u.Tasks
                        .Where(t => t.CreatedOn >= startOfWeek
                            && t.CreatedOn <= endOfWeek)
                        .Count(),

                    UpdatedTasks = u.ModifiedTasks
                        .Where(mt => mt.ModificationTime >= startOfWeek
                            && mt.ModificationTime <= endOfWeek)
                        .Count(),

                    ClosedTasks = u.ModifiedTasks
                        .Where(mt => mt.Task.Status.Status == "COMPLETED" || mt.Task.Status.Status == "FAILED"
                            && mt.ModificationTime >= startOfWeek
                            && mt.ModificationTime <= endOfWeek)
                        .Count(),
                })
                .FirstOrDefaultAsync();

            return result;
        }
    }
}
