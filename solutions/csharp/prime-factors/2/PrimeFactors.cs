public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        List<long> result = new List<long>();

        if (number <= 1)
            return result.ToArray();

        while (number % 2 == 0)
        {
            result.Add(2);
            number /= 2;
        }

        for (long divisor = 3; divisor * divisor <= number; divisor += 2)
        {
            while (number % divisor == 0)
            {
                result.Add(divisor);
                number /= divisor;
            }
        }

        if (number > 1)
            result.Add(number);

        return result.ToArray();
    }
}