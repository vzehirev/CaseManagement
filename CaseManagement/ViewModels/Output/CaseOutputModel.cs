using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.Output
{
    public class CaseOutputModel
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string CaseNumber { get; set; }
        public string Subject { get; set; }
        public string CaseStatus { get; set; }
        public string CasePriority { get; set; }
        public string Owner { get; set; }
    }
}
