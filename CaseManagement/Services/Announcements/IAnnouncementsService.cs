using CaseManagement.Models;
using System.Threading.Tasks;

namespace CaseManagement.Services.Announcements
{
    public interface IAnnouncementsService
    {
        public Task<int> AddAnnouncementAsync(string userId, string announcement);

        public Task<string> GetAnnouncementsAsync();

        public Task<Announcement[]> GetAllAnnouncementsAsync();

        public Task<int> DeleteAnnouncementAsync(int id);
    }
}
