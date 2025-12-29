public class Anagram
{
    string baseWord;

    public Anagram(string baseWord)
    {
        this.baseWord = baseWord.ToLower();
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> matches = new List<string>();
        for (int i = 0; i < potentialMatches.Length; i++)
        {
            string testWord = potentialMatches[i].ToLower();
            if (testWord.Length == baseWord.Length && testWord != baseWord)
            {

                char[] charTest = testWord.ToCharArray();
                char[] charBase = baseWord.ToCharArray();
                Array.Sort(charTest);
                Array.Sort(charBase);

                if (new string(charTest) == new string(charBase))
                    matches.Add(potentialMatches[i]);
            }
        }
        return matches.ToArray();
    }
}