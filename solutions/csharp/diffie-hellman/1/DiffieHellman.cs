using System.Numerics;
using System.Security.Cryptography;

public static class DiffieHellman
{
    public static BigInteger PrivateKey(BigInteger primeP)
        => GenerateRandomBigInteger(primeP);

    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey)
        => BigInteger.ModPow(primeG, privateKey, primeP);

    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey)
        => BigInteger.ModPow(publicKey, privateKey, primeP);

    public static BigInteger GenerateRandomBigInteger(BigInteger input)
    {
        BigInteger range = input - 1;
        int numBytes = range.ToByteArray().Length;
        byte[] randomBytes;
        BigInteger randomValue;

        do
        {
            //生成与范围长度相当的随机字节
            randomBytes = new byte[numBytes];
            RandomNumberGenerator.Fill(randomBytes);
            //字节转换为BigInteger，且确保是正数
            randomValue = new BigInteger(randomBytes, isUnsigned: true, isBigEndian: true);
        } while (randomValue >= range);

        return randomValue + 1;
    }
}