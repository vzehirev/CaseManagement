using CaseManagement.Enums;
using CaseManagement.ViewModels.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.Reports
{
    public class AgentsActivitiesViewModel
    {
        public string UserId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public TimeFrameEnum TimeFrame { get; set; }

        public IEnumerable<ReportsAgentsActivitiesSelectedAgentViewModel> SelectedAgents { get; set; }

        public IEnumerable<ReportsAgentsActivitiesAgentViewModel> AllAgents  { get; set; }
    }
}
