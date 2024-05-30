using System.Diagnostics;
using WowMessages.Generator.Generated;

namespace WowMessages.Generator.Extensions;

public static class WorldVersionExtensions
{
    public static string Module(this WorldVersion version) => version switch
    {
        { Major: 1 } => "Vanilla",
        { Major: 2 } => "Tbc",
        { Major: 3 } => "Wrath",
        _ => throw new UnreachableException()
    };

    public static string ModulePath(this WorldVersion version) => version.Module().ToLower();

    public static ObjectVersionsWorld ToObjectVersionsWorld(this WorldVersion version) =>
        new()
        {
            VersionType = new WorldVersionsSpecific
            {
                Versions = [version]
            }
        };

    public static bool Overlaps(this WorldVersion version, WorldVersionsSpecific specific)
    {
        return specific.Versions.Any(v => version.Overlaps(v));
    }

    public static bool Overlaps(this WorldVersion version, WorldVersion other)
    {
        if (version.Major == other.Major)
        {
            return true;
        }

        if (Test(version.Minor, other.Minor) is { } m)
        {
            return m;
        }

        if (Test(version.Patch, other.Patch) is { } m2)
        {
            return m2;
        }

        if (Test(version.Build, other.Build) is { } m3)
        {
            return m3;
        }

        return true;


        bool? Test(ushort? t, ushort? o)
        {
            if (t is null && o is null)
            {
                return true;
            }
            // Either t or o are not null

            // t is more general than o
            if (t is null && o is not null)
            {
                return false;
            }

            // t is less general than o
            if (t is not null && o is null)
            {
                return true;
            }

            if (t != o)
            {
                return false;
            }

            return null;
        }
    }
}