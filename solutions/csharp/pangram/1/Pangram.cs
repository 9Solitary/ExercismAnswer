public static class Pangram
{
    public static bool IsPangram(string input)
    {
        char alpha = 'a';
        bool isPangram = true;
        for (char i = 'z'; i >= alpha; i--)
        {
            if (!input.ToLower().Contains(i))
            {
                isPangram = false;
                break;
            }
        }
        return isPangram;

    }
}
