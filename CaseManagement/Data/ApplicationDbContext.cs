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

        public DbSet<Announcement> Announcements { get; set; }
    }
}
