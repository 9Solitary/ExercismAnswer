public static class Rectangles
{
    public static int Count(string[] rows)
    {
        int count = 0;

        if (rows.Count() == 0)
            return 0;
        for (int i = 0; i < rows.Count(); i++)
        {
            for (int j = 0; j < rows[i].Length; j++)
            {
                if (rows[i][j] == '+')
                {
                    count += IsRectangle(rows, i, j);
                }
            }
        }
        return count;
    }

    public static int IsRectangle(string[] rows, int i, int j)
    {
        int count = 0;

        for (int rowIndex = i; rowIndex < rows.Count(); rowIndex++)
        {
            if (rows[rowIndex][j] == '+')
            {
                for (int colIndex = j; colIndex < rows[i].Length; colIndex++)
                {
                    if (rows[i][colIndex] == '+' && rows[rowIndex][colIndex] == '+' && rowIndex > i && colIndex > j)
                    {
                        if (IsRowRectangle(rows, i, j, rowIndex, colIndex) && IsColRectangle(rows, i, j, rowIndex, colIndex))
                        {
                            count++;
                        }
                    }
                }
            }
        }
        return count;
    }

    public static bool IsRowRectangle(string[] rows, int i, int j, int rowIndex, int colIndex)
    {
        bool isRowRectangle = true;

        if (rowIndex - i == 1)
        {
            return true;
        }
        else
        {
            for (int startIndex = j + 1; startIndex < colIndex; startIndex++)
            {
                if (rows[i][startIndex] is not ('-' or '+') || rows[rowIndex][startIndex] is not ('-' or '+'))
                    isRowRectangle = false;
            }
            return isRowRectangle;
        }
    }

    public static bool IsColRectangle(string[] rows, int i, int j, int rowIndex, int colIndex)
    {
        bool isColRectangle = true;

        if (colIndex - j == 1)
        {
            return true;
        }
        else
        {
            for (int startIndex = i + 1; startIndex < rowIndex; startIndex++)
            {
                if (rows[startIndex][j] is not ('|' or '+') || rows[startIndex][colIndex] is not ('|' or '+'))
                    isColRectangle = false;
            }
            return isColRectangle;
        }
    }
}