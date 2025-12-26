using System.Collections.Generic;

public static class BottleSong
{
    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        List<string> lines = new List<string>();
        string bottle;
        string bottleLast;

        Dictionary<int, string> numberWord = new Dictionary<int, string>
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

        for (int count = 1; count <= takeDown; count++)
        {
            switch (startBottles)
            {
                case 1:
                    bottle = "green bottle";
                    break;
                default:
                    bottle = "green bottles";
                    break;
            }
            switch (startBottles - 1)
            {
                case 1:
                    bottleLast = "green bottle";
                    break;
                default:
                    bottleLast = "green bottles";
                    break;
            }
            lines.Add($"{numberWord[startBottles]} {bottle} hanging on the wall,");
            lines.Add($"{numberWord[startBottles]} {bottle} hanging on the wall,");
            lines.Add($"And if one green bottle should accidentally fall,");
            lines.Add($"There'll be {numberWord[startBottles - 1].ToLower()} {bottleLast} hanging on the wall.");
            if (count != takeDown)
            {
                lines.Add("");
            }
            startBottles--;
        }
        return lines;
    }
}
