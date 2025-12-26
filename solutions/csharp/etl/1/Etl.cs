public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string, int> transform = new Dictionary<string, int>();
        foreach (var entry in old)
        {
            int key = entry.Key;
            foreach (string word in entry.Value)
            {
                transform.Add(word.ToLower(), key);
            }
        }
        return transform;
    }
}