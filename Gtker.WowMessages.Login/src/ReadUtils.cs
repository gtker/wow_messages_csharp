using System.Text;
using Gtker.WowMessages.Login.All;

namespace Gtker.WowMessages.Login;

public static class ReadUtils
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

    public static async Task<ulong> ReadULong(Stream r)
    {
        var b = new byte[8];
        var bytesRead = 0;
        while (bytesRead != 8)
        {
            bytesRead += await r.ReadAsync(b);
        }

        return b[0] | ((ulong)b[1] << 8) | ((ulong)b[2] << 16) | ((ulong)b[3] << 24) | ((ulong)b[4] << 32) |
               ((ulong)b[5] << 40) | ((ulong)b[6] << 48) |
               ((ulong)b[7] << 56);
    }

    public static async Task<bool> ReadBool8(Stream r) =>
        await ReadByte(r) switch
        {
            1 => true,
            0 => false,
            _ => throw new ArgumentOutOfRangeException()
        };

    public static async Task<bool> ReadBool16(Stream r) =>
        await ReadUShort(r) switch
        {
            1 => true,
            0 => false,
            _ => throw new ArgumentOutOfRangeException()
        };

    public static async Task<bool> ReadBool32(Stream r) =>
        await ReadUInt(r) switch
        {
            1 => true,
            0 => false,
            _ => throw new ArgumentOutOfRangeException()
        };

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

    public static async Task<string> ReadCString(Stream r)
    {
        var s = new StringBuilder();
        var b = await ReadByte(r);

        while (b != 0)
        {
            s.Append((char)b);
            b = await ReadByte(r);
        }

        return s.ToString();
    }


    public static async Task<Population> ReadPopulation(Stream r)
    {
        var b = await ReadUInt(r);
        var f = BitConverter.ToSingle(BitConverter.GetBytes(b), 0);

        return new Population(f);
    }
}