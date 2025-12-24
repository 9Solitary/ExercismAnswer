public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {

        int right = input.Length - 1;
        int left = 0;
        if (input.Length == 0)
            return -1;
        else if (input[0] > value || input[right] < value)
            return -1;
        else if (input[0] == value)
            return 0;
        else
        {
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (input[mid] == value)
                    return mid;
                if (input[mid] < value)
                {
                    left = mid + 1;
                }
                if (input[mid] > value)
                {
                    right = mid - 1;
                }
            }
            return -1;
        }
    }
}