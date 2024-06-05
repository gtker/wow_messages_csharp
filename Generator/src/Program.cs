using System.Runtime.CompilerServices;
using System.Text.Json;
using Generator.Extensions;
using Generator.Generated;
using Generator.write_container;

namespace Generator;

internal static class Program
{
    private static string? _lazyValue;

    public static readonly WorldVersion Vanilla = new() { Major = 1, Minor = 12, Patch = 1, Build = 5875 };

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

        SanitizeModel(schema);

        if (!CompareSchemaVersions(schema.Version_))
        {
            Console.WriteLine(
                $"Unsupported schema version: {schema.Version_.Major}.{schema.Version_.Minor}.{schema.Version_.Patch}");
            Environment.Exit(1);
        }

        WriteLoginFiles(schema, 0);

        foreach (var version in schema.DistinctLoginVersionsOtherThanAll)
        {
            WriteLoginFiles(schema, version);
        }

        Console.WriteLine("Wrote all login files");

        WriteWorldFiles(schema, Vanilla);
        Console.WriteLine("Wrote all world files");
    }

    private static void SanitizeModel(IntermediateRepresentationSchema schema)
    {
        foreach (var e in schema.Login.Messages)
        {
            SanitizeContainer(e);
        }

        foreach (var e in schema.Login.Structs)
        {
            SanitizeContainer(e);
        }

        foreach (var e in schema.World.Messages)
        {
            SanitizeContainer(e);
        }

        foreach (var e in schema.World.Structs)
        {
            SanitizeContainer(e);
        }

        return;

        void SanitizeContainer(Container e)
        {
            var replacementNames = new Dictionary<string, string>
            {
                { "class", "class_type" },
                { "string", "string_value" },
                { "event", "event_type" }
            };

            foreach (var d in e.AllDefinitions())
            {
                if (replacementNames.TryGetValue(d.Name, out var name))
                {
                    d.Name = name;
                }
            }

            foreach (var po in e.AllPreparedObjects())
            {
                if (replacementNames.TryGetValue(po.Name, out var name))
                {
                    po.Name = name;
                }
            }
        }
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
                WriteTests.WriteTest(tests, e);
            }
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

    private static void WriteLoginFiles(IntermediateRepresentationSchema schema, byte version)
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

        WriteDefiners(schema.Login.Enums, module, modulePath, project, version.ToLoginVersion(), false);
        WriteDefiners(schema.Login.Flags, module, modulePath, project, version.ToLoginVersion(), true);


        WriteContainersAndTests(schema.Login.Structs.Concat(schema.Login.Messages), module, modulePath,
            project, version.ToLoginVersion());

        WriteOpcodes(schema.Login.Messages, module, modulePath, project, version.ToLoginVersion());
    }

    private static void WriteWorldFiles(IntermediateRepresentationSchema schema, WorldVersion v)
    {
        const string project = "World";
        var module = v.Module();
        var modulePath = v.ModulePath();
        var version = v.ToObjectVersionsWorld();

        WriteDefiners(schema.World.Enums, module, modulePath, project, version, false);
        WriteDefiners(schema.World.Flags, module, modulePath, project, version, true);

        WriteContainersAndTests(schema.World.Structs.Concat(schema.World.Messages), module, modulePath,
            project, version);

        WriteOpcodes(schema.World.Messages, module, modulePath, project, version);
    }
}