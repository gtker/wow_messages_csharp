using Generator.Generated;

namespace Generator.Extensions;

public static class TwoShortType
{
    public static string CsType(this TwoShortTypeInnerType d) => d switch
    {
        TwoShortTypeInnerTypeDefiner definer => definer.TwoShortType,
        TwoShortTypeInnerTypeShort => "ushort",
        _ => throw new ArgumentOutOfRangeException(nameof(d))
    };
}