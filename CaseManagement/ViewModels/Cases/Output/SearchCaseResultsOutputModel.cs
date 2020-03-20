namespace CaseManagement.ViewModels.Cases.Output
{
    public class SearchCaseResultsOutputModel
    {
        public string SearchedCaseNumber { get; set; }

        public CaseOutputModel[] Results { get; set; }
    }
}
