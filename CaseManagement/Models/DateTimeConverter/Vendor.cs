using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Models.DateTimeConverter
{
    public class Vendor
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Region> Regions { get; set; } = new HashSet<Region>();
    }
}
