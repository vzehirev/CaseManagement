using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.Output
{
    public class TaskOutputModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Owner { get; set; }
    }
}
