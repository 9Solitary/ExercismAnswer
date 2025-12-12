public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];
        byte[] payload;
        byte prefix;

        if (reading >= 0 && reading <= ushort.MaxValue)
        {
            payload = BitConverter.GetBytes((ushort)reading);
            prefix = 2;
        }
        else if (reading >= short.MinValue && reading <= -1)
        {
            payload = BitConverter.GetBytes((short)reading);
            prefix = 256 - 2;
        }
        else if (reading >= int.MinValue && reading <= int.MaxValue)
        {
            payload = BitConverter.GetBytes((int)reading);
            prefix = 256 - 4;
        }
        else if (reading > int.MaxValue && reading <= uint.MaxValue)
        {
            payload = BitConverter.GetBytes((uint)reading);
            prefix = 4;
        }
        else
        {
            payload = BitConverter.GetBytes(reading);
            prefix = 256 - 8;
        }

        buffer[0] = prefix;
        Array.Copy(payload, 0, buffer, 1, payload.Length);
        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        byte prefix = buffer[0];
        if (buffer.Length < 9) return 0;

        switch (prefix)
        {
            case 2:
                return BitConverter.ToUInt16(buffer[1..]);
            case 4:
                return BitConverter.ToUInt32(buffer[1..]);
            case 254:
                return BitConverter.ToInt16(buffer[1..]);
            case 252:
                return BitConverter.ToInt32(buffer[1..]);
            case 248:
                return BitConverter.ToInt64(buffer[1..]);
            default:
                return 0;
        }
    }
}