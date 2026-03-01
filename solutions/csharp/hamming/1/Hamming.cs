public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        int distance = 0;
        if (firstStrand.Length == secondStrand.Length)
        {
            int wordLength = firstStrand.Length;
            for (int i = 0; i < wordLength; i++)
            {
                if (firstStrand[i] != secondStrand[i])
                {
                    distance++;
                }
            }
            return distance;
        }
        else throw new ArgumentException("参数错误");
    }
}