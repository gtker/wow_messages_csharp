using System.Text;

namespace WowWorldMessages;

internal static class ReadUtils
{
    internal static async Task<byte> ReadByte(this Stream r,
        CancellationToken cancellationToken
    )
    {
        var b = new byte[1];
        await r.ReadExactlyAsync(b, cancellationToken).ConfigureAwait(false);

        return b[0];
    }

    internal static async Task<ushort> ReadUShort(this Stream r,
        CancellationToken cancellationToken
    )
    {
        var b = new byte[2];
        await r.ReadExactlyAsync(b, cancellationToken).ConfigureAwait(false);

        return (ushort)(b[0] | (b[1] << 8));
    }

    internal static async Task<uint> ReadUInt(this Stream r, CancellationToken cancellationToken)
    {
        var b = new byte[4];
        await r.ReadExactlyAsync(b, cancellationToken).ConfigureAwait(false);

        return (uint)(b[0] | (b[1] << 8) | (b[2] << 16) | (b[3] << 24));
    }

    internal static async Task<int> ReadInt(this Stream r, CancellationToken cancellationToken) =>
        BitConverter.ToInt32(BitConverter.GetBytes(await r.ReadUInt(cancellationToken).ConfigureAwait(false)));

    internal static async Task<float> ReadFloat(this Stream r, CancellationToken cancellationToken)
    {
        var val = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        return BitConverter.ToSingle(BitConverter.GetBytes(val));
    }

    internal static async Task<ulong> ReadULong(this Stream r, CancellationToken cancellationToken)
    {
        var b = new byte[8];
        await r.ReadExactlyAsync(b, cancellationToken).ConfigureAwait(false);

        return b[0] | ((ulong)b[1] << 8) | ((ulong)b[2] << 16) | ((ulong)b[3] << 24) | ((ulong)b[4] << 32) |
               ((ulong)b[5] << 40) | ((ulong)b[6] << 48) |
               ((ulong)b[7] << 56);
    }

    internal static async Task<bool> ReadBool8(this Stream r, CancellationToken cancellationToken) =>
        await ReadByte(r, cancellationToken).ConfigureAwait(false) switch
        {
            1 => true,
            0 => false,
            _ => throw new ArgumentOutOfRangeException()
        };

    internal static async Task<bool> ReadBool16(this Stream r, CancellationToken cancellationToken) =>
        await ReadUShort(r, cancellationToken).ConfigureAwait(false) switch
        {
            1 => true,
            0 => false,
            _ => throw new ArgumentOutOfRangeException()
        };

    internal static async Task<bool> ReadBool32(this Stream r, CancellationToken cancellationToken) =>
        await ReadUInt(r, cancellationToken).ConfigureAwait(false) switch
        {
            1 => true,
            0 => false,
            _ => throw new ArgumentOutOfRangeException()
        };

    internal static async Task<string> ReadCString(this Stream r, CancellationToken cancellationToken)
    {
        var s = new StringBuilder();
        var b = await ReadByte(r, cancellationToken).ConfigureAwait(false);

        while (b != 0)
        {
            s.Append((char)b);
            b = await ReadByte(r, cancellationToken).ConfigureAwait(false);
        }

        return s.ToString();
    }


    internal static async Task<string> ReadSizedCString(this Stream r, CancellationToken cancellationToken)
    {
        var length = await r.ReadUInt(cancellationToken).ConfigureAwait(false);
        var array = new byte[length - 1];
        await r.ReadExactlyAsync(array, cancellationToken).ConfigureAwait(false);

        // Null terminator
        _ = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return Encoding.UTF8.GetString(array);
    }

    internal static async Task<ulong> ReadPackedGuid(this Stream r, CancellationToken cancellationToken)
    {
        var header = await r.ReadByte(cancellationToken).ConfigureAwait(false);
        ulong value = 0;
        for (var i = 0; i < 8; i++)
        {
            if ((header & (1 << i)) != 0)
            {
                var b = await r.ReadByte(cancellationToken).ConfigureAwait(false);
                value |= (ulong)b << (i * 8);
            }
        }

        return value;
    }

    internal static ulong ULongFromUInt(uint lower, uint upper) => ((ulong)upper << 32) | lower;

    internal static uint UIntFromUShort(ushort lower, ushort upper) => ((uint)upper << 16) | lower;

    internal static (ushort, ushort) UShortFromUInt(uint value)
    {
        var lower = (ushort)value;
        var upper = (ushort)(value >> 16);

        return (lower, upper);
    }

    internal static (byte, byte, byte, byte) BytesFromUInt(uint value)
    {
        var bytes = BitConverter.GetBytes(value);

        return (bytes[0], bytes[1], bytes[2], bytes[3]);
    }

    internal static uint UIntFromBytes(byte first, byte second, byte third, byte fourth) =>
        BitConverter.ToUInt32([first, second, third, fourth]);
}