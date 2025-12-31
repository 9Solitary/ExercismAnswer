public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        int iMax = matrix.GetLength(0);
        int jMax = matrix.GetLength(1);
        List<(int, int)> result = new List<(int, int)>();

        for (int i = 0; i < iMax; i++)
        {
            for (int j = 0; j < jMax; j++)
            {
                bool isRowMax = true;
                for (int k = 0; k < jMax; k++)
                {
                    if (matrix[i, j] < matrix[i, k] && k != j)
                    {
                        isRowMax = false;
                        break;
                    }
                }
                if (isRowMax == false)
                    continue;
                bool isColMin = true;
                for (int l = 0; l < iMax; l++)
                {
                    if (matrix[i, j] > matrix[l, j] && i != l)
                    {
                        isColMin = false;
                        break;
                    }
                }
                if (isColMin && isRowMax)
                    result.Add((i + 1, j + 1));

            }
        }
        return result;
    }
}
