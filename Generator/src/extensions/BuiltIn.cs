using Generator.Generated;

namespace Generator.Extensions;

public static class BuiltIn
{
    public static ObjectVersionsLogin ToLoginVersion(this byte v) => v == Program.LoginVersionAll
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