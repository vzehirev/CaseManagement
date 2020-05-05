using System;

namespace CaseManagement.ViewModels.Datacenters
{
    public class DatacenterViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Tag { get; set; }

        public string TzIanaName { get; set; }

        public int? OpeningAtDay { get; set; }

        public TimeSpan OpeningAtTime { get; set; }

        public int? ClosingAtDay { get; set; }

        public TimeSpan ClosingAtTime { get; set; }
    }
}
