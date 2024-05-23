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

    public static List<string> CsConditionals(this IfStatement statement)
    {
        var conditions = new List<string>();
        var originalType = statement.OriginalType.CsType();

        switch (statement.Equations)
        {
            case IfStatementEquationsBitwiseAnd c:
                conditions.AddRange(c.Value.Select(cond => $".HasFlag({originalType}.{cond.ToEnumerator()})"));
                break;
            case IfStatementEquationsEquals c:
                conditions.AddRange(c.Value.Select(cond =>
                    $" == {originalType}.{cond.ToEnumerator()}"));
                break;
            case IfStatementEquationsNotEquals c:
                conditions.Add($" != {originalType}.{c.Value.ToEnumerator()}");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return conditions;
    }
}