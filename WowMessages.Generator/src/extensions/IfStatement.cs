using WowMessages.Generator.Generated;

namespace WowMessages.Generator.Extensions;

public static class IfStatementExtensions
{
    public static IEnumerable<Definition> AllDefinitions(this IfStatement statement)
    {
        foreach (var member in statement.Members)
        {
            foreach (var m in member.AllDefinitions())
            {
                yield return m;
            }
        }

        foreach (var member in statement.ElseIfStatements)
        {
            foreach (var m in member.AllDefinitions())
            {
                yield return m;
            }
        }
    }

    public static List<(string, string)> CsConditionals(this IfStatement statement, string module, string containerName,
        bool isWrite)
    {
        var conditions = new List<(string, string)>();
        var originalType = statement.OriginalType.CsType();

        var typeExists = statement.Members.Any(d => d.AllDefinitions().Any(d => d.IsInType()));
        var modulePrefix = isWrite && typeExists ? containerName : module;
        var dot = isWrite && typeExists ? "" : ".";

        switch (statement.DefinerType)
        {
            case IfStatementDefinerType.Flag:
                if (isWrite)
                {
                    conditions.AddRange(statement.Values.Select(cond =>
                        ($" is {{}} {cond.ToVariableName()}", cond)));
                }
                else
                {
                    conditions.AddRange(statement.Values.Select(cond =>
                        ($".HasFlag({modulePrefix}.{originalType}{dot}{cond.ToEnumerator()})", cond)));
                }

                break;
            case IfStatementDefinerType.Enum_:
                if (isWrite && typeExists)
                {
                    conditions.AddRange(statement.Values.Select(cond =>
                        ($" is {modulePrefix}.{originalType}{dot}{cond.ToEnumerator()} {cond.ToVariableName()}",
                            cond)));
                }
                else
                {
                    conditions.AddRange(statement.Values.Select(cond =>
                        ($" is {modulePrefix}.{originalType}{dot}{cond.ToEnumerator()}", cond)));
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return conditions;
    }

    public static bool IsFlag(this IfStatement statement) => statement.OriginalType is DataTypeFlag;
}