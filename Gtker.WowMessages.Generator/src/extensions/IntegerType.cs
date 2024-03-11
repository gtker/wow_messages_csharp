using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.Extensions;

public static class IntegerTypeExtensions
{
    public static string CsType(this IntegerType it)
        =>
            it switch
            {
                IntegerType.I16 => "short",
                IntegerType.I32 => "int",
                IntegerType.I64 => "long",
                IntegerType.I8 => "sbyte",
                IntegerType.U16 => "ushort",
                IntegerType.U32 => "uint",
                IntegerType.U64 => "ulong",
                IntegerType.U8 => "byte",
                _ => throw new ArgumentOutOfRangeException(nameof(it), it, null)
            };
}