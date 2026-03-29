static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if (balance >= 0 && balance < 1000)
            return 0.5f;
        if (balance < 5000 && balance >= 1000)
            return 1.621f;
        if (balance >= 5000)
            return 2.475f;
        else return 3.213f;
    }

    public static decimal Interest(decimal balance)
    {
        return balance * (0.01m * (decimal)InterestRate(balance));
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int year = 0;
        while (balance < targetBalance)
        {
            balance = AnnualBalanceUpdate(balance);
            year++;
        }
        return year;
    }
}
