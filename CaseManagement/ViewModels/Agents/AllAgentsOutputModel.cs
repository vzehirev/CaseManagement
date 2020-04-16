using System.Collections.Generic;

namespace CaseManagement.ViewModels.Agents
{
    public class AllAgentsOutputModel
    {
        public IEnumerable<AgentOutputModel> Agents { get; set; }
    }
}
