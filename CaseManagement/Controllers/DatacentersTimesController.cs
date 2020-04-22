using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseManagement.Services.DatacentersTimesService;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagement.Controllers
{
    public class DatacentersTimesController : Controller
    {
        private readonly IDatacentersTimesService datacentersTimesService;

        public DatacentersTimesController(IDatacentersTimesService datacentersTimesService)
        {
            this.datacentersTimesService = datacentersTimesService;
        }
        public async Task<IActionResult> Index()
        {
            var outputModel = await datacentersTimesService.GetAllRegionsAndTheirTimezonesAsync();
            return View(outputModel);
        }
    }
}