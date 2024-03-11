using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.Extensions;

public static class ObjectVersionsExtensions
{
    public static bool IsLoginVersion(this ObjectVersions versions) =>
        versions switch
        {
            ObjectVersionsLogin => true,
            ObjectVersionsWorld => false,
            _ => throw new ArgumentOutOfRangeException(nameof(versions))
        };

    public static bool IsVersionAll(this ObjectVersions versions) =>
        versions switch
        {
            ObjectVersionsLogin l => l.VersionType is LoginVersionsAll,
            ObjectVersionsWorld w => w.VersionType is WorldVersionsAll,
            _ => throw new ArgumentOutOfRangeException(nameof(versions))
        };
}