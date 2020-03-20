using System;

namespace CaseManagement.ViewModels.Tasks.Output
{
    public class TaskOutputModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Action { get; set; }

        public string NextAction { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public string Agent { get; set; }
    }
}
