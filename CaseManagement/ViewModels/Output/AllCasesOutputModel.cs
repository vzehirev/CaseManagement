namespace CaseManagement.ViewModels.Output
{
    public class AllCasesOutputModel
    {
        public string SearchedCaseNumber { get; set; }

        public CaseOutputModel[] Cases { get; set; }
    }
}
