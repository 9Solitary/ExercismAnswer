public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        if (operation == null)
            throw new ArgumentNullException();
        if (operation == "")
            throw new ArgumentException();

        switch (operation)
        {
            case "+":
                return $"{operand1} + {operand2} = {operand1 + operand2}";
            case "*":
                return $"{operand1} * {operand2} = {operand1 * operand2}";
            case "/":
                try
                {
                    if (operand2 == 0)
                    {
                        throw new ArgumentException();
                    }
                }
                catch (ArgumentException)
                {
                    return $"Division by zero is not allowed.";
                }
                return $"{operand1} / {operand2} = {operand1 / operand2}";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
