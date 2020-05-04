using CaseManagement.Data;
using CaseManagement.Models.Datacenters;
using CaseManagement.ViewModels.Datacenters;
using CaseManagement.ViewModels.DatacentersTimes;
using CaseManagement.ViewModels.TimeZoneRegions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.DatacentersService
{
    public class DatacentersService : IDatacentersService
    {
        private readonly ApplicationDbContext dbContext;

        public DatacentersService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddDcAsync(string name, string tag, string tzIanaName, int timeZoneRegionId,
            int? openingAtDay, TimeSpan openingAtTime, int? closingAtDay, TimeSpan closingAtTime)
        {
            var dc = new Datacenter
            {
                Name = name,
                Tag = tag,
                TzIanaName = tzIanaName,
                TimeZoneRegionId = timeZoneRegionId,
                OpeningAtDay = openingAtDay,
                OpeningAtTime = openingAtTime,
                ClosingAtDay = closingAtDay,
                ClosingAtTime = closingAtTime,
            };

            this.dbContext.Datacenters.Add(dc);
            await this.dbContext.SaveChangesAsync();

            return dc.Id;
        }

        public async Task<DatacentersTimesIndexOutputModel> GetAllRegionsAndTheirTimezonesAsync()
        {
            var result = new DatacentersTimesIndexOutputModel();
            result.TimeZoneRegions = await dbContext
                .TimeZoneRegions
                .Select(tr => new TimeZoneRegionViewModel
                {
                    Name = tr.Name,
                    Datacenters = tr.TimeZones
                    .OrderBy(t => t.Name)
                    .Select(t => new DatacenterViewModel
                    {
                        Name = t.Name,
                        Tag = t.Tag,
                        TzIanaName = t.TzIanaName,
                        OpeningAtDay = t.OpeningAtDay,
                        OpeningAtTime = t.OpeningAtTime,
                        ClosingAtDay = t.ClosingAtDay,
                        ClosingAtTime = t.ClosingAtTime,
                    })
                    .ToArray(),
                })
                .ToArrayAsync();

            return result;
        }
    }
}
