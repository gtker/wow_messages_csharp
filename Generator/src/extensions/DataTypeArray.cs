using Generator.Generated;

namespace Generator.Extensions;

public static class DataTypeArrayExtensions
{
    public static string CsType(this DataTypeArray array)
    {
        return array.Size switch
        {
            ArraySizeEndless => $"List<{array.InnerType.CsType()}>",
            ArraySizeFixed => $"{array.InnerType.CsType()}[]",
            ArraySizeVariable => $"List<{array.InnerType.CsType()}>",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static string ArraySize(this DataTypeArray array, Definition d, string name, string prefix)
    {
        switch (array.InnerType)
        {
            case ArrayTypeCstring:
                return $"{prefix}{name}.Sum(e => e.Length)";
            case ArrayTypeGuid:
                return $"{prefix}{name}.Sum(e => 8)";
            case ArrayTypeInteger it:
                return $"{prefix}{name}.Sum(e => {it.IntegerType.SizeBytes()})";
            case ArrayTypeSpell:
                return $"{prefix}{name}.Sum(e => 4)";
            case ArrayTypeStruct e:
                if (e.StructData.Sizes.ConstantSized)
                {
                    return $"{prefix}{name}.Sum(e => {e.StructData.Sizes.MaximumSize})";
                }

                return $"{prefix}{name}.Sum(e => e.Size())";
            case ArrayTypePackedGuid:
                return $"{prefix}{name}.Sum(e => e.PackedGuidLength())";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public static bool FixedSize(this DataTypeArray array) => array.Size is ArraySizeFixed;
}