namespace WowWorldMessages;

public static class UpdateMaskUtils
{
    internal static void AddUInt(IDictionary<ushort, uint> values, ushort offset, uint value)
    {
        values[offset] = value;
    }

    internal static uint? GetUInt(IDictionary<ushort, uint> values, ushort offset)
    {
        if (values.TryGetValue(offset, out var value))
        {
            return value;
        }

        return null;
    }

    internal static void AddFloat(IDictionary<ushort, uint> values, ushort offset, float value)
    {
        AddUInt(values, offset, BitConverter.ToUInt32(BitConverter.GetBytes(value)));
    }

    internal static float? GetFloat(IDictionary<ushort, uint> values, ushort offset)
    {
        if (GetUInt(values, offset) is { } val)
        {
            return BitConverter.ToSingle(BitConverter.GetBytes(val));
        }

        return null;
    }

    internal static void AddGuid(IDictionary<ushort, uint> values, ushort offset, ulong value)
    {
        AddUInt(values, offset, value.LowerUInt());
        offset += 1;
        AddUInt(values, offset, value.UpperUInt());
    }

    internal static ulong? GetGuid(IDictionary<ushort, uint> values, ushort offset)
    {
        var lower = GetUInt(values, offset);
        offset += 1;
        var upper = GetUInt(values, offset);

        if ((lower, upper) is (null, null))
        {
            return null;
        }

        return ReadUtils.ULongFromUInt(lower ?? 0, upper ?? 0);
    }

    internal static void AddTwoShort(IDictionary<ushort, uint> values, ushort offset, ushort first, ushort second)
    {
        AddUInt(values, offset, ReadUtils.UIntFromUShort(first, second));
    }

    internal static (ushort, ushort)? GetTwoShort(IDictionary<ushort, uint> values, ushort offset)
    {
        if (GetUInt(values, offset) is { } value)
        {
            return ReadUtils.UShortFromUInt(value);
        }

        return null;
    }

    internal static void AddBytes(IDictionary<ushort, uint> values, ushort offset, byte first, byte second, byte third,
        byte fourth)
    {
        AddUInt(values, offset, ReadUtils.UIntFromBytes(first, second, third, fourth));
    }

    internal static (byte, byte, byte, byte)? GetBytes(IDictionary<ushort, uint> values, ushort offset)
    {
        if (GetUInt(values, offset) is { } value)
        {
            return ReadUtils.BytesFromUInt(value);
        }

        return null;
    }
}