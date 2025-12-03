public class Player
{
    public int RollDie()
    {
        Random rnd = new();
        int diceResult = rnd.Next(1, 19);
        return diceResult;
    }

    public double GenerateSpellStrength()
    {
        Random rnd1 = new();
        Random rnd2 = new();
        int diceResult1 = rnd1.Next(0, 100);
        double diceResult2 = rnd2.NextDouble();
        return diceResult1 + diceResult2;
    }
}
