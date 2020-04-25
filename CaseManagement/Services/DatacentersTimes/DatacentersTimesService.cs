using CaseManagement.Data;
using CaseManagement.ViewModels.DatacentersTimes;
using CaseManagement.ViewModels.TimezoneRegions;
using CaseManagement.ViewModels.Timezones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.DatacentersTimesService
{
    public class DatacentersTimesService : IDatacentersTimesService
    {
        private readonly ApplicationDbContext dbContext;

        public DatacentersTimesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<DatacentersTimesIndexOutputModel> GetAllRegionsAndTheirTimezonesAsync()
        {
            var result = new DatacentersTimesIndexOutputModel();
            result.TimezoneRegions = await dbContext
                .TimezoneRegions
                .Select(tr => new TimezoneRegionOutputModel
                {
                    Name = tr.Name,
                    Timezones = tr.Timezones
                    .OrderBy(t => t.Name)
                    .Select(t => new TimezoneOutputModel
                    {
                        Name = t.Name,
                        Tag = t.Tag,
                        TzIanaName = t.TzIanaName,
                    })
                    .ToArray(),
                })
                .ToArrayAsync();

            return result;
        }
    }
}
