using Generator.Generated;

namespace Generator.Extensions;

public static class ByteTypeExtensions
{
    public static string CsType(this ByteType d) => d.InnerType switch
    {
        ByteTypeInnerTypeByte => "byte",
        ByteTypeInnerTypeDefiner definer => definer.ByteType,
        _ => throw new ArgumentOutOfRangeException()
    };
}