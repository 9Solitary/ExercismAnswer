public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number <= 0)
            throw new ArgumentOutOfRangeException();

        List<int> factors = new List<int>();
        for (int factor = 1; factor <= number / 2; factor++)
        {
            if (number % factor == 0)
                factors.Add(factor);
        }
        int factorsSum = factors.Sum();

        if (factorsSum == number)
            return Classification.Perfect;
        else if (factorsSum < number)
            return Classification.Deficient;
        else return Classification.Abundant;
    }
}
