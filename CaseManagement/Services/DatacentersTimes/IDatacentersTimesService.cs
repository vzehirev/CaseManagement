using CaseManagement.ViewModels.DatacentersTimes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.DatacentersTimesService
{
    public interface IDatacentersTimesService
    {
        Task<DatacentersTimesIndexOutputModel> GetAllRegionsAndTheirTimezonesAsync();
    }
}
