using CaseManagement.Data;
using CaseManagement.ViewModels.DateTimeConverter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.DateTimeConverter
{
    public class DateTimeConverterService : IDateTimeConverterService
    {
        private readonly ApplicationDbContext dbContext;

        public DateTimeConverterService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<VendorsWithRegionsOutputModel> GetAllVendorsWithRegionsAsync()
        {
            var outputModel = new VendorsWithRegionsOutputModel
            {
                Vendors = await dbContext.Vendors
                    .Select(v => new VendorOutputModel
                    {
                        Name = v.Name,
                        Regions = v.Regions.Select(r => new RegionOutputModel
                        {
                            Name = r.Name,
                            UtcOffset = r.UtcOffset,
                        })
                        .ToArray(),
                    })
                    .ToArrayAsync(),
            };

            return outputModel;
        }
    }
}
