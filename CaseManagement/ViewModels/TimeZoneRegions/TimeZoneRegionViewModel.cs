using CaseManagement.ViewModels.Datacenters;
using System.Collections.Generic;

namespace CaseManagement.ViewModels.TimeZoneRegions
{
    public class TimeZoneRegionViewModel
    {
        public string Name { get; set; }

        public IEnumerable<DatacenterViewModel> Datacenters { get; set; }
    }
}
