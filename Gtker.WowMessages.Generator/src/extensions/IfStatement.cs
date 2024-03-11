using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.Extensions;

public static class IfStatementExtensions
{
    public static IEnumerable<Definition> AllMembers(this IfStatement statement)
    {
        foreach (var member in statement.Members)
        {
            foreach (var m in member.AllMembers())
            {
                yield return m;
            }
        }

        foreach (var member in statement.ElseIfStatements)
        {
            foreach (var m in member.AllMembers())
            {
                yield return m;
            }
        }

        foreach (var member in statement.ElseMembers)
        {
            foreach (var m in member.AllMembers())
            {
                yield return m;
            }
        }
    }
}