namespace WowMessages.Generator.Extensions;

public static class StringExtensions
{
    public static string ToCamelCase(this string s) =>
        Utils.SnakeCaseToCamelCase(s);

    public static string ToPascalCase(this string s) =>
        Utils.SnakeCaseToPascalCase(s);

    public static string ToEnumerator(this string s) =>
        Utils.SnakeCaseToPascalCase(s);
}