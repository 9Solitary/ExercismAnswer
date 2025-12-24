public static class ResistorColorDuo
{
    public static int Value(string[] colors)
    {
        string[] allColors = { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };
        char firstColor = (char)Array.IndexOf(allColors, colors[0]);
        char SecondColor = (char)Array.IndexOf(allColors, colors[1]);
        return firstColor * 10 + SecondColor;
    }
}
