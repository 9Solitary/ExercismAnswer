public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {

        int right = input.Length - 1;
        int left = 0;
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