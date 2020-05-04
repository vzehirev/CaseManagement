using CaseManagement.Models.Datacenters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models.TimeZoneRegions
{
    public class TimeZoneRegion
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Datacenter> TimeZones { get; set; }
    }
}
