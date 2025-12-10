public static class LogAnalysis
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string log)
    {
        return str[(str.IndexOf(log) + log.Length)..];
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string str, string first, string last)
    {
        int first1 = str.IndexOf(first) + first.Length;
        int last1 = str.LastIndexOf(last);
        return str.Substring(first1, last1 - first1);
    }
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str)
    {
        return str.SubstringAfter(":").Trim();
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}