public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        char alpha = 'a';
        bool isIsogram = true;
        int count = 0;
        for (char i = 'z'; i >= alpha; i--)
        {
            count = 0;
            foreach (char c in word.ToLower())
            {
                if (c == i)
                    count++;
                if (count > 1)
                {
                    isIsogram = false;
                    break;
                }
            }
        }
        return isIsogram;

    }
}