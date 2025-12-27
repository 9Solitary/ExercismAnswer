using System.Text;

public static class Bob
{
    public static string Response(string statement)
    {
        switch (statement)
        {
            case string text when string.IsNullOrWhiteSpace(text):
                return "Fine. Be that way!";
            case string text when text.OnlyLetters().All(char.IsUpper) && text.EndsWith("?") && text.Any(char.IsLetter):
                return "Calm down, I know what I'm doing!";
            case string text when text.Trim().EndsWith("?"):
                return "Sure.";
            case string text when text.OnlyLetters().All(char.IsUpper) && text.Any(char.IsLetter):
                return "Whoa, chill out!";
            default:
                return "Whatever.";
        }
    }

    public static string OnlyLetters(this string str)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in str)
        {
            if (char.IsLetter(c))
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
}