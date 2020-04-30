using CaseManagement.Enums;
using System;

namespace CaseManagement.Helpers
{
    public static class CalculateFromAndToDatesByTimeFrameEnum
    {
        public static DateTime CalculateFromDate(TimeFrameEnum timeFrame = 0)
        {
            var result = new DateTime();
            var now = DateTime.UtcNow;
            var todayAt0000 = now.AddMilliseconds(-now.TimeOfDay.TotalMilliseconds + 1);

            var dayDifference = (DayOfWeek.Monday - now.DayOfWeek) >= 1 ? -6 : (DayOfWeek.Monday - now.DayOfWeek);

            var thisWeeksMondayAt0000 = now.AddDays(dayDifference)
                .AddMilliseconds(-now.TimeOfDay.TotalMilliseconds + 1);

            switch (timeFrame)
            {
                case TimeFrameEnum.Today:
                    result = now.AddMilliseconds(-now.TimeOfDay.TotalMilliseconds + 1);
                    break;

                case TimeFrameEnum.Yesterday:
                    result = now.AddDays(-1).AddMilliseconds(-now.TimeOfDay.TotalMilliseconds + 1);
                    break;

                case TimeFrameEnum.ThisWeek:
                    result = thisWeeksMondayAt0000;
                    break;

                case TimeFrameEnum.LastWeek:
                    result = thisWeeksMondayAt0000.AddDays(-7);
                    break;

                case TimeFrameEnum.ThisMonth:
                    result = new DateTime(todayAt0000.Year,
                        todayAt0000.Month,
                        1,
                        todayAt0000.Hour,
                        todayAt0000.Minute,
                        todayAt0000.Second,
                        todayAt0000.Millisecond);
                    break;

                case TimeFrameEnum.LastMonth:
                    var sameDateLastMonthAt0000 = todayAt0000.AddMonths(-1);

                    result = new DateTime(sameDateLastMonthAt0000.Year,
                        sameDateLastMonthAt0000.Month,
                        1,
                        sameDateLastMonthAt0000.Hour,
                        sameDateLastMonthAt0000.Minute,
                        sameDateLastMonthAt0000.Second,
                        sameDateLastMonthAt0000.Millisecond);
                    break;
            }

            return result;
        }

        public static DateTime CalculateToDate(TimeFrameEnum timeFrame = 0)
        {
            var result = new DateTime();
            var now = DateTime.UtcNow;

            var dayDifference = (7 - (int)now.DayOfWeek) >= 7 ? 0 : (7 - (int)now.DayOfWeek);

            var thisWeeksSundayAt2359 = now.AddDays(dayDifference + 1)
                .AddMilliseconds(-now.TimeOfDay.TotalMilliseconds - 1);

            switch (timeFrame)
            {
                case TimeFrameEnum.Today:
                    result = now.AddDays(1).AddMilliseconds(-now.TimeOfDay.TotalMilliseconds - 1);
                    break;

                case TimeFrameEnum.Yesterday:
                    result = now.AddMilliseconds(-now.TimeOfDay.TotalMilliseconds - 1);
                    break;

                case TimeFrameEnum.ThisWeek:
                    result = thisWeeksSundayAt2359;
                    break;

                case TimeFrameEnum.LastWeek:
                    result = thisWeeksSundayAt2359.AddDays(-7);
                    break;

                case TimeFrameEnum.ThisMonth:
                    var sameTimeNextMonth = now.AddMonths(1);
                    var lastDayOfThisMonthAt2359 = new DateTime(sameTimeNextMonth.Year, sameTimeNextMonth.Month, 1)
                        .AddMilliseconds(-1);
                    result = lastDayOfThisMonthAt2359;
                    break;

                case TimeFrameEnum.LastMonth:
                    var lastDayOfLastMonthAt2359 = new DateTime(now.Year, now.Month, 1)
                        .AddMilliseconds(-1);
                    result = lastDayOfLastMonthAt2359;
                    break;
            }

            return result;
        }
    }
}
