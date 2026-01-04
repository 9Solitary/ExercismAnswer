public static class AtbashCipher
{
    public static string Encode(string plainValue)
    {
        string processedInput = plainValue.Replace(" ", "").ToLower();
        string output = string.Empty;

        foreach (char letter in processedInput)
        {
            if (char.IsLetter(letter))
            {
                char outputLetter = (char)('z' + 'a' - letter);
                output += outputLetter;
            }
            else if (char.IsDigit(letter))
            {
                output += letter;
            }
        }

        if (output.Length > 5)
        {
            for (int spacePos = 5; spacePos < output.Length; spacePos += 6)
            {
                output = output.Insert(spacePos, " ");
            }
        }

        return output;
    }

    public static string Decode(string encodedValue)
    {
        string processedInput = encodedValue.Replace(" ", "");
        string output = string.Empty;

        foreach (char letter in processedInput)
        {
            if (char.IsLetter(letter))
            {
                char outputLetter = (char)('z' + 'a' - letter);
                output += outputLetter;
            }
            else if (char.IsDigit(letter))
            {
                output += letter;
            }
        }

        return output;
    }
}
