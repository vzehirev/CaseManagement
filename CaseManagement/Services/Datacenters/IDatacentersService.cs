using CaseManagement.ViewModels.DatacentersTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.DatacentersService
{
    public interface IDatacentersService
    {
        Task<DatacentersTimesIndexOutputModel> GetAllRegionsAndTheirTimezonesAsync();

        Task<int> AddDcAsync(string name, string tag, string tzIanaName, int timeZoneRegionId,
            int? openingAtDay, TimeSpan openingAtTime, int? closingAtDay, TimeSpan closingAtTime);
    }
}
