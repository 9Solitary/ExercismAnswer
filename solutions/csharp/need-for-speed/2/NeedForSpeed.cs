class RemoteControlCar
{
    // TODO: define the constructor for the 'RemoteControlCar' class

    public int speed;
    private int batteryDrain;
    private int distance;
    private int driveDistance;
    private int battery = 100;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }
    public bool BatteryDrained()
    {
        if (battery >= batteryDrain)
            return false;
        else return true;
    }

    public int DistanceDriven() => driveDistance;

    public void Drive()
    {
        battery -= batteryDrain;
        if (battery >= 0)
        {
            driveDistance += speed;
        }
    }

    public static RemoteControlCar Nitro()
    {
        var nitro = new RemoteControlCar(50, 4);
        return nitro;
    }
}

class RaceTrack
{
    // TODO: define the constructor for the 'RaceTrack' class
    int distance;
    public RaceTrack(int distance)
    {
        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        int runTime = distance / car.speed;
        while (runTime > 0)
        {
            car.Drive();
            runTime--;
        }
        return distance == car.DistanceDriven();
    }
}
