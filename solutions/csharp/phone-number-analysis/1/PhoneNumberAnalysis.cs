public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        bool IsNewYork = "212" == phoneNumber.Split("-")[0];
        bool IsFake = "555" == phoneNumber.Split("-")[1];
        string LocalNumber = phoneNumber.Split("-")[2];
        return (IsNewYork, IsFake, LocalNumber);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.Item2;
    }
}
