using System;
using System.Text;

public class Robot
{
    static readonly Random rnd = new Random();
    static HashSet<string> robotNames = new HashSet<string>();
    string name;
    public string Name
    {
        get
        {
            if (name == null)
                name = CreateId();
            return name;
        }
    }

    public void Reset()
    {
        if (name != null)
            robotNames.Remove(name);
        name = null;
    }

    private string CreateId()
    {
        string newName;
        do
        {
            int randomAlphabet = rnd.Next(26);
            char letter1 = (char)('A' + randomAlphabet);
            char letter2 = (char)('A' + randomAlphabet);
            int digit1 = rnd.Next(10);
            int digit2 = rnd.Next(10);
            int digit3 = rnd.Next(10);

            newName = $"{letter1}{letter2}{digit1}{digit2}{digit3}";
        } while (robotNames.Contains(newName));
        robotNames.Add(newName);
        return newName;
    }
}