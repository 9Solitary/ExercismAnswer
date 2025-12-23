public static class SquareRoot
{
    public static int Root(int number)
    {
        double xOld = number / 2.0;
        double xNew = number / 2.0;
        double xPast = 0;
        double diff = xNew - xPast;
        while (diff > 0.00001)
        {
            xPast = xNew;
            xNew = (xOld + (number / xOld)) / 2;
            xOld = xNew;
            diff = xNew - xPast;
            if (diff < 0) diff = -diff;
        }
        return (int)xNew;
    }
}
