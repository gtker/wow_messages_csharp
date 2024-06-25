using Generator.Generated;

namespace Generator.Extensions;

public static class PreparedObjectExtensions
{
    public static IEnumerable<PreparedObject> AllPreparedObjects(this PreparedObject po)
    {
        if (po.Enumerators is not null)
        {
            foreach (var (enumerator, members) in po.Enumerators)
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
        foreach (var (enumerator, members) in po.Enumerators)
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
        var first = po.Enumerators.First().Key;
        foreach (var (enumerator, _) in po.Enumerators)
        {
            if (string.CompareOrdinal(enumerator, first) > 1)
            {
                first = enumerator;
            }
        }

        return first.ToMemberName();
    }

    public static string EnumName(this PreparedObject po, Definition d)
    {
        var isEnumInsideFlag = d.DataType is DataTypeFlag && po.DefinerType is DefinerType.Enum_;
        if (isEnumInsideFlag)
        {
            return $"{d.CsTypeName()}{po.FirstEnumerator()}Multi";
        }

        return $"{d.CsTypeName()}Type";
    }
}