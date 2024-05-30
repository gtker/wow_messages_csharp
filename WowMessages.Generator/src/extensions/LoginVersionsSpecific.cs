using WowMessages.Generator.Generated;

namespace WowMessages.Generator.Extensions;

public static class LoginVersionsSpecificExtensions
{
    public static bool Overlaps(this LoginVersionsSpecific thisVersion, LoginVersionsSpecific otherVersions) =>
        (from version in thisVersion.Versions
            from other in otherVersions.Versions
            where version == other
            select version).Any();
}