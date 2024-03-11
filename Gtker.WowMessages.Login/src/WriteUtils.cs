using System.Text;
using Gtker.WowMessages.Login.All;

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

    public static async Task WriteUInt(Stream w, uint v)
    {
        var b = new byte[4];

        b[0] = (byte)(v & 0xFF);
        b[1] = (byte)((v >> 8) & 0xFF);
        b[2] = (byte)((v >> 16) & 0xFF);
        b[3] = (byte)((v >> 24) & 0xFF);

        await w.WriteAsync(b);
    }

    public static async Task WriteULong(Stream w, ulong v)
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

        await w.WriteAsync(b);
    }

    public static async Task WriteCString(Stream w, string v)
    {
        await w.WriteAsync(Encoding.UTF8.GetBytes(v));
        await WriteByte(w, 0);
    }

    public static async Task WriteString(Stream w, string v)
    {
        await WriteByte(w, (byte)v.Length);

        await w.WriteAsync(Encoding.UTF8.GetBytes(v));
    }

    public static async Task WritePopulation(Stream w, Population v)
    {
        await WriteFloat(w, v.Value);
    }

    public static async Task WriteFloat(Stream w, float v)
    {
        var s = BitConverter.ToUInt32(BitConverter.GetBytes(v));
        await WriteUInt(w, s);
    }

    public static async Task WriteBool8(Stream w, bool v)
    {
        await WriteByte(w, v ? (byte)1 : (byte)0);
    }

    public static async Task WriteBool16(Stream w, bool v)
    {
        await WriteUShort(w, v ? (ushort)1 : (ushort)0);
    }

    public static async Task WriteBool32(Stream w, bool v)
    {
        await WriteUInt(w, v ? 1 : (uint)0);
    }
}