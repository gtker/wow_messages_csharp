using System.Runtime.CompilerServices;
using System.Text.Json;
using Generator.Extensions;
using Generator.Generated;
using Generator.write_container;

namespace Generator;

internal static class Program
{
    private static string? _lazyValue;

    public static readonly ObjectVersionsWorld All = new()
    {
        VersionType = new WorldVersionsAll()
    };

    public static readonly WorldVersion Vanilla = new() { Major = 1, Minor = 12, Patch = 1, Build = 5875 };
    public static readonly WorldVersion Tbc = new() { Major = 2, Minor = 4, Patch = 3, Build = 8606 };
    public static readonly WorldVersion Wrath = new() { Major = 3, Minor = 3, Patch = 5, Build = 12340 };

    private static string ProjectDir
    {
        get => _lazyValue ??= CalculatePath();
    }

    private static string CalculatePath()
    {
        var pathName = GetSourceFilePathName();
        const string fileName = nameof(Program) + ".cs";
        return pathName[..^fileName.Length] + "../../";
    }


    private static string GetSourceFilePathName([CallerFilePath] string? callerFilePath = null) => callerFilePath ?? "";


    private static bool CompareSchemaVersions(SchemaVersion version) => version is { Major: 0, Minor: <= 1 };

    private static void Main()
    {
        Console.WriteLine("Running tests");
        Tests.RunTests();
        Console.WriteLine("Tests finished");


        var path = ProjectDir + "Generator/wow_messages/intermediate_representation.json";
        Console.WriteLine(path);
        var contents = File.ReadAllText(path);

        var schema = JsonSerializer.Deserialize<IntermediateRepresentationSchema>(contents);
        if (schema == null)
        {
            Console.WriteLine("JsonSerializer.Deserialize returned null.");
            Environment.Exit(1);
        }

        Sanitizer.SanitizeModel(schema);

        if (!CompareSchemaVersions(schema.Version_))
        {
            Console.WriteLine(
                $"Unsupported schema version: {schema.Version_.Major}.{schema.Version_.Minor}.{schema.Version_.Patch}");
            Environment.Exit(1);
        }

        WriteLoginFiles(schema.Login, 0);

        foreach (var version in schema.DistinctLoginVersionsOtherThanAll)
        {
            WriteLoginFiles(schema.Login, version);
        }

        Console.WriteLine("Wrote all login files");

        WriteFiles(schema.World, null, All, "All", "all", "World");
        WriteFiles(schema.World, schema.VanillaUpdateMask, Vanilla.ToObjectVersionsWorld(), Vanilla.Module(),
            Vanilla.ModulePath(), "World");
        WriteFiles(schema.World, schema.TbcUpdateMask, Tbc.ToObjectVersionsWorld(), Tbc.Module(),
            Tbc.ModulePath(), "World");
        WriteFiles(schema.World, schema.WrathUpdateMask, Wrath.ToObjectVersionsWorld(), Wrath.Module(),
            Wrath.ModulePath(), "World");
        Console.WriteLine("Wrote all world files");
    }

    private static void WriteDefiners(IList<Definer> enums, string module, string modulePath, string project,
        ObjectVersions version, bool isFlag)
    {
        foreach (var e in enums)
        {
            if (e.Tags.Version_.ShouldNotWriteObject(version))
            {
                continue;
            }

            var s = WriteEnumAndFlag.WriteEnum(e, module, project, isFlag);
            File.WriteAllText(ProjectDir + $"Wow{project}Messages/src/{modulePath}/" + e.FileName(), s.ToString());
        }
    }

    private static void WriteContainersAndTests(IEnumerable<Container> containers, string module, string modulePath,
        string project, ObjectVersions version)
    {
        var tests = new Writer();
        WriteTests.TestHeader(tests, project, module);
        var shouldWriteTests = false;
        foreach (var e in containers)
        {
            if (e.Tags.Version_.ShouldNotWriteObject(version) || e.ShouldSkip())
            {
                continue;
            }

            var s = WriteContainers.WriteContainer(e, module, project);
            File.WriteAllText(ProjectDir + $"Wow{project}Messages/src/{modulePath}/" + e.FileName(),
                s.ToString());

            if (e.ObjectType is not ObjectTypeStruct)
            {
                shouldWriteTests = true;
                WriteTests.WriteTest(tests, e);
            }
        }

        if (!shouldWriteTests)
        {
            return;
        }

        WriteTests.TestFooter(tests);
        File.WriteAllText(ProjectDir + $"Wow{project}Messages.Test/{module}.cs", tests.ToString());
    }

    private static void WriteOpcodes(IList<Container> messages, string module, string modulePath, string project,
        ObjectVersions version)
    {
        var serverMessages =
            messages.Where(e =>
                    e.Tags.Version_.ShouldWriteObject(version) && !e.ShouldSkip() &&
                    e.ObjectType is ObjectTypeSlogin or ObjectTypeSmsg)
                .ToList();
        var serverS =
            WriteOpcodesImpl.WriteOpcodes(serverMessages, module, project, "Server");
        if (serverS is not null)
        {
            File.WriteAllText(ProjectDir + $"Wow{project}Messages/src/{modulePath}/ServerOpcodeReader.cs",
                serverS.ToString());
        }

        var clientMessages =
            messages.Where(e =>
                    e.Tags.Version_.ShouldWriteObject(version) && !e.ShouldSkip() &&
                    e.ObjectType is ObjectTypeClogin or ObjectTypeCmsg)
                .ToList();
        var clientS =
            WriteOpcodesImpl.WriteOpcodes(clientMessages, module, project, "Client");
        if (clientS is not null)
        {
            File.WriteAllText(ProjectDir + $"Wow{project}Messages/src/{modulePath}/ClientOpcodeReader.cs",
                clientS.ToString());
        }
    }

    private static void WriteLoginFiles(Objects objects, byte version)
    {
        var module = version switch
        {
            0 => "All",
            _ => $"Version{version}"
        };
        var modulePath = version switch
        {
            0 => "all",
            _ => $"version{version}"
        };

        const string project = "Login";

        WriteFiles(objects, null, version.ToLoginVersion(), module, modulePath, project);
    }

    private static void WriteFiles(Objects objects, IList<UpdateMask>? updateMask, ObjectVersions version,
        string module, string modulePath,
        string project)
    {
        var path = $"{ProjectDir}Wow{project}Messages/src/{modulePath}";
        Directory.Delete(path, true);
        Directory.CreateDirectory(path);

        WriteDefiners(objects.Enums, module, modulePath, project, version, false);
        WriteDefiners(objects.Flags, module, modulePath, project, version, true);

        WriteContainersAndTests(objects.Structs.Concat(objects.Messages), module, modulePath,
            project, version);

        WriteOpcodes(objects.Messages, module, modulePath, project, version);

        if (updateMask != null)
        {
            WriteUpdateMasks.WriteUpdateMask(updateMask, module, $"{path}/UpdateMask.cs");
        }
    }
}