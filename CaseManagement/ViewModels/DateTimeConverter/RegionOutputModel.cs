using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseManagement.ViewModels.DateTimeConverter
{
    public class RegionOutputModel
    {
        public string Name { get; set; }

        public int UtcOffset { get; set; }

        public string FullName
        {
            get
            {
                if (UtcOffset > 0)
                {
                    return $"{Name} (UTC +{UtcOffset})";
                }
                else
                {
                    return $"{Name} (UTC {UtcOffset})";
                }
            }
        }
    }
}
