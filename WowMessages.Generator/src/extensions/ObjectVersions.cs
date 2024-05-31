using System.Diagnostics;
using WowMessages.Generator.Generated;

namespace WowMessages.Generator.Extensions;

public static class ObjectVersionsExtensions
{
    public static bool Overlaps(this ObjectVersions versions, ObjectVersions other)
    {
        return (versions, other) switch
        {
            (ObjectVersionsLogin, ObjectVersionsWorld) => false,
            (ObjectVersionsWorld, ObjectVersionsLogin) => false,
            (ObjectVersionsWorld v, ObjectVersionsWorld o) => v.VersionType.Overlaps(o.VersionType),
            (ObjectVersionsLogin v, ObjectVersionsLogin o) => v.VersionType.Overlaps(o.VersionType),
            _ => throw new UnreachableException()
        };
    }

    public static bool ShouldNotWriteObject(this ObjectVersions versions, ObjectVersions other)
    {
        var versionsDontMatch = !versions.Overlaps(other);
        var versionIsAllButObjectIsNot = other.IsVersionAll() && !versions.IsVersionAll();
        var objectIsAllButVersionIsNot = !other.IsVersionAll() && versions.IsVersionAll();
        return versionsDontMatch || versionIsAllButObjectIsNot || objectIsAllButVersionIsNot;
    }

    public static bool ShouldWriteObject(this ObjectVersions versions, ObjectVersions other) =>
        !ShouldNotWriteObject(versions, other);

    public static bool IsVersionAll(this ObjectVersions versions) =>
        versions switch
        {
            ObjectVersionsLogin l => l.VersionType is LoginVersionsAll,
            ObjectVersionsWorld w => w.VersionType is WorldVersionsAll,
            _ => throw new ArgumentOutOfRangeException(nameof(versions))
        };

    public static bool IsWorld(this ObjectVersions versions) => versions switch
    {
        ObjectVersionsWorld => true,
        _ => false
    };
}