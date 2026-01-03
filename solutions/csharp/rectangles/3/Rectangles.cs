public static class Rectangles
{
    public static int Count(string[] rows)
    {
        if (rows == null || rows.Length == 0)
            return 0;

        int totalRectangles = 0;

        for (int top = 0; top < rows.Length; top++)
        {
            for (int left = 0; left < rows[top].Length; left++)
            {
                if (rows[top][left] == '+')
                {
                    totalRectangles += CountRectanglesFromTopLeft(rows, top, left);
                }
            }
        }

        return totalRectangles;
    }

    // 对所有使用（top, left）作为左上角的矩形进行计数
    private static int CountRectanglesFromTopLeft(string[] rows, int top, int left)
    {
        int count = 0;

        for (int bottom = top + 1; bottom < rows.Length; bottom++)
        {
            if (rows[bottom][left] != '+')
                continue;

            for (int right = left + 1; right < rows[top].Length; right++)
            {
                if (!IsRectangleCorner(rows, top, left, bottom, right))
                    continue;

                if (HasValidHorizontalEdges(rows, top, bottom, left, right) &&
                    HasValidVerticalEdges(rows, top, bottom, left, right))
                {
                    count++;
                }
            }
        }

        return count;
    }

    private static bool IsRectangleCorner(
        string[] rows,
        int top,
        int left,
        int bottom,
        int right)
    {
        return rows[top][right] == '+'
            && rows[bottom][right] == '+';
    }

    private static bool HasValidHorizontalEdges(
        string[] rows,
        int top,
        int bottom,
        int left,
        int right)
    {
        for (int col = left + 1; col < right; col++)
        {
            if (!IsHorizontalEdge(rows[top][col]) ||
                !IsHorizontalEdge(rows[bottom][col]))
            {
                return false;
            }
        }

        return true;
    }

    private static bool HasValidVerticalEdges(
        string[] rows,
        int top,
        int bottom,
        int left,
        int right)
    {
        for (int row = top + 1; row < bottom; row++)
        {
            if (!IsVerticalEdge(rows[row][left]) ||
                !IsVerticalEdge(rows[row][right]))
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsHorizontalEdge(char c)
        => c == '-' || c == '+';

    private static bool IsVerticalEdge(char c)
        => c == '|' || c == '+';
}
