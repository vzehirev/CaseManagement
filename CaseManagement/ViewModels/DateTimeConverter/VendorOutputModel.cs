using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.DateTimeConverter
{
    public class VendorOutputModel
    {
        public string Name { get; set; }

        public IEnumerable<RegionOutputModel> Regions { get; set; }
    }
}
