using System.Text;
using WowLoginMessages.All;

namespace WowLoginMessages;

internal static class WriteUtils
{
    public static async Task WriteByte(this Stream w, byte v, CancellationToken cancellationToken)
    {
        var b = new[] { v };

        await w.WriteAsync(b, cancellationToken).ConfigureAwait(false);
    }

    public static async Task WriteUShort(this Stream w, ushort v, CancellationToken cancellationToken)
    {
        var b = new byte[2];

        b[0] = (byte)(v & 0xFF);
        b[1] = (byte)((v >> 8) & 0xFF);

        await w.WriteAsync(b, cancellationToken).ConfigureAwait(false);
    }

    public static async Task WriteUInt(this Stream w, uint v, CancellationToken cancellationToken)
    {
        var b = new byte[4];

        b[0] = (byte)(v & 0xFF);
        b[1] = (byte)((v >> 8) & 0xFF);
        b[2] = (byte)((v >> 16) & 0xFF);
        b[3] = (byte)((v >> 24) & 0xFF);

        await w.WriteAsync(b, cancellationToken).ConfigureAwait(false);
    }

    public static async Task WriteULong(this Stream w, ulong v, CancellationToken cancellationToken)
    {
        var b = new byte[8];

        b[0] = (byte)(v & 0xFF);
        b[1] = (byte)((v >> 8) & 0xFF);
        b[2] = (byte)((v >> 16) & 0xFF);
        b[3] = (byte)((v >> 24) & 0xFF);
        b[4] = (byte)((v >> 32) & 0xFF);
        b[5] = (byte)((v >> 40) & 0xFF);
        b[6] = (byte)((v >> 48) & 0xFF);
        b[7] = (byte)((v >> 56) & 0xFF);

        await w.WriteAsync(b, cancellationToken).ConfigureAwait(false);
    }

    public static async Task WriteCString(this Stream w, string v, CancellationToken cancellationToken)
    {
        await w.WriteAsync(Encoding.UTF8.GetBytes(v), cancellationToken).ConfigureAwait(false);
        await WriteByte(w, 0, cancellationToken).ConfigureAwait(false);
    }

    public static async Task WriteString(this Stream w, string v, CancellationToken cancellationToken)
    {
        await WriteByte(w, (byte)v.Length, cancellationToken).ConfigureAwait(false);

        await w.WriteAsync(Encoding.UTF8.GetBytes(v), cancellationToken).ConfigureAwait(false);
    }

    public static async Task WritePopulation(this Stream w, Population v, CancellationToken cancellationToken)
    {
        await WriteFloat(w, v.Value, cancellationToken).ConfigureAwait(false);
    }

    public static async Task WriteFloat(this Stream w, float v, CancellationToken cancellationToken)
    {
        var s = BitConverter.ToUInt32(BitConverter.GetBytes(v));
        await WriteUInt(w, s, cancellationToken).ConfigureAwait(false);
    }

    public static async Task WriteBool8(this Stream w, bool v, CancellationToken cancellationToken)
    {
        await WriteByte(w, v ? (byte)1 : (byte)0, cancellationToken).ConfigureAwait(false);
    }

    public static async Task WriteBool16(this Stream w, bool v, CancellationToken cancellationToken)
    {
        await WriteUShort(w, v ? (ushort)1 : (ushort)0, cancellationToken).ConfigureAwait(false);
    }

    public static async Task WriteBool32(this Stream w, bool v, CancellationToken cancellationToken)
    {
        await WriteUInt(w, v ? 1 : (uint)0, cancellationToken).ConfigureAwait(false);
    }
}