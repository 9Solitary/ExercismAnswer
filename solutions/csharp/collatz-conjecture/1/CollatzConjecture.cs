public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        int steps = 0;
        int value = number;
        if (number >= 1)
        {
            while (value > 1)
            {
                if (value % 2 == 0)
                {
                    value = value / 2;
                    steps++;
                }
                else
                {
                    value = value * 3 + 1;
                    steps++;
                }
            }
            return steps;
        }
        else throw new ArgumentOutOfRangeException(nameof(number));
    }
}