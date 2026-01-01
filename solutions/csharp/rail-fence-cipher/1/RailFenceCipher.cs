using System.Text;

public class RailFenceCipher
{
    List<StringBuilder> rows;
    int rails;
    int row = 0;
    int dir = 1;
    public RailFenceCipher(int rails)
    {
        this.rows = new List<StringBuilder>();
        this.rails = rails;
        for (int r = 0; r < rails; r++)
        {
            rows.Add(new StringBuilder());
        }
    }

    public string Encode(string input)
    {
        if (rails <= 1)
            return input;

        foreach (char c in input)
        {
            rows[row].Append(c);
            if (row == 0)
                dir = 1;
            if (row == rails - 1)
                dir = -1;
            row += dir;
        }

        var result = new StringBuilder();
        foreach (var sb in rows)
            result.Append(sb);
        return result.ToString();
    }

    public string Decode(string input)
    {
        if (rails <= 1)
            return input;

        row = 0;
        dir = 1;

        int[] railAt = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            railAt[i] = row;

            if (row == 0)
                dir = 1;
            else if (row == rails - 1)
                dir = -1;

            row += dir;
        }

        int[] count = new int[rails];
        for (int i = 0; i < railAt.Length; i++)
            count[railAt[i]]++;

        string[] text = new string[rails];
        int start = 0;

        for (int r = 0; r < rails; r++)
        {
            text[r] = input.Substring(start, count[r]);
            start += count[r];
        }

        int[] railPos = new int[rails];
        StringBuilder result = new StringBuilder();

        row = 0;
        dir = 1;

        for (int i = 0; i < input.Length; i++)
        {
            result.Append(text[row][railPos[row]]);
            railPos[row]++;

            if (row == 0)
                dir = 1;
            else if (row == rails - 1)
                dir = -1;

            row += dir;
        }

        return result.ToString();


    }
}