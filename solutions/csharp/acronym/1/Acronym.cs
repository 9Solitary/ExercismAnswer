using System.Text;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        string[] phraseSplit = phrase.Split(' ', '-');
        StringBuilder sb = new StringBuilder();

        foreach (string text in phraseSplit)
        {
            if (text != null)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (char.IsLetter(text[i]))
                    {
                        string newText = text[i].ToString().ToUpper();
                        sb.Append(newText);
                        break;
                    }
                }
            }
        }
        return sb.ToString().Trim();
    }
}