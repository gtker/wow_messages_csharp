using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.Extensions;

public static class EnumeratorExtension
{
    public static string CsName(this Enumerator e)
        =>
            Utils.CamelCaseToPascalCase(e.Name);
}