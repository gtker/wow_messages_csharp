using Generator.Generated;

namespace Generator.Extensions;

public static class LoginVersionsExtensions
{
    public static bool Overlaps(this LoginVersions thisVersion, LoginVersions otherVersion)
        => (thisVersion, otherVersion) switch
        {
            (LoginVersionsAll, _) => true,
            (_, LoginVersionsAll) => true,
            (LoginVersionsSpecific version, LoginVersionsSpecific other) => version.Overlaps(other)
        };
}