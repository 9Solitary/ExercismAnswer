public static class ReverseString
{
    public static string Reverse(string input)
    {
        string reverseString = new string(input.Reverse().ToArray());
        return reverseString;
    }
}