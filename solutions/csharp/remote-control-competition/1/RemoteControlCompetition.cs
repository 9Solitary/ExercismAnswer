public interface IRemoteControlCar
{
    int DistanceTravelled { get; }
    void Drive();
}


public class ProductionRemoteControlCar : IRemoteControlCar, IComparable<ProductionRemoteControlCar>
{

    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public int CompareTo(ProductionRemoteControlCar? other)
    {
        if (other == null)
        {
            return 1;
        }
        else
        {
            int result = this.NumberOfVictories - other.NumberOfVictories;
            return result;
        }
    }

    public void Drive()
    {
        DistanceTravelled += 10;
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        List<ProductionRemoteControlCar> cars = new List<ProductionRemoteControlCar>();
        cars.Add(prc1);
        cars.Add(prc2);
        cars.Sort();
        return cars;
    }
}
