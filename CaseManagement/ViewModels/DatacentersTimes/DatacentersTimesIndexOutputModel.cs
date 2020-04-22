using CaseManagement.ViewModels.TimezoneRegions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.DatacentersTimes
{
    public class DatacentersTimesIndexOutputModel
    {
        public IEnumerable<TimezoneRegionOutputModel> TimezoneRegions { get; set; }
    }
}
