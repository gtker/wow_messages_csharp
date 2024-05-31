using WowMessages.Generator.Extensions;
using WowMessages.Generator.Generated;

namespace WowMessages.Generator;

public static class Tests
{
    public static void RunTests()
    {
        Versions();
    }

    private static void Versions()
    {
        var shouldNotPass = new ObjectVersionsWorld
        {
            VersionType = new WorldVersionsSpecific
            {
                Versions =
                [
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 1
                    },
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 2
                    },
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 3
                    },
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 4
                    },
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 5
                    },
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 6
                    },
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 7
                    },
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 8
                    }
                ]
            }
        };

        if (shouldNotPass.ShouldWriteObject(Program.Vanilla.ToObjectVersionsWorld()))
        {
            throw new Exception("Accepts messages that it shouldn't");
        }

        var shouldPass = new ObjectVersionsWorld
        {
            VersionType = new WorldVersionsSpecific
            {
                Versions =
                [
                    new WorldVersion
                    {
                        Major = 1,
                        Minor = 12
                    }
                ]
            }
        };

        if (shouldPass.ShouldNotWriteObject(Program.Vanilla.ToObjectVersionsWorld()))
        {
            throw new Exception("Rejects messages that it shouldn't");
        }

        var shouldNotPass2 = new ObjectVersionsWorld
        {
            VersionType = new WorldVersionsSpecific
            {
                Versions =
                [
                    new WorldVersion
                    {
                        Major = 2,
                        Minor = 4,
                        Patch = 3
                    },
                    new WorldVersion
                    {
                        Major = 3
                    }
                ]
            }
        };

        if (shouldNotPass2.ShouldWriteObject(Program.Vanilla.ToObjectVersionsWorld()))
        {
            throw new Exception("Accepts messages that it shouldn't 2");
        }
    }
}