using System;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private int month;
    private int year;

    public Meetup(int month, int year)
    {
        this.month = month;
        this.year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        int dayInMonth = DateTime.DaysInMonth(year, month);
        DateTime startTime = new DateTime();
        DateTime endTime = new DateTime();
        DateTime theDay = new DateTime();

        switch (schedule)
        {
            case Schedule.Teenth:
                startTime = new DateTime(year, month, 13);
                endTime = new DateTime(year, month, 19);
                break;
            case Schedule.First:
                startTime = new DateTime(year, month, 1);
                endTime = new DateTime(year, month, 7);
                break;
            case Schedule.Second:
                startTime = new DateTime(year, month, 8);
                endTime = new DateTime(year, month, 14);
                break;
            case Schedule.Third:
                startTime = new DateTime(year, month, 15);
                endTime = new DateTime(year, month, 21);
                break;
            case Schedule.Fourth:
                startTime = new DateTime(year, month, 22);
                endTime = new DateTime(year, month, 28);
                break;
            case Schedule.Last:
                startTime = new DateTime(year, month, dayInMonth - 6);
                endTime = new DateTime(year, month, dayInMonth);
                break;
        }

        for (DateTime daySearch = startTime; daySearch <= endTime; daySearch = daySearch.AddDays(1))
        {
            if (daySearch.DayOfWeek == dayOfWeek)
            {
                theDay = daySearch;
                break;
            }
        }
        return theDay;
    }
}