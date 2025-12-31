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
                //检查行最大
                if (!IsRowMax(matrix, i, j, jMax))
                    continue;

                //检查列最小
                if (IsColMin(matrix, i, j, iMax))
                {
                    result.Add((i + 1, j + 1));  //记录位置
                }
            }
        }
        return result;
    }
    public static bool IsRowMax(int[,] matrix, int i, int j, int jMax)
    {
        for (int k = 0; k < jMax; k++)
        {
            if (matrix[i, j] < matrix[i, k] && k != j)
            {
                return false;
            }
        }
        return true;
    }

    public static bool IsColMin(int[,] matrix, int i, int j, int iMax)
    {
        for (int l = 0; l < iMax; l++)
        {
            if (matrix[i, j] > matrix[l, j] && i != l)
            {
                return false;
            }
        }
        return true;
    }

}
