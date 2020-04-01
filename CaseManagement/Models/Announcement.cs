using System;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models
{
    public class Announcement
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime PublishedOn { get; set; }
    }
}
