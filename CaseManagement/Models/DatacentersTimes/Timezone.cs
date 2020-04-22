using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.Models.DatacentersTimes
{
    public class Timezone
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Tag { get; set; }

        [Required]
        public string TzIanaName { get; set; }

        [Required]
        public int TimezoneRegionId { get; set; }
        public virtual TimezoneRegion TimezoneRegion { get; set; }
    }
}
