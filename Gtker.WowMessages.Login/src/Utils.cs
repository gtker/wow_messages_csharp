using System.Text;

namespace Gtker.WowMessages.Login;

public static class Utils
{
    public static async Task<byte> ReadByte(Stream r)
    {
        var b = new byte[1];
        while (await r.ReadAsync(b) != 1)
        {
        }

        return b[0];
    }

    public static async Task<ushort> ReadUShort(Stream r)
    {
        var b = new byte[2];
        var bytesRead = 0;
        while (bytesRead != 2)
        {
            bytesRead += await r.ReadAsync(b);
        }

        return (ushort)(b[0] | (b[1] << 8));
    }

    public static async Task<uint> ReadUInt(Stream r)
    {
        var b = new byte[4];
        var bytesRead = 0;
        while (bytesRead != 4)
        {
            bytesRead += await r.ReadAsync(b);
        }

        return (uint)(b[0] | (b[1] << 8) | (b[2] << 16) | (b[3] << 24));
    }

    public static async Task<string> ReadString(Stream r)
    {
        var length = await ReadByte(r);
        var s = new StringBuilder();

        for (byte i = 0; i < length; ++i)
        {
            s.Append((char)await ReadByte(r));
        }

        return s.ToString();
    }
}