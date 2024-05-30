using WowMessages.Generator.Generated;

namespace WowMessages.Generator.Extensions;

public static class BuiltIn
{
    public static ObjectVersionsLogin ToLoginVersion(this byte v) => v == 0
        ? new ObjectVersionsLogin
        {
            VersionType = new LoginVersionsAll()
        }
        : new ObjectVersionsLogin
        {
            VersionType = new LoginVersionsSpecific
            {
                Versions = [v]
            }
        };
}