public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        string[] sentences = new string[subjects.Length];
        int proverbs = subjects.Length;
        for (int i = 0; i < subjects.Length; i++)
        {
            if (i == 0)
            {
                sentences[subjects.Length - 1] = $"And all for the want of a {subjects[0]}.";
            }
            if (i > 0)
            {
                sentences[i - 1] = $"For want of a {subjects[i - 1]} the {subjects[i]} was lost.";
            }
        }
        return sentences;
    }
}