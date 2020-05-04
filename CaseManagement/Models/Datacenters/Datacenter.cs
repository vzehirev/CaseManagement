using CaseManagement.Models.TimeZoneRegions;
using System;
using System.ComponentModel.DataAnnotations;

namespace CaseManagement.Models.Datacenters
{
    public class Datacenter
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Tag { get; set; }

        [Required]
        public string TzIanaName { get; set; }

        [Required]
        public int TimeZoneRegionId { get; set; }
        public virtual TimeZoneRegion TimeZoneRegion { get; set; }

        public int? OpeningAtDay { get; set; }

        public TimeSpan OpeningAtTime { get; set; }

        public int? ClosingAtDay { get; set; }

        public TimeSpan ClosingAtTime { get; set; }
    }
}
