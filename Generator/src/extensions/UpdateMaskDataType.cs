using Generator.Generated;

namespace Generator.Extensions;

public static class UpdateMaskDataTypeExtensions
{
    public static string CsReturnType(this UpdateMaskDataType d) => d switch
    {
        UpdateMaskDataTypeArrayOfStruct e => e.Content.VariableName,
        UpdateMaskDataTypeBytes => "(byte, byte, byte, byte)",
        UpdateMaskDataTypeFloat => "float",
        UpdateMaskDataTypeGuid => "ulong",
        UpdateMaskDataTypeInt => "uint",
        UpdateMaskDataTypeTwoShort => "(ushort, ushort)",
        UpdateMaskDataTypeGuidArrayUsingEnum => "Guid",
        _ => throw new ArgumentOutOfRangeException(nameof(d))
    };

    public static string CsArgument(this UpdateMaskDataType d) => d switch
    {
        UpdateMaskDataTypeArrayOfStruct e =>
            $"{e.Content.VariableName.ToPascalCase()} {e.Content.VariableName.ToVariableName()}, int index",
        UpdateMaskDataTypeBytes b =>
            $"{b.Content.First.CsType()} {b.Content.First.Name.ToVariableName()}, {b.Content.Second.CsType()} {b.Content.Second.Name.ToVariableName()}, {b.Content.Third.CsType()} {b.Content.Third.Name.ToVariableName()}, {b.Content.Fourth.CsType()} {b.Content.Fourth.Name.ToVariableName()}",
        UpdateMaskDataTypeTwoShort s =>
            $"{s.Content.First.InnerType.CsType()} {s.Content.First.Name.ToVariableName()}, {s.Content.Second.InnerType.CsType()} {s.Content.Second.Name.ToVariableName()}",
        UpdateMaskDataTypeFloat => "float value",
        UpdateMaskDataTypeGuid => "ulong value",
        UpdateMaskDataTypeInt => "uint value",
        UpdateMaskDataTypeGuidArrayUsingEnum g =>
            $"{g.Content.Definer.Name} {g.Content.VariableName.ToVariableName()}, int index",
        _ => throw new ArgumentOutOfRangeException(nameof(d))
    };
}