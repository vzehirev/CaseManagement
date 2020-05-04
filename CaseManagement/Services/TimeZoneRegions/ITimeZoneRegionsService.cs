using CaseManagement.ViewModels.TimeZoneRegions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.TimeZoneRegions
{
    public interface ITimeZoneRegionsService
    {
        Task<int> AddTimeZoneRegionAsync(string name);

        Task<IEnumerable<AddDcTimeZoneRegionSelectViewModel>> GetAllTimeZoneRegionsAsync();
    }
}
