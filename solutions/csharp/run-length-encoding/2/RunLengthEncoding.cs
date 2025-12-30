using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        var result = new StringBuilder();

        char currentChar = input[0];
        int runLength = 1;

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == currentChar)
            {
                runLength++;
            }
            else
            {
                AppendRun(result, currentChar, runLength);

                currentChar = input[i];
                runLength = 1;
            }
        }

        // 输出最后一个 run（必然存在）
        AppendRun(result, currentChar, runLength);

        return result.ToString();
    }

    private static void AppendRun(StringBuilder sb, char character, int count)
    {
        if (count > 1)
            sb.Append(count);

        sb.Append(character);
    }

    public static string Decode(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        var result = new StringBuilder();
        int repeatCount = 0;

        foreach (char ch in input)
        {
            if (char.IsDigit(ch))
            {
                repeatCount = repeatCount * 10 + (ch - '0');
            }
            else
            {
                int times = repeatCount > 0 ? repeatCount : 1;
                result.Append(ch, times);
                repeatCount = 0;
            }
        }

        return result.ToString();
    }

}
