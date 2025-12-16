public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        char newChar;
        List<char> charList = new List<char>();
        foreach (char c in text.ToArray())
        {
            if (char.IsLetter(c))
            {
                if (char.IsLower(c))
                    newChar = (char)('a' + ((c - 'a' + shiftKey) % 26));
                else
                    newChar = (char)('A' + ((c - 'A' + shiftKey) % 26));
                charList.Add(newChar);
            }
            else charList.Add(c);
        }
        char[] chars = charList.ToArray();
        string result = new string(chars);
        if (shiftKey == 0)
            return text;
        else return result;
    }
}