using CaseManagement.ViewModels.CasePriorities.Output;
using CaseManagement.ViewModels.CaseStatuses.Output;

namespace CaseManagement.ViewModels.Cases.Output
{
    public class AllCasesOutputModel
    {
        public int AllCases { get; set; }

        public int CurrentPage { get; set; }

        public int LastPage { get; set; }

        public CaseOutputModel[] Cases { get; set; }

        public string OrderedBy { get; set; }

        public string Announcements { get; set; }

        public CaseStatusOuputModel[] AllAvailableCaseStatuses { get; set; }

        public int[] SelectedStatuses { get; set; }

        public int[] SelectedPriorities { get; set; }

        public CasePriorityOutputModel[] AllAvailableCasePriorities { get; set; }
    }
}
