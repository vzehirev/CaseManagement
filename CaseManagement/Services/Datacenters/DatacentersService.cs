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

        public async Task<int> DeleteDcAsync(int id)
        {
            var result = 0;
            var dc = await this.dbContext.Datacenters.FirstOrDefaultAsync(x => x.Id == id);

            if (dc != null)
            {
                this.dbContext.Datacenters.Remove(dc);
                result = await this.dbContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<DatacentersTimesIndexOutputModel> GetAllRegionsAndTheirDatacentersAsync()
        {
            var result = new DatacentersTimesIndexOutputModel();
            result.TimeZoneRegions = await dbContext
                .TimeZoneRegions
                .Select(x => new TimeZoneRegionViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Datacenters = x.Datacenters
                    .OrderBy(y => y.Name)
                    .Select(y => new DatacenterViewModel
                    {
                        Id = y.Id,
                        Name = y.Name,
                        Tag = y.Tag,
                        TzIanaName = y.TzIanaName,
                        OpeningAtDay = y.OpeningAtDay,
                        OpeningAtTime = y.OpeningAtTime,
                        ClosingAtDay = y.ClosingAtDay,
                        ClosingAtTime = y.ClosingAtTime,
                    })
                    .ToArray(),
                })
                .ToArrayAsync();

            return result;
        }
    }
}
