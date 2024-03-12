using System.Runtime.CompilerServices;
using System.Text.Json;
using Gtker.WowMessages.Generator.Extensions;
using Gtker.WowMessages.Generator.Generated;
using Gtker.WowMessages.Generator.write_container;

namespace Gtker.WowMessages.Generator;

internal static class Program
{
    private static string? _lazyValue;

    private static string ProjectDir => _lazyValue ??= CalculatePath();

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
        var path = ProjectDir + "Gtker.WowMessages.Generator/wow_messages/intermediate_representation.json";
        Console.WriteLine(path);
        var contents = File.ReadAllText(path);

        var schema = JsonSerializer.Deserialize<IntermediateRepresentationSchema>(contents);
        if (schema == null)
        {
            Console.WriteLine("JsonSerializer.Deserialize returned null.");
            Environment.Exit(1);
        }

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

        foreach (var e in schema.Login.Enums.Value)
        {
            if (!LoginVersionMatches(e.Tags.Version_, version))
            {
                continue;
            }

            var s = WriteEnumAndFlag.WriteEnum(e, module, project, false);
            File.WriteAllText(ProjectDir + $"Gtker.WowMessages.{project}/src/{modulePath}/" + e.FileName(), s.Data());
        }

        foreach (var e in schema.Login.Flags.Value)
        {
            if (!LoginVersionMatches(e.Tags.Version_, version))
            {
                continue;
            }

            var s = WriteEnumAndFlag.WriteEnum(e, module, project, true);
            File.WriteAllText(ProjectDir + $"Gtker.WowMessages.{project}/src/{modulePath}/" + e.FileName(), s.Data());
        }

        foreach (var e in schema.Login.Structs.Value)
        {
            if (!LoginVersionMatches(e.Tags.Version_, version) || e.ShouldSkip())
            {
                continue;
            }

            var s = WriteContainers.WriteContainer(e, module, project);
            File.WriteAllText(ProjectDir + $"Gtker.WowMessages.{project}/src/{modulePath}/" + e.FileName(),
                s.Data());
        }

        var tests = new Writer();
        WriteTests.TestHeader(tests, module);
        foreach (var e in schema.Login.Messages.Value)
        {
            if (!LoginVersionMatches(e.Tags.Version_, version) || e.ShouldSkip())
            {
                continue;
            }

            var s = WriteContainers.WriteContainer(e, module, project);

            File.WriteAllText(ProjectDir + $"Gtker.WowMessages.{project}/src/{modulePath}/" + e.FileName(),
                s.Data());

            WriteTests.WriteTest(tests, e);
        }

        WriteTests.TestFooter(tests);
        File.WriteAllText(ProjectDir + $"Gtker.WowMessages.{project}Test/{module}.cs", tests.Data());
        return;

        bool LoginVersionMatches(ObjectVersions objectVersions, byte v) =>
            objectVersions.IsSpecificLoginVersion(v);
    }
}