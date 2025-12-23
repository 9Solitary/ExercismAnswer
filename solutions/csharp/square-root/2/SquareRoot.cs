public static class SquareRoot
{
    public static int Root(int number)
    {
        // 初始猜测
        double guess = number / 2.0;

        // 精度阈值
        const double epsilon = 0.00001;

        while (true)
        {
            // 根据牛顿法公式计算下一次猜测
            double nextGuess = (guess + number / guess) / 2.0;

            // 判断是否已经足够接近
            if (Abs(nextGuess - guess) < epsilon)
            {
                break;
            }

            // 准备下一轮
            guess = nextGuess;
        }

        return (int)guess;
    }

    private static double Abs(double value)
    {
        return value < 0 ? -value : value;
    }
}
