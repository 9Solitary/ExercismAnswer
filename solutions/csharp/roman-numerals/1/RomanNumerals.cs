using System.Text;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int value)
    {
        StringBuilder result = new StringBuilder();
        Dictionary<int, string> dict = new Dictionary<int, string>
        {
            [1000] = "M",
            [900] = "CM",
            [500] = "D",
            [400] = "CD",
            [100] = "C",
            [90] = "XC",
            [50] = "L",
            [40] = "XL",
            [10] = "X",
            [9] = "IX",
            [5] = "V",
            [4] = "IV",
            [1] = "I"
        };

        int valueNow = value;
        foreach (int number in dict.Keys)
        {
            int frequency = valueNow / number;
            int nextNumber = valueNow % number;
            for (int i = frequency; i > 0; i--)
            {
                result.Append(dict[number]);
            }
            valueNow = nextNumber;
        }

        return result.ToString();
    }
}