using System;
using System.Collections.Generic;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        if (sum % 2 != 0)
            yield break;

        // 使用 long 防止 sum * sum 溢出 int 范围
        long target = (long)sum * sum / 2;

        for (int factor1 = 1; factor1 * factor1 < target; factor1++)
        {
            if (target % factor1 == 0)
            {
                long factor2 = target / factor1;

                int a = sum - (int)factor2;
                int b = sum - factor1;
                int c = sum - a - b;

                if (a > 0 && b > a && c > b)
                {
                    if ((long)a * a + (long)b * b == (long)c * c)
                    {
                        yield return (a, b, c);
                    }
                }
            }
        }
    }
}