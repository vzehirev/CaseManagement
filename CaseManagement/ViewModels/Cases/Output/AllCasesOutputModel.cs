namespace CaseManagement.ViewModels.Cases.Output
{
    public class AllCasesOutputModel
    {
        public int AllCases { get; set; }

        public int CurrentPage { get; set; }

        public int LastPage { get; set; }

        public CaseOutputModel[] Cases { get; set; }

        public string OrderedBy { get; set; }
    }
}
