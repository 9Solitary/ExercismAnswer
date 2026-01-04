public static class Luhn
{
    public static bool IsValid(string number)
    {
        string numberWithoutSpace = number.Replace(" ", "");
        if (IsAllNumber(numberWithoutSpace) && !IsSingleZero(numberWithoutSpace))
        {
            List<int> intVerifyNumberList = VerifyNumber(numberWithoutSpace);
            if (intVerifyNumberList.Sum() % 10 == 0)
                return true;
            else return false;
        }
        else return false;
    }

    public static bool IsAllNumber(string numberWithoutSpace)
        => numberWithoutSpace.All(char.IsDigit);

    public static bool IsOverTen(int singleNumber)
        => singleNumber >= 10;

    public static bool IsSingleZero(string numberWithoutSpace)
        => numberWithoutSpace.Length == 1 && int.Parse(numberWithoutSpace) == 0;

    public static int NumberResult(int singleNumber)
    {
        if (IsOverTen(singleNumber))
        {
            return singleNumber - 9;
        }
        else return singleNumber;
    }

    public static List<int> VerifyNumber(string numberWithoutSpace)
    {
        List<string> verifyNumber = new List<string>();
        bool isVerifyNeed = false;
        for (int pos = numberWithoutSpace.Length - 1; pos >= 0; pos--)
        {
            if (isVerifyNeed)
            {
                char numberChar = numberWithoutSpace[pos];
                int singleNumber = (int)(numberChar - '0') * 2;
                verifyNumber.Insert(0, NumberResult(singleNumber).ToString());
                isVerifyNeed = false;
            }
            else
            {
                verifyNumber.Insert(0, numberWithoutSpace[pos].ToString());
                isVerifyNeed = true;
            }
        }
        List<int> intVerifyNumberList = verifyNumber.ConvertAll(s => Convert.ToInt32(s));
        return intVerifyNumberList;
    }
}