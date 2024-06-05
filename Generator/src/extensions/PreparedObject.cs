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
}