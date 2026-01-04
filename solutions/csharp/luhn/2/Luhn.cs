public static class Luhn
{
    public static bool IsValid(string number)
    {
        int sum = 0;
        int digitCount = 0;
        bool shouldDouble = false;

        for (int i = number.Length - 1; i >= 0; i--)
        {
            char c = number[i];

            if (char.IsWhiteSpace(c))
                continue;

            if (!char.IsDigit(c))
                return false;

            int digit = c - '0';

            if (shouldDouble)
            {
                digit *= 2;
                if (digit > 9) digit -= 9;
            }

            sum += digit;
            digitCount++;
            shouldDouble = !shouldDouble;
        }

        return digitCount > 1 && sum % 10 == 0;
    }
}
