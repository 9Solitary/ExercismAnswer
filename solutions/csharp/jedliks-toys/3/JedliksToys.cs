using System.Diagnostics.Metrics;

class RemoteControlCar
{
    int Meters = 0;
    int Percentage = 100;
    public static RemoteControlCar Buy() => new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {Meters} meters";


    public string BatteryDisplay()
    {
        if (Percentage > 0)
            return $"Battery at {Percentage}%";
        else return $"Battery empty";
    }

    public void Drive()
    {
        if (Percentage > 0)
        {
            Meters = Meters + 20;
            Percentage = Percentage - 1;
        }
    }
}
