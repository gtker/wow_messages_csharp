using System.Diagnostics;
using Generator.Generated;

namespace Generator.Extensions;

public static class PreparedObjectExtensions
{
    public static IEnumerable<PreparedObject> AllPreparedObjects(this PreparedObject po)
    {
        if (po.Enumerators is not null)
        {
            foreach (var (_, members) in po.Enumerators)
            {
                foreach (var member in members)
                {
                    yield return member;
                    foreach (var obj in member.AllPreparedObjects())
                    {
                        yield return obj;
                    }
                }
            }
        }
    }

    public static string UniqueString(this PreparedObject po)
    {
        var s = $"{po.Name}";
        foreach (var (enumerator, members) in po.Enumerators!)
        {
            s += enumerator;
            foreach (var member in members)
            {
                s += member.Name;
            }
        }

        return s;
    }

    public static bool IsFakeElseIf(this PreparedObject po, IList<PreparedObject> members) =>
        po.IsElseifFlag && members.Count == 1 && members[0].DefinerType is DefinerType.Enum_;

    private static string FirstEnumerator(this PreparedObject po)
    {
        var first = po.Enumerators!.First().Key;
        foreach (var (enumerator, _) in po.Enumerators!)
        {
            if (string.CompareOrdinal(enumerator, first) > 1)
            {
                first = enumerator;
            }
        }

        return first.ToMemberName();
    }

    public static bool IsEnumFromFlag(this PreparedObject po, Definition d) =>
        d.DataType is DataTypeFlag && po.DefinerType is DefinerType.Enum_;

    public static string EnumName(this PreparedObject po, Container e)
    {
        var d = e.FindDefinitionByName(po.Name);
        if (po.IsEnumFromFlag(d))
        {
            var poSet = po.Enumerators!.Select((e, i) => e.Key).ToHashSet();

            foreach (var m in e.AllMembers())
            {
                switch (m)
                {
                    case StructMemberDefinition:
                        break;
                    case StructMemberIfStatement statement:
                        var statementSet = statement.StructMemberContent.AllEnumeratorsAsSet();

                        if (poSet.SetEquals(statementSet))
                        {
                            return $"{d.CsTypeName()}{statement.StructMemberContent.Values[0].ToEnumerator()}Multi";
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(m));
                }
            }

            throw new UnreachableException();
        }

        return $"{d.CsTypeName()}Type";
    }

    public static IList<PreparedObject> GetMembersForEnumerator(this PreparedObject po, string enumerator)
    {
        if (!po.IsElseifFlag)
        {
            return po.Enumerators![enumerator];
        }

        foreach (var (_, members) in po.Enumerators!)
        {
            foreach (var member in members)
            {
                if (member.Enumerators is { } enumerators)
                {
                    if (enumerators.TryGetValue(enumerator, out var val))
                    {
                        return val;
                    }
                }
            }
        }

        if (po.Enumerators.TryGetValue(enumerator, out var value))
        {
            return value;
        }

        throw new UnreachableException();
    }

    public static bool IsInMultipleStatements(this PreparedObject po, Container e)
    {
        var seenBefore = false;
        foreach (var m in e.AllMembers())
        {
            switch (m)
            {
                case StructMemberDefinition:
                    break;
                case StructMemberIfStatement statement:
                    if (statement.StructMemberContent.VariableName == po.Name)
                    {
                        if (seenBefore)
                        {
                            return true;
                        }

                        seenBefore = true;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(m));
            }
        }

        return false;
    }
}