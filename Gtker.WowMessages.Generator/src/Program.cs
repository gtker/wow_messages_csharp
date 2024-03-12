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
            if (!e.Tags.Version_.IsSpecificLoginVersion(version))
            {
                continue;
            }

            var s = WriteEnumAndFlag.WriteEnum(e, module, project, false);
            File.WriteAllText(ProjectDir + $"Gtker.WowMessages.{project}/src/{modulePath}/" + e.FileName(),
                s.ToString());
        }

        foreach (var e in schema.Login.Flags.Value)
        {
            if (!e.Tags.Version_.IsSpecificLoginVersion(version))
            {
                continue;
            }

            var s = WriteEnumAndFlag.WriteEnum(e, module, project, true);
            File.WriteAllText(ProjectDir + $"Gtker.WowMessages.{project}/src/{modulePath}/" + e.FileName(),
                s.ToString());
        }


        var tests = new Writer();
        WriteTests.TestHeader(tests, module);
        foreach (var e in schema.Login.Structs.Value.Concat(schema.Login.Messages.Value))
        {
            if (!e.Tags.Version_.IsSpecificLoginVersion(version) || e.ShouldSkip())
            {
                continue;
            }

            var s = WriteContainers.WriteContainer(e, module, project);
            File.WriteAllText(ProjectDir + $"Gtker.WowMessages.{project}/src/{modulePath}/" + e.FileName(),
                s.ToString());

            if (e.ObjectType is not ObjectTypeStruct)
            {
                WriteTests.WriteTest(tests, e);
            }
        }

        WriteTests.TestFooter(tests);
        File.WriteAllText(ProjectDir + $"Gtker.WowMessages.{project}Test/{module}.cs", tests.ToString());

        var messages =
            schema.Login.Messages.Value.Where(e => e.Tags.Version_.IsSpecificLoginVersion(version) && !e.ShouldSkip());

        WriteOpcodes(messages, module, modulePath, project, "ILoginMessage");
    }

    public static void WriteOpcodes(IEnumerable<Container> containers, string module, string modulePath,
        string project, string interfaceName)
    {
        var server = new Writer();
        server.Wln($"namespace Gtker.WowMessages.{project}.{module};");
        server.Newline();
        server.OpenCurly("public class ServerOpcodeReader");
        server.OpenCurly($"public static async Task<{interfaceName}> ReadAsync(Stream r)");

        var client = new Writer();
        client.Wln($"namespace Gtker.WowMessages.{project}.{module};");
        client.Newline();
        client.OpenCurly("public class ClientOpcodeReader");
        client.OpenCurly($"public static async Task<{interfaceName}> ReadAsync(Stream r)");

        if (project == "Login")
        {
            server.Wln("var opcode = await ReadUtils.ReadByte(r);");
            client.Wln("var opcode = await ReadUtils.ReadByte(r);");

            server.OpenCurly("return opcode switch");
            client.OpenCurly("return opcode switch");
        }
        else
        {
            throw new NotImplementedException();
        }

        var serverHasMembers = false;
        var clientHasMembers = false;

        foreach (var e in containers)
        {
            switch (e.ObjectType)
            {
                case ObjectTypeClogin o:
                    clientHasMembers = true;
                    client.Wln($"{o.Opcode} => await {e.Name}.ReadAsync(r),");
                    break;
                case ObjectTypeSlogin o:
                    serverHasMembers = true;
                    server.Wln($"{o.Opcode} => await {e.Name}.ReadAsync(r),");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        if (project == "Login")
        {
            server.ClosingCurly(";"); // return opcode switch
            client.ClosingCurly(";"); // return opcode switch
        }
        else
        {
            throw new NotImplementedException();
        }

        server.ClosingCurly(); // public static async Task<>
        client.ClosingCurly(); // public static async Task<>

        server.ClosingCurly(); // public class ServerOpcodeReader
        client.ClosingCurly(); // public class ClientOpcodeReader

        if (serverHasMembers)
        {
            File.WriteAllText(ProjectDir + $"Gtker.WowMessages.{project}/src/{modulePath}/ServerOpcodeReader.cs",
                server.ToString());
        }

        if (clientHasMembers)
        {
            File.WriteAllText(ProjectDir + $"Gtker.WowMessages.{project}/src/{modulePath}/ClientOpcodeReader.cs",
                client.ToString());
        }
    }
}