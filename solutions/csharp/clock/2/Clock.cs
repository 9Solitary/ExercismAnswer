public class Clock : IEquatable<Clock>
{
    int _totalMinutes;
    private int Hours => _totalMinutes / 60;
    private int Minutes => _totalMinutes % 60;
    public Clock(int hours, int minutes)
    {
        _totalMinutes = (hours * 60 + minutes) % (24 * 60);
        if (_totalMinutes < 0)
            _totalMinutes += 24 * 60;
    }

    public Clock Add(int minutesToAdd)
    => new Clock(0, _totalMinutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract)
    => new Clock(0, _totalMinutes - minutesToSubtract);

    public bool Equals(Clock? other) => other is not null && other.Hours == Hours && other.Minutes == Minutes;
    public override bool Equals(object? obj) => Equals(obj as Clock);

    public override int GetHashCode() => _totalMinutes.GetHashCode();

    public override string ToString() => $"{Hours:D2}:{Minutes:D2}";
}
