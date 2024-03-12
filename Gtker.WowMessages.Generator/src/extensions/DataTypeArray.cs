using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.Extensions;

public static class DataTypeArrayExtensions
{
    public static string CsType(this DataTypeArray array) =>
        $"List<{array.Content.InnerType.CsType()}>";
}