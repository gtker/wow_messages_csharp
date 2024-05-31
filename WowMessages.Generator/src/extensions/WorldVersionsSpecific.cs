using WowMessages.Generator.Generated;

namespace WowMessages.Generator.Extensions;

public static class WorldVersionsSpecificExtensions
{
    public static bool Overlaps(this WorldVersionsSpecific theseVersions, WorldVersionsSpecific otherVersions) =>
        (from version in theseVersions.Versions
            from other in otherVersions.Versions
            where other.Overlaps(version)
            select version).Any();
}