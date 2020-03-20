using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.Cases.Output
{
    public class SearchCaseResultsOutputModel
    {
        public string SearchedCaseNumber { get; set; }

        public CaseOutputModel[] Results { get; set; }
    }
}
