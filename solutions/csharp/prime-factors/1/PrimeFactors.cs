public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        List<long> result = new List<long>();
        long oddNumber = 0;

        if (number <= 1)
            return result.ToArray();

        if (number % 2 == 0)
        {
            while (number % 2 == 0)
            {
                number = number / 2;
                result.Add(2);
            }
            oddNumber = number;
        }
        else oddNumber = number;

        for (long divisor = 3; divisor * divisor <= oddNumber; divisor += 2)
        {
            if (oddNumber % divisor == 0)
            {
                while (oddNumber % divisor == 0)
                {
                    oddNumber = oddNumber / divisor;
                    result.Add(divisor);
                }
            }
        }

        if (oddNumber > 1)
            result.Add(oddNumber);

        return result.ToArray();
    }
}