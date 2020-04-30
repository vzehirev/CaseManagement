using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.Agents
{
    public class ReportsAgentsActivitiesSelectedAgentViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public int CreatedCases { get; set; }

        public int UpdatedCases { get; set; }

        public int OpenCases { get; set; }

        public int ClosedCases { get; set; }

        public int OtherCasesStatus { get; set; }

        public int CreatedTasks { get; set; }

        public int UpdatedTasks { get; set; }

        public int OpenTasks { get; set; }

        public int ClosedTasks { get; set; }

        public int OtherTasksStatus { get; set; }
    }
}
