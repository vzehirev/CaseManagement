using CaseManagement.Models;
using CaseManagement.Services.Announcements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace CaseManagement.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Lead")]
    public partial class AnnouncementsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAnnouncementsService announcementsService;

        public AnnouncementsModel(UserManager<ApplicationUser> userManager, IAnnouncementsService announcementsService)
        {
            _userManager = userManager;
            this.announcementsService = announcementsService;
        }


        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required, MinLength(1)]
            public string Announcement { get; set; }
            public Announcement[] AvailableAnnouncements { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Input = new InputModel
            {
                AvailableAnnouncements = await announcementsService.GetAllAnnouncementsAsync(),
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id != 0)
            {
                int result = await announcementsService.DeleteAnnouncementAsync(id);
                if (result > 0)
                {
                    TempData["AnnouncementDeleted"] = true;
                    return RedirectToPage();
                }
                TempData["AnnouncementDeleted"] = false;
                return RedirectToPage();
            }

            ApplicationUser user = await _userManager.GetUserAsync(User);
            string userId = user.Id;

            if (ModelState.IsValid)
            {
                int result = await announcementsService.AddAnnouncementAsync(userId, Input.Announcement);
                if (result > 0)
                {
                    TempData["AnnouncementAdded"] = true;
                    return RedirectToPage();
                }
            }

            TempData["AnnouncementAdded"] = false;
            return RedirectToPage(Input);

        }
    }
}
