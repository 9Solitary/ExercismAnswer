using System;
using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime localDateTime = DateTime.Parse(appointmentDateDescription);

        string timeZoneId = GetTimeZoneId(location);

        TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        return TimeZoneInfo.ConvertTimeToUtc(localDateTime, tzi);
    }

    private static string GetTimeZoneId(Location location)
    {
        bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        return location switch
        {
            Location.NewYork => isWindows ? "Eastern Standard Time" : "America/New_York",
            Location.London => isWindows ? "GMT Standard Time" : "Europe/London",
            Location.Paris => isWindows ? "W. Europe Standard Time" : "Europe/Paris",
            _ => throw new ArgumentOutOfRangeException(nameof(location))
        };
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        switch (alertLevel)
        {
            case AlertLevel.Early:
                return appointment.AddDays(-1);
            case AlertLevel.Standard:
                return appointment.AddMinutes(-105);
            case AlertLevel.Late:
                return appointment.AddMinutes(-30);
            default:
                throw new ArgumentOutOfRangeException(nameof(alertLevel));
        }
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        string timeZoneId = GetTimeZoneId(location);
        TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

        bool isDaylightSavingNow = tzi.IsDaylightSavingTime(dt);

        DateTime sevenDaysAgo = dt.AddDays(-7);
        bool isDaylightSavingPast = tzi.IsDaylightSavingTime(sevenDaysAgo);

        return isDaylightSavingNow != isDaylightSavingPast;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        string timeCulture;
        DateTime result;

        switch (location)
        {
            case Location.NewYork:
                timeCulture = "en-US";
                break;
            case Location.London:
                timeCulture = "en-GB";
                break;
            case Location.Paris:
                timeCulture = "fr-FR";
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(location));
        }

        CultureInfo cultureInfo = new CultureInfo(timeCulture);
        if (DateTime.TryParse(dtStr, cultureInfo, DateTimeStyles.None, out result))
            return result;
        else return new DateTime(1, 1, 1);
    }
}
