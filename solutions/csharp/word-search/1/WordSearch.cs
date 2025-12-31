public class WordSearch
{
    string[] rows;
    int rowCounts;
    int colCounts;
    int[,] directions = new int[8, 2]
    {
    {0, 1},   // 下⬇️
    {0, -1},  // 上⬆️
    {1, 0},   // 右➡️
    {-1, 0},  // 左⬅️
    {1, 1},   // 右下↘️
    {-1, 1},  // 左下↙️
    {1, -1},  // 右上↗️
    {-1, -1}  // 左上↖️
    };
    public WordSearch(string grid)
    {
        this.rows = grid.Split("\n");
        rowCounts = this.rows.Length;
        colCounts = this.rows[0].Length;
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        Dictionary<string, ((int, int), (int, int))?> result = new Dictionary<string, ((int, int), (int, int))?>();
        foreach (string w in wordsToSearchFor)
        {
            for (int i = 0; i < rowCounts; i++)
            {
                for (int j = 0; j < colCounts; j++)
                {
                    if (rows[i][j] != w[0])
                        continue;
                    for (int d = 0; d < 8; d++)
                    {
                        int rowMove = directions[d, 0];
                        int colMove = directions[d, 1];
                        bool isMatch = true;
                        for (int step = 1; step < w.Length; step++)
                        {
                            int newRow = i + step * rowMove;
                            int newCol = j + step * colMove;
                            //检查范围
                            if (!Check(newRow, newCol))
                            {
                                isMatch = false;
                                break;
                            }
                            //检查匹配
                            else if (rows[newRow][newCol] != w[step])
                            {
                                isMatch = false;
                                break;
                            }
                        }
                        if (isMatch)
                        {
                            int endRow = i + (w.Length - 1) * rowMove;
                            int endCol = j + (w.Length - 1) * colMove;

                            result.Add(w, ((j + 1, i + 1), (endCol + 1, endRow + 1)));
                            continue;
                        }
                    }
                }
            }
            if (!result.ContainsKey(w))
                result.Add(w, null);
        }
        return result;
    }

    public bool Check(int newRow, int newCol)
    {
        if (newRow < 0 || newRow >= rowCounts || newCol < 0 || newCol >= colCounts)
            return false;
        else return true;
    }
}