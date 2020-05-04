using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagement.Services.DatacentersService;
using CaseManagement.Services.DateTimeConverter;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagement.Controllers
{
    public class DatacentersTimesController : Controller
    {
        private readonly IDatacentersService datacentersTimesService;
        private readonly IDateTimeConverterService dateTimeConverterService;

        public DatacentersTimesController(IDatacentersService datacentersTimesService, IDateTimeConverterService dateTimeConverterService)
        {
            this.datacentersTimesService = datacentersTimesService;
            this.dateTimeConverterService = dateTimeConverterService;
        }
        public async Task<IActionResult> Index()
        {
            var outputModel = await datacentersTimesService.GetAllRegionsAndTheirTimezonesAsync();
            outputModel.VendorsWithRegions = await dateTimeConverterService.GetAllVendorsWithRegionsAsync();

            return View(outputModel);
        }
    }
}