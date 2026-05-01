public class Clock : IEquatable<Clock>
{
    int SumMinutes;
    int hoursNow { get; }
    int minutesNow { get; }
    public Clock(int hours, int minutes)
    {
        SumMinutes = (hours * 60 + minutes) % (24 * 60);
        if (SumMinutes < 0)
            SumMinutes += 24 * 60;
        hoursNow = SumMinutes / 60;
        minutesNow = SumMinutes % 60;
    }

    public Clock Add(int minutesToAdd)
    {
        SumMinutes += minutesToAdd;
        return new Clock(0, SumMinutes);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        SumMinutes -= minutesToSubtract;
        return new Clock(0, SumMinutes);
    }

    public bool Equals(Clock? other) => other is not null && other.hoursNow == hoursNow && other.minutesNow == minutesNow;

    public override string ToString() => $"{hoursNow:D2}:{minutesNow:D2}";
}
