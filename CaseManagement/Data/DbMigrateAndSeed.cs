using CaseManagement.Models.CaseModels;
using CaseManagement.Models.TaskModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseManagement.Data
{
    public class DbMigrateAndSeed
    {
        private readonly ApplicationDbContext dbContext;

        public DbMigrateAndSeed(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void MigrateAndSeed()
        {
            this.dbContext.Database.Migrate();

            this.SeedCaseTypes();
            this.SeedCaseStatuses();
            this.SeedCasePhases();
            this.SeedCasePriorities();
            this.SeedTaskTypes();
            this.SeedTaskStatuses();
            this.SeedServices();

            return;
        }

        private int SeedCaseTypes()
        {
            var caseTypes = new string[]
            {
                "DCM Regional Ticket",
                "Server Maintenance Break and Fix (B+F)",
                "Time Critical Request (Incident)",
                "Time Critical Request (Request)",
                "Requesting DC access",
                "Requesting Goods Delivery to DCs",
                "Requesting the announcement of System News",
                "Requesting different kinds of onsite support activities",
                "Other",
            };

            var caseTypesToSeed = new List<CaseType>();

            foreach (var caseType in caseTypes)
            {
                caseTypesToSeed.Add(new CaseType { Type = caseType });
            }

            this.dbContext.CaseTypes.AddRange(caseTypesToSeed);

            var result = this.dbContext.SaveChanges();

            return result;
        }

        private int SeedCasePhases()
        {
            var casePhases = new string[]
            {
                "Evaluate",
                "Plan & Prepare",
                "Execute",
                "Post steps",
            };

            var casePhasesToSeed = new List<CasePhase>();

            foreach (var casePhase in casePhases)
            {
                casePhasesToSeed.Add(new CasePhase { Phase = casePhase });
            }

            this.dbContext.CasePhases.AddRange(casePhasesToSeed);

            var result = this.dbContext.SaveChanges();

            return result;
        }

        private int SeedCaseStatuses()
        {
            var caseStatuses = new string[]
            {
                "New",
                "Waiting",
                "In Process",
                "Resolved",
                "On-hold",
                "Closed",
                "Other",
            };

            var caseStatusesToSeed = new List<CaseStatus>();

            foreach (var caseStatus in caseStatuses)
            {
                caseStatusesToSeed.Add(new CaseStatus { Status = caseStatus });
            }

            this.dbContext.CaseStatuses.AddRange(caseStatusesToSeed);

            var result = this.dbContext.SaveChanges();

            return result;
        }

        private int SeedCasePriorities()
        {
            var casePriorities = new string[]
            {
                "Low",
                "Normal",
                "Urgent",
                "Immediate",
            };

            var casePrioritiesToSeed = new List<CasePriority>();

            foreach (var casePriority in casePriorities)
            {
                casePrioritiesToSeed.Add(new CasePriority { Priority = casePriority });
            }

            this.dbContext.CasePriorities.AddRange(casePrioritiesToSeed);

            var result = this.dbContext.SaveChanges();

            return result;
        }

        private int SeedServices()
        {
            var services = new string[]
            {
                "HW_MAINTENANCE_SUPPORT_CISCO",
                "HW_MAINTENANCE_SUPPORT_IBM",
                "DC_GOODS_DELIVERY",
                "DC_SUPPORT_SERVICES",
                "DC_NETWORK_SERVICES",
                "HW_MAINTENANCE_SUPPORT_FUJITSU",
                "HW_MAINTENANCE_SUPPORT_HP",
                "HW_MAINTENANCE_SUPPORT_CISCO",
                "HW_MAINTENANCE_SUPPORT_OTHER",
                "DC_NETWORK_SERVICES_RH",
                "CO_LOCATION_DC_ACCESS",
                "DC_SMARTHANDS_OTHERS",
                "DC_BUILD_CHANGE",
                "DC_ASSET_CLEARANCE",
                "DC_HDD_SHIPMENT",
                "DC_SUPPORT_SERVICES_RH_ONLY_COLORADO",
                "DC_ASSET_RELOCATION",
                "DC_ACCESS_REQUESTS_ADAM_PIT",
                "DC_ASSET_DECOM",
                "Other",
            };

            var servicesToSeed = new List<Service>();

            foreach (var service in services)
            {
                servicesToSeed.Add(new Service { ServiceName = service });
            }

            this.dbContext.Services.AddRange(servicesToSeed);

            var result = this.dbContext.SaveChanges();

            return result;
        }

        private int SeedTaskTypes()
        {
            var taskTypes = new string[]
            {
                "Dispatching DCM Regional tickets",
                "Fetch the logs",
                "Create Vendor Case",
                "Shipment Request",
                "Access Request",
                "Onsite Support Activities",
                "DC Escort Request",
                "Other",
            };

            var taskTypesToSeed = new List<TaskType>();

            foreach (var taskType in taskTypes)
            {
                taskTypesToSeed.Add(new TaskType { Type = taskType });
            }

            this.dbContext.TaskTypes.AddRange(taskTypesToSeed);

            var result = this.dbContext.SaveChanges();

            return result;
        }

        private int SeedTaskStatuses()
        {
            var taskStatuses = new string[]
            {
                "WAITING",
                "READY",
                "WORKING",
                "COMPLETED",
                "FAILED",
            };

            var taskStatusesToSeed = new List<Models.TaskModels.TaskStatus>();

            foreach (var taskStatus in taskStatuses)
            {
                taskStatusesToSeed.Add(new Models.TaskModels.TaskStatus { Status = taskStatus });
            }

            this.dbContext.TaskStatuses.AddRange(taskStatusesToSeed);

            var result = this.dbContext.SaveChanges();

            return result;
        }
    }
}
