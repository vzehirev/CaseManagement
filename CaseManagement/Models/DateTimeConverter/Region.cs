using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Models.DateTimeConverter
{
    public class Region
    {
        [Required, Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int UtcOffset { get; set; }

        [Required]
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
