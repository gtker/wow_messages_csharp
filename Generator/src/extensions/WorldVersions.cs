using System.Diagnostics;
using Generator.Generated;

namespace Generator.Extensions;

public static class WorldVersionsExtensions
{
    public static bool Overlaps(this WorldVersions thisVersion, WorldVersions other)
    {
        return (thisVersion, other) switch
        {
            (WorldVersionsAll, _) => true,
            (_, WorldVersionsAll) => true,
            (WorldVersionsSpecific t, WorldVersionsSpecific o) => t.Overlaps(o),
            _ => throw new UnreachableException()
        };
    }
}