public static class PalindromeProducts
{
    public static (int, IEnumerable<(int, int)>) Largest(int minFactor, int maxFactor)
    {
        int maxPalindrome = 0;
        for (int product = maxFactor * maxFactor; product >= minFactor * minFactor; product--)
        {
            if (product != ReverseNumber(product) || !HasGetFactorPairs(product, minFactor, maxFactor)) continue;
            maxPalindrome = product;
            break;
        }

        if (maxPalindrome != 0)
            return (maxPalindrome, GetFactorPairs(maxPalindrome, minFactor, maxFactor));

        else throw new ArgumentException();
    }

    public static (int, IEnumerable<(int, int)>) Smallest(int minFactor, int maxFactor)
    {
        int minPalindrome = 0;
        for (int product = minFactor * minFactor; product <= maxFactor * maxFactor; product++)
        {
            if (product != ReverseNumber(product) || !HasGetFactorPairs(product, minFactor, maxFactor)) continue;
            minPalindrome = product;
            break;
        }

        if (minPalindrome != 0)
            return (minPalindrome, GetFactorPairs(minPalindrome, minFactor, maxFactor));

        else throw new ArgumentException();
    }

    public static int ReverseNumber(int num)
    {
        int reversed = 0;
        while (num != 0)
        {
            int digit = num % 10;          // 获取最后一位
            num /= 10;                     // 去掉最后一位

            // 检查溢出（C# 默认不会自动抛出溢出异常，需显式检查）
            if (reversed > int.MaxValue / 10 || (reversed == int.MaxValue / 10 && digit > 7))
                return 0;                  // 溢出时返回0或抛出异常
            if (reversed < int.MinValue / 10 || (reversed == int.MinValue / 10 && digit < -8))
                return 0;

            reversed = reversed * 10 + digit;
        }
        return reversed;
    }

    public static bool HasGetFactorPairs(int n, int minFactor, int maxFactor)
    {
        var results = GetFactorPairs(n, minFactor, maxFactor);

        // 检查是否有数据，如果没有则抛出异常
        if (!results.Any())
            return false;
        else return true;
    }

    private static IEnumerable<(int a, int b)> GetFactorPairs(int n, int minFactor, int maxFactor)
    {
        if (n <= 0) yield break;

        for (int i = minFactor; i <= maxFactor; i++)
        {
            if (n % i == 0 && n / i <= maxFactor && n / i >= minFactor)
            {
                int j = n / i;
                if (i <= j)
                    yield return (i, j);
            }
        }
    }
}
