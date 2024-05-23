using WowMessages.Generator.Generated;

namespace WowMessages.Generator.Extensions;

public static class IntegerTypeExtensions
{
    public static string CsType(this IntegerType it)
        =>
            it switch
            {
                IntegerType.I8 => "sbyte",
                IntegerType.I16 => "short",
                IntegerType.I32 => "int",
                IntegerType.I64 => "long",
                IntegerType.U16 => "ushort",
                IntegerType.U32 => "uint",
                IntegerType.U64 => "ulong",
                IntegerType.U8 => "byte",
                _ => throw new ArgumentOutOfRangeException(nameof(it), it, null)
            };

    public static string ReadFunction(this IntegerType it) =>
        it switch
        {
            IntegerType.I8 => "ReadSByte",
            IntegerType.I16 => "ReadShort",
            IntegerType.I32 => "ReadInt",
            IntegerType.I64 => "ReadLong",
            IntegerType.U8 => "ReadByte",
            IntegerType.U16 => "ReadUShort",
            IntegerType.U32 => "ReadUInt",
            IntegerType.U48 => "ReadU48",
            IntegerType.U64 => "ReadULong",
            _ => throw new ArgumentOutOfRangeException(nameof(it), it, null)
        };

    public static string WriteFunction(this IntegerType it) =>
        it switch
        {
            IntegerType.I8 => "WriteSByte",
            IntegerType.I16 => "WriteShort",
            IntegerType.I32 => "WriteInt",
            IntegerType.I64 => "WriteLong",
            IntegerType.U8 => "WriteByte",
            IntegerType.U16 => "WriteUShort",
            IntegerType.U32 => "WriteUInt",
            IntegerType.U48 => "WriteU48",
            IntegerType.U64 => "WriteULong",
            _ => throw new ArgumentOutOfRangeException(nameof(it), it, null)
        };

    public static int SizeBytes(this IntegerType it) =>
        it switch
        {
            IntegerType.U8 or IntegerType.I8 => 1,
            IntegerType.I16 or IntegerType.U16 => 2,
            IntegerType.I32 or IntegerType.U32 => 4,
            IntegerType.I64 or IntegerType.U64 => 8,
            IntegerType.U48 => 6,
            _ => throw new ArgumentOutOfRangeException(nameof(it), it, null)
        };

    public static int SizeBits(this IntegerType it) => it.SizeBytes() * 8;
}