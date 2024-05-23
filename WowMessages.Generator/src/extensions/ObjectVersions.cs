using WowMessages.Generator.Generated;

namespace WowMessages.Generator.Extensions;

public static class ObjectVersionsExtensions
{
    public static bool IsSpecificLoginVersion(this ObjectVersions versions, byte version)
    {
        switch (versions)
        {
            case ObjectVersionsLogin l:
                switch (l.VersionType)
                {
                    case LoginVersionsAll:
                        return version == 0;
                    case LoginVersionsSpecific specific:
                        return specific.Versions.Contains(version);
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                break;
            case ObjectVersionsWorld:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(versions));
        }

        return false;
    }


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