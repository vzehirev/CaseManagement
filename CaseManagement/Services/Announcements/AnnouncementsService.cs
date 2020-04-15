using CaseManagement.Data;
using CaseManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Services.Announcements
{
    public class AnnouncementsService : IAnnouncementsService
    {
        private readonly ApplicationDbContext dbContext;

        public AnnouncementsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> AddAnnouncementAsync(string userId, string announcement)
        {
            Announcement announcementToAdd = new Announcement
            {
                UserId = userId,
                Content = announcement,
                PublishedOn = DateTime.UtcNow,
            };

            dbContext.Announcements.Add(announcementToAdd);

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAnnouncementAsync(int id)
        {
            Announcement announcementToDelete = await dbContext.Announcements.FirstOrDefaultAsync(a => a.Id == id);

            if (announcementToDelete != null)
            {
                dbContext.Announcements.Remove(announcementToDelete);
            }
            return await dbContext.SaveChangesAsync();
        }

        public async Task<Announcement[]> GetAllAnnouncementsAsync()
        {
            return await dbContext.Announcements
                .OrderByDescending(a => a.PublishedOn)
                .ToArrayAsync();
        }

        public async Task<string> GetAnnouncementsAsync()
        {
            const int announcementsToTake = 5;

            string[] announcements = await dbContext.Announcements
                .OrderByDescending(a => a.PublishedOn)
                // TinyMCE (the visual editor used for adding the announcements) adds p tag to each entry. It's removed here.
                .Select(a => a.Content.Replace("<p>", "").Replace("</p>", ""))
                .Take(announcementsToTake)
                .ToArrayAsync();

            if (announcements.Length == 0)
            {
                return string.Empty;
            }

            // Wrap all the announcements in one p tag, so they can be shown on one line and put some dividers inbetween them
            string result = "<p>" + string.Join("&nbsp;&nbsp;&nbsp;&#10148;&nbsp;", announcements) + "&nbsp;&nbsp;&nbsp;&#10148;&nbsp;</p>";

            return result;
        }
    }
}
