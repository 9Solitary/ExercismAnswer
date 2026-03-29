public class Player
{
    Random rnd = new();
    public int RollDie()
    {
        int diceResult = rnd.Next(1, 19);
        return diceResult;
    }

    public double GenerateSpellStrength()
    {
        double diceResult = rnd.NextDouble();
        return diceResult * 100;
    }
}
