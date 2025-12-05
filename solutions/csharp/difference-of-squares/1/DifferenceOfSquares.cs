public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        int sumMax = 0;
        while (max > 0)
        {
            sumMax += max;
            max--;
        }
        return sumMax * sumMax;
    }

    public static int CalculateSumOfSquares(int max)
    {
        int sumMax;
        int sum = 0;
        while (max > 0)
        {
            sumMax = max * max;
            sum += sumMax;
            max--;
        }
        return sum;
    }

    public static int CalculateDifferenceOfSquares(int max) => CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
}