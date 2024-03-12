using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.Extensions;

public static class ArrayExtensions
{
    public static string ArraySize(this Array_ array, Definition d)
    {
        switch (array.InnerType)
        {
            case ArrayTypeCstring:
                return $"{d.MemberName()}.Sum(e => e.Length)";
            case ArrayTypeGuid:
                return $"{d.MemberName()}.Sum(e => 8)";
            case ArrayTypeInteger it:
                return $"{d.MemberName()}.Sum(e => {it.Content.SizeBytes()})";
            case ArrayTypeSpell:
                return $"{d.MemberName()}.Sum(e => 4)";
            case ArrayTypeStruct e:
                if (e.Content.StructData.Sizes.ConstantSized)
                {
                    return $"{d.MemberName()}.Sum(e => {e.Content.StructData.Sizes.MaximumSize})";
                }

                return $"{d.MemberName()}.Sum(e => e.Size())";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}