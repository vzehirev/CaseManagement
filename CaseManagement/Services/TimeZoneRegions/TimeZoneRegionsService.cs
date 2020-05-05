using CaseManagement.Data;
using CaseManagement.Models.TimeZoneRegions;
using CaseManagement.ViewModels.TimeZoneRegions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.TimeZoneRegions
{
    public class TimeZoneRegionsService : ITimeZoneRegionsService
    {
        private readonly ApplicationDbContext dbContext;

        public TimeZoneRegionsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddTimeZoneRegionAsync(string name)
        {
            var timeZoneRegion = new TimeZoneRegion
            {
                Name = name,
            };

            this.dbContext.TimeZoneRegions.Add(timeZoneRegion);
            await this.dbContext.SaveChangesAsync();

            return timeZoneRegion.Id;
        }

        public async Task<int> DeleteTimeZoneRegionAsync(int id)
        {
            var result = 0;
            var timeZoneRegion = await this.dbContext.TimeZoneRegions.FirstOrDefaultAsync(x => x.Id == id);

            if (timeZoneRegion != null)
            {
                this.dbContext.TimeZoneRegions.Remove(timeZoneRegion);
                result = await this.dbContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<AddDcTimeZoneRegionSelectViewModel>> GetAllTimeZoneRegionsAsync()
        {
            var result = await this.dbContext.TimeZoneRegions
                .Select(x => new AddDcTimeZoneRegionSelectViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                })
                .ToArrayAsync();

            return result;
        }
    }
}
