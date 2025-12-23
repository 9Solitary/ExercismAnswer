public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        List<int> numList = new List<int>();
        foreach (int item in multiples)
        {
            if (item <= 0)
                continue;
            for (int value = 1; item * value < max; value++)
            {
                int multiple = item * value;
                numList.Add(multiple);
            }
        }
        return numList.Distinct().Sum();
    }
}