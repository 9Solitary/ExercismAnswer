public struct ComplexNumber
{
    private double real;
    private double imaginary;
    public ComplexNumber(double real, double imaginary)
    {
        this.real = real;
        this.imaginary = imaginary;
    }

    //实部
    public double Real() => real;

    //虚部
    public double Imaginary() => imaginary;

    // 乘法：复数 * 复数
    public ComplexNumber Mul(ComplexNumber other)
    {
        double r1 = real, i1 = imaginary;
        double r2 = other.real, i2 = other.imaginary;
        return new ComplexNumber(r1 * r2 - i1 * i2, i1 * r2 + r1 * i2);
    }

    // 乘法：复数 * 实数
    public ComplexNumber Mul(double other) =>
        new ComplexNumber(real * other, imaginary * other);

    // 加法：复数 + 复数
    public ComplexNumber Add(ComplexNumber other) =>
        new ComplexNumber(real + other.real, imaginary + other.imaginary);

    // 加法：复数 + 实数（double）
    public ComplexNumber Add(double other) =>
        new ComplexNumber(real + other, imaginary);

    // 减法：复数 - 复数
    public ComplexNumber Sub(ComplexNumber other) =>
        new ComplexNumber(real - other.real, imaginary - other.imaginary);

    // 减法：复数 - 实数
    public ComplexNumber Sub(double other) =>
        new ComplexNumber(real - other, imaginary);

    // 除法：复数 / 复数
    public ComplexNumber Div(ComplexNumber other)
    {
        double a = real, b = imaginary;
        double c = other.real, d = other.imaginary;
        double denominator = c * c + d * d;
        return new ComplexNumber(
            (a * c + b * d) / denominator,
            (b * c - a * d) / denominator
        );
    }

    // 除法：复数 / 实数
    public ComplexNumber Div(double other) =>
        new ComplexNumber(real / other, imaginary / other);

    //绝对值
    public double Abs() => Math.Sqrt(real * real + imaginary * imaginary);

    //共轭复数
    public ComplexNumber Conjugate() => new ComplexNumber(real, -imaginary);

    //幂运算
    public ComplexNumber Exp()
    {
        double expReal = Math.Exp(real); // 等价于 Math.Pow(Math.E, real)
        return new ComplexNumber(expReal * Math.Cos(imaginary), expReal * Math.Sin(imaginary));
    }
}