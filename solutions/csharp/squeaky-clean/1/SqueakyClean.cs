using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder sb = new StringBuilder(identifier);
        for (int i = sb.Length - 1; i >= 0; i--)
        {
            if (char.IsWhiteSpace(identifier[i]))
                sb[i] = '_';
            else if (char.IsControl(identifier[i]))
            {
                sb[i] = 'C';
                sb.Insert(i + 1, "TRL");
            }
            else if (identifier[i] == '-')
            {
                sb[i + 1] = char.ToUpper(sb[i + 1]);
                sb.Remove(i, 1);
            }
            else if (!char.IsLetter(identifier[i]))
            {
                sb.Remove(i, 1);
            }
            else if (identifier[i] >= 'α' && identifier[i] <= 'ω')
            {
                sb.Remove(i, 1);
            }
        }
        return sb.ToString();
    }
}
