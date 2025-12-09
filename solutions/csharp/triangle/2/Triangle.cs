public static class Triangle
{
    public static bool IsTriangle(double a, double b, double c) => a + b > c && a + c > b && b + c > a;
    public static bool IsScalene(double a, double b, double c) => IsTriangle(a, b, c) && a != b && a != c && b != c;

    public static bool IsIsosceles(double a, double b, double c) => IsTriangle(a, b, c) && (a == b || a == c || b == c);

    public static bool IsEquilateral(double a, double b, double c) => a == b && a == c && b == c && a > 0;
}