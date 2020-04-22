using CaseManagement.ViewModels.Timezones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.TimezoneRegions
{
    public class TimezoneRegionOutputModel
    {
        public string Name { get; set; }

        public IEnumerable<TimezoneOutputModel> Timezones { get; set; }
    }
}
