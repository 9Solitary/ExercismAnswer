class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        int[] lastWeekCount = { 0, 2, 5, 3, 7, 8, 4 };
        return lastWeekCount;
    }

    public int Today() => birdsPerDay[birdsPerDay.Length - 1];

    public void IncrementTodaysCount()
    {
        int count = new BirdCount(birdsPerDay).Today();
        birdsPerDay[birdsPerDay.Length - 1] = count + 1;
    }

    public bool HasDayWithoutBirds()
    {
        if (Array.IndexOf(birdsPerDay, 0) > -1)
            return true;
        else return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int sum = 0;
        for (int i = 0; i < numberOfDays; i++)
        {
            sum += birdsPerDay[i];
        }
        return sum;
    }

    public int BusyDays()
    {
        int busyDays = 0;
        foreach (int birdPerDay in birdsPerDay)
        {
            if (birdPerDay >= 5)
                busyDays++;
        }
        return busyDays;
    }
}
