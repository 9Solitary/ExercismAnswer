using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public static class BottleSong
{
    static Dictionary<int, string> numberWord = new Dictionary<int, string>
    {
        [0] = "No",
        [1] = "One",
        [2] = "Two",
        [3] = "Three",
        [4] = "Four",
        [5] = "Five",
        [6] = "Six",
        [7] = "Seven",
        [8] = "Eight",
        [9] = "Nine",
        [10] = "Ten"

    };

    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {


        List<string> lines = new List<string>();


        for (int count = 1; count <= takeDown; count++)
        {
            lines.Add($"{numberWord[startBottles]} {BottleWord(startBottles)} hanging on the wall,");
            lines.Add($"{numberWord[startBottles]} {BottleWord(startBottles)} hanging on the wall,");
            lines.Add($"And if one green bottle should accidentally fall,");
            lines.Add($"There'll be {numberWord[startBottles - 1].ToLower()} {BottleWord(startBottles - 1)} hanging on the wall.");
            if (count != takeDown)
            {
                lines.Add("");
            }
            startBottles--;
        }
        return lines;
    }
    public static string BottleWord(int count)
    {
        switch (count)
        {
            case 1:
                return "green bottle";
            default:
                return "green bottles";
        }
    }
}
