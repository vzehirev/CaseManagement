using System;

namespace CaseManagement.ViewModels.Cases.Output
{
    public class CaseUpdatesOutputModel
    {
        public string CaseNumber { get; set; }
        public DateTime TimeOfUpdate { get; set; }
        public string User { get; set; }
        public string Updates { get; set; }
    }
}
