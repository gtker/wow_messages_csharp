using WowMessages.Generator.Generated;

namespace WowMessages.Generator.Extensions;

public static class DataTypeArrayExtensions
{
    public static string CsType(this DataTypeArray array) =>
        $"List<{array.InnerType.CsType()}>";

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
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}