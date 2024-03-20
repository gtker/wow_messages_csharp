using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.Extensions;

public static class ArrayTypeExtensions
{
    public static string CsType(this ArrayType t) =>
        t switch
        {
            ArrayTypeCstring => "string",
            ArrayTypeGuid => "ulong",
            ArrayTypeInteger arrayTypeInteger => arrayTypeInteger.IntegerType.CsType(),
            ArrayTypePackedGuid => "ulong",
            ArrayTypeSpell => "uint",
            ArrayTypeStruct arrayTypeStruct => arrayTypeStruct.StructData.Name,
            _ => throw new ArgumentOutOfRangeException(nameof(t))
        };
}