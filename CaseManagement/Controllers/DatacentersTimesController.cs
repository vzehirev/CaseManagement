using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagement.Services.DatacentersService;
using CaseManagement.Services.DateTimeConverter;
using CaseManagement.Services.TimeZoneRegions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagement.Controllers
{
    public class DatacentersTimesController : Controller
    {
        private readonly IDatacentersService datacentersService;
        private readonly ITimeZoneRegionsService timeZoneRegionsService;
        private readonly IDateTimeConverterService dateTimeConverterService;

        public DatacentersTimesController(IDatacentersService datacentersService,
            ITimeZoneRegionsService timeZoneRegionsService,
            IDateTimeConverterService dateTimeConverterService)
        {
            this.datacentersService = datacentersService;
            this.timeZoneRegionsService = timeZoneRegionsService;
            this.dateTimeConverterService = dateTimeConverterService;
        }
        public async Task<IActionResult> Index()
        {
            var outputModel = await datacentersService.GetAllRegionsAndTheirDatacentersAsync();
            outputModel.VendorsWithRegions = await dateTimeConverterService.GetAllVendorsWithRegionsAsync();

            return View(outputModel);
        }

        [Authorize(Roles = "Lead")]
        [HttpPost]
        public async Task<IActionResult> DeleteDc(int id)
        {
            var result = await this.datacentersService.DeleteDcAsync(id);

            if (result > 0)
            {
                this.TempData["dcDeleted"] = true;
            }

            return RedirectToAction(nameof(this.Index));
        }

        [Authorize(Roles = "Lead")]
        [HttpPost]
        public async Task<IActionResult> DeleteTimeZoneRegion(int id)
        {
            var result = await this.timeZoneRegionsService.DeleteTimeZoneRegionAsync(id);

            if (result > 0)
            {
                this.TempData["timeZoneDeleted"] = true;
            }

            return RedirectToAction(nameof(this.Index));
        }
    }
}