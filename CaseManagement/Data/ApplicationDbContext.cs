using CaseManagement.Models;
using CaseManagement.Models.CaseModels;
using CaseManagement.Models.TaskModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CaseManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<CaseType>().HasData(
        //        new CaseType { Type = "DCM Regional Ticket" },
        //        new CaseType { Type = "Server Maintenance Break and Fix (B+F)" },
        //        new CaseType { Type = "Time Critical Request (Incident)" },
        //        new CaseType { Type = "Time Critical Request (Request)" },
        //        new CaseType { Type = "Requesting DC access" },
        //        new CaseType { Type = "Requesting Goods Delivery to DCs" },
        //        new CaseType { Type = "Requesting the announcement of System News" },
        //        new CaseType { Type = "Requesting different kinds of onsite support activities" },
        //        new CaseType { Type = "Other" }
        //        );

        //    base.OnModelCreating(builder);
        //}

        public DbSet<Case> Cases { get; set; }

        public DbSet<CaseType> CaseTypes { get; set; }

        public DbSet<CasePhase> CasePhases { get; set; }

        public DbSet<CaseStatus> CaseStatuses { get; set; }

        public DbSet<CasePriority> CasePriorities { get; set; }

        public DbSet<ServiceArea> ServiceAreas { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<CaseTask> Tasks { get; set; }

        public DbSet<TaskType> TaskTypes { get; set; }

        public DbSet<TaskStatus> TaskStatuses { get; set; }

        public DbSet<FieldModification> FieldModifications { get; set; }

        public DbSet<CaseModificationLogRecord> CaseModificationLogRecords { get; set; }

        public DbSet<TaskModificationLogRecord> TaskModificationLogRecords { get; set; }
    }
}
