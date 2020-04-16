using System;

namespace CaseManagement.ViewModels.Agents
{
    public class AgentOutputModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime LastActivityDate { get; set; }
    }
}
