class WeighingMachine
{
    private int precision;
    public WeighingMachine(int precision)
    {
        this.precision = precision;
    }
    public int Precision
    {
        get { return precision; }
    }

    private double weight;
    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException();
            weight = value;
        }
    }

    public double TareAdjustment { get; set; } = 5;

    public string DisplayWeight
    {
        get
        {
            return (Weight - TareAdjustment).ToString("N" + precision) + " kg";
        }
    }

}
