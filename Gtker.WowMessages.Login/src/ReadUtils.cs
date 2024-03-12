using System.Text;
using Gtker.WowMessages.Login.All;

namespace Gtker.WowMessages.Login;

public static class ReadUtils
{
    public static async Task<byte> ReadByte(Stream r,
        CancellationToken cancellationToken
    )
    {
        var b = new byte[1];
        await r.ReadExactlyAsync(b, cancellationToken);

        return b[0];
    }

    public static async Task<ushort> ReadUShort(Stream r,
        CancellationToken cancellationToken
    )
    {
        var b = new byte[2];
        await r.ReadExactlyAsync(b, cancellationToken);

        return (ushort)(b[0] | (b[1] << 8));
    }

    public static async Task<uint> ReadUInt(Stream r, CancellationToken cancellationToken)
    {
        var b = new byte[4];
        await r.ReadExactlyAsync(b, cancellationToken);

        return (uint)(b[0] | (b[1] << 8) | (b[2] << 16) | (b[3] << 24));
    }

    public static async Task<ulong> ReadULong(Stream r, CancellationToken cancellationToken)
    {
        var b = new byte[8];
        await r.ReadExactlyAsync(b, cancellationToken);

        return b[0] | ((ulong)b[1] << 8) | ((ulong)b[2] << 16) | ((ulong)b[3] << 24) | ((ulong)b[4] << 32) |
               ((ulong)b[5] << 40) | ((ulong)b[6] << 48) |
               ((ulong)b[7] << 56);
    }

    public static async Task<bool> ReadBool8(Stream r, CancellationToken cancellationToken) =>
        await ReadByte(r, cancellationToken) switch
        {
            1 => true,
            0 => false,
            _ => throw new ArgumentOutOfRangeException()
        };

    public static async Task<bool> ReadBool16(Stream r, CancellationToken cancellationToken) =>
        await ReadUShort(r, cancellationToken) switch
        {
            1 => true,
            0 => false,
            _ => throw new ArgumentOutOfRangeException()
        };

    public static async Task<bool> ReadBool32(Stream r, CancellationToken cancellationToken) =>
        await ReadUInt(r, cancellationToken) switch
        {
            1 => true,
            0 => false,
            _ => throw new ArgumentOutOfRangeException()
        };

    public static async Task<string> ReadString(Stream r, CancellationToken cancellationToken)
    {
        var length = await ReadByte(r, cancellationToken);
        var s = new StringBuilder();

        for (byte i = 0; i < length; ++i)
        {
            s.Append((char)await ReadByte(r, cancellationToken));
        }

        return s.ToString();
    }

    public static async Task<string> ReadCString(Stream r, CancellationToken cancellationToken)
    {
        var s = new StringBuilder();
        var b = await ReadByte(r, cancellationToken);

        while (b != 0)
        {
            s.Append((char)b);
            b = await ReadByte(r, cancellationToken);
        }

        return s.ToString();
    }


    public static async Task<Population> ReadPopulation(Stream r, CancellationToken cancellationToken)
    {
        var b = await ReadUInt(r, cancellationToken);
        var f = BitConverter.ToSingle(BitConverter.GetBytes(b), 0);

        return new Population(f);
    }
}