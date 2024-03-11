namespace Gtker.WowMessages.Login;

public class WriteUtils
{
    public static async Task WriteByte(Stream w, byte v)
    {
        var b = new[] { v };

        await w.WriteAsync(b);
    }

    public static async Task WriteUShort(Stream w, ushort v)
    {
        var b = new byte[2];

        b[0] = (byte)(v & 0xFF);
        b[1] = (byte)((v >> 8) & 0xFF);

        await w.WriteAsync(b);
    }
}