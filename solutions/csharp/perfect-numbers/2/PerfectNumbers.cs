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
        if (number <= 0) throw new ArgumentOutOfRangeException();
        var sum = Enumerable.Range(1, number / 2).Where(i => number % i == 0).Sum();
        return sum == number ? Classification.Perfect : sum > number ? Classification.Abundant : Classification.Deficient;
    }
}
