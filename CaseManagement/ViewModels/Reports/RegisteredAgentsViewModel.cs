using CaseManagement.ViewModels.Agents;
using System.Collections.Generic;

namespace CaseManagement.ViewModels.Reports
{
    public class RegisteredAgentsViewModel
    {
        public IEnumerable<ReportsRegisteredAgentsAgentViewModel> AllAgents { get; set; }
    }
}
