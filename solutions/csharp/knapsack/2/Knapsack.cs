public static class Knapsack
{
    public static int MaximumValue(int maximumWeight, (int weight, int value)[] items)
    {
        int[] values = new int[maximumWeight + 1];
        for (int i = 0; i < items.Length; i++)
        {
            for (int j = maximumWeight; j >= items[i].weight; j--)
            {
                if (j - items[i].weight >= 0 && values[j] < (values[j - items[i].weight] + items[i].value))
                {
                    values[j] = values[j - items[i].weight] + items[i].value;
                }
            }
        }
        return values.Max();
    }
}
