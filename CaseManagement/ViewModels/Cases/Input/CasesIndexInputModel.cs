namespace CaseManagement.ViewModels.Cases.Input
{
    public class CasesIndexInputModel
    {
        public int Page { get; set; }

        public string OrderBy { get; set; }

        public int[] SelectedStatuses { get; set; }

        public int[] SelectedPriorities { get; set; }
    }
}
