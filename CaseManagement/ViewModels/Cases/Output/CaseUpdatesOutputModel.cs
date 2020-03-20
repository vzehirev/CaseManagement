using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
