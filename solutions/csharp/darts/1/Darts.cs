public static class Darts
{
    public static int Score(double x, double y)
    {
        double Line = Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(y, 2.0));
        if (Line <= 1)
            return 10;
        else if (Line <= 5)
            return 5;
        else if (Line <= 10)
            return 1;
        else return 0;
    }
}
