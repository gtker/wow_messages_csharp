using Generator.Generated;

namespace Generator.Extensions;

public static class IfStatementExtensions
{
    public static IEnumerable<StructMember> AllMembers(this IfStatement statement)
    {
        foreach (var m in statement.Members)
        {
            yield return m;

            switch (m)
            {
                case StructMemberDefinition:
                    break;
                case StructMemberIfStatement innerStatement:
                    foreach (var member in innerStatement.StructMemberContent.AllMembers())
                    {
                        yield return member;
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(m));
            }
        }

        foreach (var elseif in statement.ElseIfStatements)
        {
            foreach (var member in elseif.AllMembers())
            {
                yield return member;
            }
        }
    }

    public static string SeparateIfStatementNamePrefix(this IfStatement statement) =>
        $"{statement.VariableName.ToVariableName()}If";


    public static HashSet<string> AllEnumeratorsAsSet(this IfStatement statement)
    {
        var set = new HashSet<string>();

        foreach (var value in statement.Values)
        {
            set.Add(value);
        }

        foreach (var elseif in statement.ElseIfStatements)
        {
            set.UnionWith(elseif.AllEnumeratorsAsSet());
        }

        return set;
    }

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

    public static bool IsFlag(this IfStatement statement) => statement.OriginalType is DataTypeFlag;
}