using System.Globalization;

namespace probiotics.Utils;

public  static class DateUtils
{
    public static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
    {
        DateTime jan1 = new DateTime(year, 1, 1);
        int daysOffset = DayOfWeek.Monday - jan1.DayOfWeek;

        DateTime firstMonday = jan1.AddDays(daysOffset);
        int firstWeek = ISOWeek.GetWeekOfYear(firstMonday);

        if (firstWeek <= 1)
        {
            weekOfYear -= 1;
        }

        return firstMonday.AddDays((weekOfYear - 1) * 7);
    }
}