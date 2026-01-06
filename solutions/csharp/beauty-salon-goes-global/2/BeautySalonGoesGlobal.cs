using System;
using System.Collections.Generic;
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
    private record LocationConfig(string WindowsZoneId, string UnixZoneId, string CultureCode);

    private static readonly Dictionary<Location, LocationConfig> _locationRegistry = new()
    {
        [Location.NewYork] = new("Eastern Standard Time", "America/New_York", "en-US"),
        [Location.London] = new("GMT Standard Time", "Europe/London", "en-GB"),
        [Location.Paris] = new("W. Europe Standard Time", "Europe/Paris", "fr-FR")
    };

    private static readonly bool _isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    private static TimeZoneInfo GetTimeZone(Location location)
    {
        if (!_locationRegistry.TryGetValue(location, out var config))
        {
            throw new ArgumentOutOfRangeException(nameof(location), $"Location {location} is not configured.");
        }

        string timeZoneId = _isWindows ? config.WindowsZoneId : config.UnixZoneId;

        return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
    }

    private static CultureInfo GetCulture(Location location)
    {
        if (!_locationRegistry.TryGetValue(location, out var config))
        {
            throw new ArgumentOutOfRangeException(nameof(location));
        }
        return CultureInfo.GetCultureInfo(config.CultureCode);
    }

    public static DateTime ShowLocalTime(DateTime dtUtc) => dtUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        var tzi = GetTimeZone(location);

        var localDateTime = DateTime.Parse(appointmentDateDescription);

        return TimeZoneInfo.ConvertTimeToUtc(localDateTime, tzi);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        TimeSpan offset = alertLevel switch
        {
            AlertLevel.Early => TimeSpan.FromDays(1),
            AlertLevel.Standard => TimeSpan.FromMinutes(105), // 1h 45m
            AlertLevel.Late => TimeSpan.FromMinutes(30),
            _ => throw new ArgumentOutOfRangeException(nameof(alertLevel))
        };

        return appointment - offset;
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var tzi = GetTimeZone(location);

        return tzi.IsDaylightSavingTime(dt) != tzi.IsDaylightSavingTime(dt.AddDays(-7));
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        var culture = GetCulture(location);

        return DateTime.TryParse(dtStr, culture, DateTimeStyles.None, out var result)
            ? result
            : new DateTime(1, 1, 1);
    }
}