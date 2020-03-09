using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.Output
{
    public class CaseOutputModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Number { get; set; }

        public string Subject { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }
        
        public string Owner { get; set; }
    }
}
