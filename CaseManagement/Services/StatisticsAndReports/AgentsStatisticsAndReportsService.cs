using CaseManagement.Areas.Identity.Pages.Account.Manage;
using CaseManagement.Data;
using CaseManagement.Enums;
using CaseManagement.ViewModels.Agents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CaseManagement.Areas.Identity.Pages.Account.Manage.MyStatisticsModel;

namespace CaseManagement.Services.StatisticsAndReports
{
    public class AgentsStatisticsAndReportsService : IAgentsStatisticsAndReportsService
    {
        private readonly ApplicationDbContext dbContext;

        public AgentsStatisticsAndReportsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MyStatisticsViewModel> GetAgentsStatisticsAsync(string userId, DateTime fromDate, DateTime toDate)
        {
            var result = await this.dbContext.Users
                .Where(u => u.Id == userId)
                .Select(u => new MyStatisticsViewModel
                {
                    CreatedCasesLowPriority = u.Cases
                        .Count(c => c.PriorityId == this.dbContext.CasePriorities
                        .FirstOrDefault(x => x.Priority.ToLower() == "low").Id
                            && c.CreatedOn >= fromDate
                            && c.CreatedOn <= toDate),

                    CreatedCasesNormalPriority = u.Cases
                        .Count(c => c.PriorityId == this.dbContext.CasePriorities
                        .FirstOrDefault(x => x.Priority.ToLower() == "normal").Id
                            && c.CreatedOn >= fromDate
                            && c.CreatedOn <= toDate),

                    CreatedCasesUrgentPriority = u.Cases
                        .Count(c => c.PriorityId == this.dbContext.CasePriorities
                        .FirstOrDefault(x => x.Priority.ToLower() == "urgent").Id
                            && c.CreatedOn >= fromDate
                            && c.CreatedOn <= toDate),

                    CreatedCasesImmediatePriority = u.Cases
                        .Count(c => c.PriorityId == this.dbContext.CasePriorities
                        .FirstOrDefault(x => x.Priority.ToLower() == "immediate").Id
                            && c.CreatedOn >= fromDate
                            && c.CreatedOn <= toDate),

                    CreatedCasesNaPriority = u.Cases
                        .Count(c => c.PriorityId == this.dbContext.CasePriorities
                        .FirstOrDefault(x => x.Priority.ToLower() == "n/a").Id
                            && c.CreatedOn >= fromDate
                            && c.CreatedOn <= toDate),

                    UpdatedCasesLowPriority = u.ModifiedCases
                        .Count(x => x.Case.PriorityId == this.dbContext.CasePriorities
                        .FirstOrDefault(x => x.Priority.ToLower() == "low").Id
                            && x.ModificationTime >= fromDate
                            && x.ModificationTime <= toDate),

                    UpdatedCasesNormalPriority = u.ModifiedCases
                        .Count(x => x.Case.PriorityId == this.dbContext.CasePriorities
                        .FirstOrDefault(x => x.Priority.ToLower() == "normal").Id
                            && x.ModificationTime >= fromDate
                            && x.ModificationTime <= toDate),

                    UpdatedCasesUrgentPriority = u.ModifiedCases
                        .Count(x => x.Case.PriorityId == this.dbContext.CasePriorities
                        .FirstOrDefault(x => x.Priority.ToLower() == "urgent").Id
                            && x.ModificationTime >= fromDate
                            && x.ModificationTime <= toDate),

                    UpdatedCasesImmediatePriority = u.ModifiedCases
                        .Count(x => x.Case.PriorityId == this.dbContext.CasePriorities
                        .FirstOrDefault(x => x.Priority.ToLower() == "immediate").Id
                            && x.ModificationTime >= fromDate
                            && x.ModificationTime <= toDate),

                    UpdatedCasesNaPriority = u.ModifiedCases
                        .Count(x => x.Case.PriorityId == this.dbContext.CasePriorities
                        .FirstOrDefault(x => x.Priority.ToLower() == "n/a").Id
                            && x.ModificationTime >= fromDate
                            && x.ModificationTime <= toDate),

                    ClosedCasesLowPriority = u.ModifiedCases
                        .Count(x => x.Case.PriorityId == this.dbContext.CasePriorities.FirstOrDefault(x => x.Priority.ToLower() == "low").Id
                            && (x.Case.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "closed").Id
                                || x.Case.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "resolved").Id)
                            && x.ModificationTime >= fromDate
                            && x.ModificationTime <= toDate),

                    ClosedCasesNormalPriority = u.ModifiedCases
                        .Count(x => x.Case.PriorityId == this.dbContext.CasePriorities.FirstOrDefault(x => x.Priority.ToLower() == "normal").Id
                            && (x.Case.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "closed").Id
                                || x.Case.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "resolved").Id)
                            && x.ModificationTime >= fromDate
                            && x.ModificationTime <= toDate),

                    ClosedCasesUrgentPriority = u.ModifiedCases
                        .Count(x => x.Case.PriorityId == this.dbContext.CasePriorities.FirstOrDefault(x => x.Priority.ToLower() == "urgent").Id
                            && (x.Case.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "closed").Id
                                || x.Case.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "resolved").Id)
                            && x.ModificationTime >= fromDate
                            && x.ModificationTime <= toDate),

                    ClosedCasesImmediatePriority = u.ModifiedCases
                        .Count(x => x.Case.PriorityId == this.dbContext.CasePriorities.FirstOrDefault(x => x.Priority.ToLower() == "immediate").Id
                            && (x.Case.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "closed").Id
                                || x.Case.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "resolved").Id)
                            && x.ModificationTime >= fromDate
                            && x.ModificationTime <= toDate),

                    ClosedCasesNaPriority = u.ModifiedCases
                        .Count(x => x.Case.PriorityId == this.dbContext.CasePriorities.FirstOrDefault(x => x.Priority.ToLower() == "n/a").Id
                            && (x.Case.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "closed").Id
                                || x.Case.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "resolved").Id)
                            && x.ModificationTime >= fromDate
                            && x.ModificationTime <= toDate),

                    CreatedTasks = u.Tasks
                        .Count(t => t.CreatedOn.Date >= fromDate
                            && t.CreatedOn <= toDate),

                    UpdatedTasks = u.ModifiedTasks
                        .Count(x => x.ModificationTime >= fromDate
                            && x.ModificationTime <= toDate),

                    ClosedTasks = u.ModifiedTasks
                        .Count(x => (x.Task.StatusId == this.dbContext.TaskStatuses.FirstOrDefault(x => x.Status == "completed").Id
                                || x.Task.StatusId == this.dbContext.TaskStatuses.FirstOrDefault(x => x.Status == "failed").Id)
                            && x.ModificationTime >= fromDate
                            && x.ModificationTime <= toDate),
                })
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<ReportsAgentsActivitiesSelectedAgentViewModel>> GetAgentsActivitiesReportsAsync(string userId, DateTime fromDate, DateTime toDate)
        {
            var query = this.dbContext.Users.AsQueryable();

            // If there's userId get info only for this agent, otherwise for all agents.
            if (userId != null)
            {
                query = query.Where(u => u.Id == userId);
            }

            var result = await query
                .Select(u => new ReportsAgentsActivitiesSelectedAgentViewModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    FullName = string.Join(' ', u.FirstName, u.LastName),

                    CreatedCases = this.dbContext.Cases
                        .Count(c => c.UserId == u.Id && c.CreatedOn >= fromDate && c.CreatedOn <= toDate),

                    UpdatedCases = this.dbContext.CaseModificationLogRecords
                        .Where(x => x.UserId == u.Id && x.ModificationTime >= fromDate && x.ModificationTime <= toDate)
                        .Select(x => x.CaseId)
                        .Distinct()
                        .Count(),

                    OpenCases = this.dbContext.Cases
                        .Count(c => c.UserId == u.Id
                            && c.CreatedOn >= fromDate
                            && c.CreatedOn <= toDate
                            && c.StatusId != this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "resolved").Id
                            && c.StatusId != this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "closed").Id
                            && c.StatusId != this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "other").Id
                            && c.StatusId != this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "n/a").Id),

                    ClosedCases = this.dbContext.Cases
                            .Count(c => c.UserId == u.Id
                                && c.CreatedOn >= fromDate
                                && c.CreatedOn <= toDate
                                && (c.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "resolved").Id
                                    || c.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "closed").Id)
                                && c.LastModified == null)
                        + this.dbContext.CaseModificationLogRecords
                            .Where(x => x.UserId == u.Id
                                && x.ModificationTime >= fromDate
                                && x.ModificationTime <= toDate
                                && x.ModifiedFields.Any(x => x.FieldName.ToLower() == "status"
                                && (x.NewValue.ToLower() == "resolved" || x.NewValue.ToLower() == "closed"))
                                && (x.Case.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "resolved").Id
                                    || x.Case.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "closed").Id))
                            .Select(x => x.CaseId)
                            .Distinct()
                            .Count(),

                    OtherCasesStatus = this.dbContext.Cases
                            .Count(c => c.UserId == u.Id
                                && c.CreatedOn >= fromDate
                                && c.CreatedOn <= toDate
                                && (c.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "other").Id
                                    || c.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "n/a").Id)
                                && c.LastModified == null)
                        + this.dbContext.CaseModificationLogRecords
                            .Where(x => x.UserId == u.Id
                                && x.ModificationTime >= fromDate
                                && x.ModificationTime <= toDate
                                && x.ModifiedFields.Any(x => x.FieldName.ToLower() == "status"
                                && (x.NewValue.ToLower() == "other" || x.NewValue.ToLower() == "n/a"))
                                && (x.Case.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "other").Id
                                    || x.Case.StatusId == this.dbContext.CaseStatuses.FirstOrDefault(x => x.Status.ToLower() == "n/a").Id))
                            .Select(x => x.CaseId)
                            .Distinct()
                            .Count(),

                    CreatedTasks = this.dbContext.Tasks
                        .Count(t => t.UserId == u.Id && t.CreatedOn >= fromDate && t.CreatedOn <= toDate),

                    UpdatedTasks = this.dbContext.TaskModificationLogRecords
                        .Where(x => x.UserId == u.Id && x.ModificationTime >= fromDate && x.ModificationTime <= toDate)
                        .Select(x => x.TaskId)
                        .Distinct()
                        .Count(),

                    OpenTasks = this.dbContext.Tasks
                        .Count(t => t.UserId == u.Id
                            && t.CreatedOn >= fromDate
                            && t.CreatedOn <= toDate
                            && t.StatusId != this.dbContext.TaskStatuses.FirstOrDefault(x => x.Status.ToLower() == "completed").Id
                            && t.StatusId != this.dbContext.TaskStatuses.FirstOrDefault(x => x.Status.ToLower() == "failed").Id),

                    ClosedTasks = this.dbContext.Tasks
                            .Count(t => t.UserId == u.Id
                                && t.CreatedOn >= fromDate
                                && t.CreatedOn <= toDate
                                && (t.StatusId == this.dbContext.TaskStatuses.FirstOrDefault(x => x.Status.ToLower() == "completed").Id
                                    || t.StatusId == this.dbContext.TaskStatuses.FirstOrDefault(x => x.Status.ToLower() == "failed").Id)
                                && t.LastModified == null)
                        + this.dbContext.TaskModificationLogRecords
                            .Where(x => x.UserId == u.Id
                                && x.ModificationTime >= fromDate
                                && x.ModificationTime <= toDate
                                && x.ModifiedFields.Any(x => x.FieldName.ToLower() == "status"
                                && (x.NewValue.ToLower() == "completed" || x.NewValue.ToLower() == "failed"))
                                && (x.Task.StatusId == this.dbContext.TaskStatuses.FirstOrDefault(x => x.Status.ToLower() == "completed").Id
                                    || x.Task.StatusId == this.dbContext.TaskStatuses.FirstOrDefault(x => x.Status.ToLower() == "failed").Id))
                            .Select(x => x.TaskId)
                            .Distinct()
                            .Count(),

                    OtherTasksStatus = this.dbContext.Tasks
                            .Count(t => t.UserId == u.Id
                                && t.CreatedOn >= fromDate
                                && t.CreatedOn <= toDate
                                && t.StatusId == null
                                && t.LastModified == null)
                        + this.dbContext.TaskModificationLogRecords
                            .Where(x => x.UserId == u.Id
                                && x.ModificationTime >= fromDate
                                && x.ModificationTime <= toDate
                                && x.ModifiedFields.Any(x => x.FieldName.ToLower() == "status"
                                && x.NewValue == null)
                                && x.Task.StatusId == null)
                            .Select(x => x.TaskId)
                            .Distinct()
                            .Count(),
                })
                .ToArrayAsync();

            return result;
        }
    }
}
