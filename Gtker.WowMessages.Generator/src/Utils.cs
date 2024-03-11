using System.Text;

namespace Gtker.WowMessages.Generator;

public static class Utils
{
    public static string SnakeCaseToPascalCase(string s)
    {
        var newString = new StringBuilder();
        var nextIsUpper = true;

        foreach (var ch in s)
            if (nextIsUpper)
            {
                newString.Append(char.ToUpper(ch));
                nextIsUpper = false;
            }
            else if (ch == '_')
            {
                nextIsUpper = true;
            }
            else
            {
                newString.Append(char.ToLower(ch));
            }

        return newString.ToString();
    }

    public static string SnakeCaseToCamelCase(string s)
    {
        var newString = new StringBuilder();
        var nextIsUpper = false;

        foreach (var ch in s)
            if (nextIsUpper)
            {
                newString.Append(char.ToUpper(ch));
                nextIsUpper = false;
            }
            else if (ch == '_')
            {
                nextIsUpper = true;
            }
            else
            {
                newString.Append(char.ToLower(ch));
            }

        return newString.ToString();
    }
}