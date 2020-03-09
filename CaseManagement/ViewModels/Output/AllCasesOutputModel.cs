using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.Output
{
    public class AllCasesOutputModel
    {
        public string SearchedCaseNumber { get; set; }
        public CaseOutputModel[] Cases { get; set; }
    }
}
