using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        StringBuilder sb = new StringBuilder();
        int count = 0;

        if (input == "")
            return "";

        char memory = input[0];
        for (int i = 0; i < input.Length; i++)
        {
            if (memory == input[i])
            {
                count++;
            }
            else
            {
                if (count != 1)
                {
                    sb.Append(count);
                    sb.Append(memory);
                }
                else
                {
                    sb.Append(memory);
                }
                memory = input[i];
                count = 1;
            }
        }

        if (input[input.Length - 1] == input[input.Length - 2])
        {
            sb.Append(count);
            sb.Append(memory);
        }
        else
        {
            sb.Append(input[input.Length - 1]);
        }
        return sb.ToString();
    }

    public static string Decode(string input)
    {
        StringBuilder sb = new StringBuilder();
        if (input == "")
            return "";

        string memory = "";
        for (int i = 0; i < input.Length; i++)
        {
            if (Char.IsDigit(input[i]))
            {
                memory += input[i].ToString();
            }
            else if (memory != "")
            {
                sb.Append(input[i], int.Parse(memory));
                memory = "";
            }
            else sb.Append(input[i]);
        }

        return sb.ToString();
    }
}
