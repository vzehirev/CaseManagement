using CaseManagement.Models;
using CaseManagement.Services.DatacentersService;
using CaseManagement.Services.TimeZoneRegions;
using CaseManagement.ViewModels.TimeZoneRegions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CaseManagement.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Lead")]
    public partial class AddDc : PageModel
    {
        private readonly ITimeZoneRegionsService timeZoneRegionsService;
        private readonly IDatacentersService datacentersService;

        public AddDc(ITimeZoneRegionsService timeZoneRegionsService, IDatacentersService datacentersService)
        {
            this.timeZoneRegionsService = timeZoneRegionsService;
            this.datacentersService = datacentersService;
        }

        public class AddTimeZoneRegionViewModel
        {
            [Required]
            public string Name { get; set; }
        }

        public class AddDcViewModel
        {
            [Required]
            public string Name { get; set; }

            [Required]
            public string Tag { get; set; }

            [Required]
            [Display(Name = "Time zone IANA identifier")]
            public string TzIanaName { get; set; }

            [Required, Range(1, double.MaxValue, ErrorMessage = "Please select time zone region.")]
            public int TimeZoneRegionId { get; set; }

            public int? OpeningAtDay { get; set; }

            public TimeSpan OpeningAtTime { get; set; }

            public int? ClosingAtDay { get; set; }

            public TimeSpan ClosingAtTime { get; set; }

            public IEnumerable<AddDcTimeZoneRegionSelectViewModel> TimeZoneRegions { get; set; }
        }

        [BindProperty]
        public AddTimeZoneRegionViewModel AddTimeZoneRegionModel { get; set; } = new AddTimeZoneRegionViewModel();

        [BindProperty]
        public AddDcViewModel AddDcModel { get; set; } = new AddDcViewModel();

        public async Task<IActionResult> OnGetAsync()
        {
            this.AddDcModel.TimeZoneRegions = await this.timeZoneRegionsService.GetAllTimeZoneRegionsAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAddTimeZoneRegionAsync()
        {
            if (AddTimeZoneRegionModel.Name == null)
            {
                return RedirectToPage(this.AddTimeZoneRegionModel);
            }

            var result = await this.timeZoneRegionsService.AddTimeZoneRegionAsync(this.AddTimeZoneRegionModel.Name.Trim());

            if (result > 0)
            {
                this.TempData["timeZoneRegionAdded"] = true;
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddDcAsync()
        {
            if (this.AddDcModel.Name == null
                || this.AddDcModel.Tag == null
                || this.AddDcModel.TzIanaName == null
                || this.AddDcModel.TimeZoneRegionId == 0)
            {
                return RedirectToPage(this.AddDcModel);
            }

            var result = await this.datacentersService.AddDcAsync(this.AddDcModel.Name, this.AddDcModel.Tag,
                this.AddDcModel.TzIanaName, this.AddDcModel.TimeZoneRegionId,
                this.AddDcModel.OpeningAtDay, this.AddDcModel.OpeningAtTime,
                this.AddDcModel.ClosingAtDay, this.AddDcModel.ClosingAtTime);

            if (result > 0)
            {
                this.TempData["datacenterAdded"] = true;
            }

            return RedirectToPage();
        }
    }
}
