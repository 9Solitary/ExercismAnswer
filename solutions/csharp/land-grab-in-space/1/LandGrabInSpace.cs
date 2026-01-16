public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Plot(Coord p1, Coord p2, Coord p3, Coord p4)
    {
        P1 = p1;
        P2 = p2;
        P3 = p3;
        P4 = p4;
    }
    public Coord P1 { get; }
    public Coord P2 { get; }
    public Coord P3 { get; }
    public Coord P4 { get; }

    public readonly int LongestSide()
    {
        int length = P2.X - P1.X;
        int width = P3.Y - P1.Y;
        if (length > width)
            return length;
        else return width;
    }
}


public class ClaimsHandler
{
    List<Plot> plots = new();
    public void StakeClaim(Plot plot)
    {
        plots.Add(plot);
    }

    public bool IsClaimStaked(Plot plot)
    {
        bool isClaimStaked = false;
        for (int i = 0; i < plots.Count; i++)
        {
            if (Equals(plots[i], plot))
            {
                isClaimStaked = true;
                break;
            }
        }
        return isClaimStaked;
    }

    public bool IsLastClaim(Plot plot)
    {
        int lastPlot = plots.Count - 1;
        if (Equals(plots[lastPlot], plot))
            return true;
        else return false;
    }

    public Plot GetClaimWithLongestSide()
    {
        List<int> longestSide = new();
        for (int i = 0; i < plots.Count; i++)
        {
            longestSide.Add(plots[i].LongestSide());
        }
        int longestIndex = longestSide.IndexOf(longestSide.Max());
        Plot longestSidePlot = plots[longestIndex];
        return longestSidePlot;
    }
}
