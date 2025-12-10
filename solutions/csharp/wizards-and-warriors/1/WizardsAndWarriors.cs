abstract class Character
{
    string characterType;
    protected Character(string characterType)
    {
        this.characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString()
    {

        return $"Character is a {characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable() == true)
            return 10;
        else return 6;
    }
}

class Wizard : Character
{
    bool isPrepared = false;
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (isPrepared == true)
            return 12;
        else return 3;
    }

    public void PrepareSpell()
    {
        isPrepared = true;
    }

    public override bool Vulnerable()
    {
        if (isPrepared == true)
            return false;
        else return true;
    }
}
