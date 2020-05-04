using CaseManagement.ViewModels.DateTimeConverter;
using CaseManagement.ViewModels.TimeZoneRegions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.DatacentersTimes
{
    public class DatacentersTimesIndexOutputModel
    {
        public IEnumerable<TimeZoneRegionViewModel> TimeZoneRegions { get; set; }

        public VendorsWithRegionsOutputModel VendorsWithRegions { get; set; }
    }
}
