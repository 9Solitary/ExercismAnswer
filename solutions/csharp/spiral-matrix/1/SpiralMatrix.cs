public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {

        int top = 0;
        int bottom = size - 1;
        int left = 0;
        int right = size - 1;
        int number = 1;
        int[,] matrix = new int[size, size];
        while (left <= right && top <= bottom)
        {
            for (int j = left; j <= right; j++)
            {
                matrix[top, j] = number;
                number++;
            }
            top++;
            for (int i = top; i <= bottom; i++)
            {
                matrix[i, right] = number;
                number++;
            }
            right--;
            for (int j = right; j >= left; j--)
            {
                matrix[bottom, j] = number;
                number++;
            }
            bottom--;
            for (int i = bottom; i >= top; i--)
            {
                matrix[i, left] = number;
                number++;
            }
            left++;
        }
        return matrix;
    }
}
