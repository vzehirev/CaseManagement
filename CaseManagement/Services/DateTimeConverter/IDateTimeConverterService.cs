using CaseManagement.ViewModels.DateTimeConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.DateTimeConverter
{
    public interface IDateTimeConverterService
    {
        public Task<VendorsWithRegionsOutputModel> GetAllVendorsWithRegionsAsync();
    }
}
