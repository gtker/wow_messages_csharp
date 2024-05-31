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

        foreach (var member in statement.ElseMembers)
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

        var variableBinding = isWrite ? $" {statement.VariableName.ToVariableName()}" : "";
        var modulePrefix = isWrite ? containerName : module;
        var dot = isWrite ? "" : ".";

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
                conditions.AddRange(statement.Values.Select(cond =>
                    ($" is {modulePrefix}.{originalType}{dot}{cond.ToEnumerator()}{variableBinding}", cond)));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return conditions;
    }

    public static bool IsFlag(this IfStatement statement) => statement.OriginalType is DataTypeFlag;
}