using WowMessages.Generator.Generated;

namespace WowMessages.Generator.Extensions;

public static class DataTypeArrayExtensions
{
    public static string CsType(this DataTypeArray array) =>
        $"List<{array.InnerType.CsType()}>";

    public static string ArraySize(this DataTypeArray array, Definition d)
    {
        switch (array.InnerType)
        {
            case ArrayTypeCstring:
                return $"{d.MemberName()}.Sum(e => e.Length)";
            case ArrayTypeGuid:
                return $"{d.MemberName()}.Sum(e => 8)";
            case ArrayTypeInteger it:
                return $"{d.MemberName()}.Sum(e => {it.IntegerType.SizeBytes()})";
            case ArrayTypeSpell:
                return $"{d.MemberName()}.Sum(e => 4)";
            case ArrayTypeStruct e:
                if (e.StructData.Sizes.ConstantSized)
                {
                    return $"{d.MemberName()}.Sum(e => {e.StructData.Sizes.MaximumSize})";
                }

                return $"{d.MemberName()}.Sum(e => e.Size())";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}