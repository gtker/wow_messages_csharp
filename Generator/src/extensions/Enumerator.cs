using Generator.Generated;

namespace Generator.Extensions;

public static class EnumeratorExtension
{
    public static string CsName(this Enumerator e)
        =>
            Utils.SnakeCaseToPascalCase(e.Name);
}