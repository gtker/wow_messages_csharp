using System.Runtime.CompilerServices;
using System.Text.Json;
using WowMessages.Generator.Extensions;
using WowMessages.Generator.Generated;
using WowMessages.Generator.write_container;

namespace WowMessages.Generator;

internal static class Program
{
    private static string? _lazyValue;
    
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
        var path = ProjectDir + "WowMessages.Generator/wow_messages/intermediate_representation.json";
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
            File.WriteAllText(ProjectDir + $"Wow{project}Messages/src/{modulePath}/" + e.FileName(),
                s.ToString());
        }
        
        foreach (var e in schema.Login.Flags.Value)
        {
            if (!e.Tags.Version_.IsSpecificLoginVersion(version))
            {
                continue;
            }
            
            var s = WriteEnumAndFlag.WriteEnum(e, module, project, true);
            File.WriteAllText(ProjectDir + $"Wow{project}Messages/src/{modulePath}/" + e.FileName(),
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
            File.WriteAllText(ProjectDir + $"Wow{project}Messages/src/{modulePath}/" + e.FileName(),
                s.ToString());
            
            if (e.ObjectType is not ObjectTypeStruct)
            {
                WriteTests.WriteTest(tests, e);
            }
        }
        
        WriteTests.TestFooter(tests);
        File.WriteAllText(ProjectDir + $"Wow{project}Messages.Test/{module}.cs", tests.ToString());
        
        var serverMessages =
            schema.Login.Messages.Value.Where(e =>
                e.Tags.Version_.IsSpecificLoginVersion(version) && !e.ShouldSkip() && e.ObjectType is ObjectTypeSlogin);
        var serverS =
            WriteOpcodesImpl.WriteOpcodes(serverMessages, module, project, "Server");
        if (serverS is not null)
        {
            File.WriteAllText(ProjectDir + $"Wow{project}Messages/src/{modulePath}/ServerOpcodeReader.cs",
                serverS.ToString());
        }
        
        var clientMessages =
            schema.Login.Messages.Value.Where(e =>
                e.Tags.Version_.IsSpecificLoginVersion(version) && !e.ShouldSkip() && e.ObjectType is ObjectTypeClogin);
        var clientS =
            WriteOpcodesImpl.WriteOpcodes(clientMessages, module, project, "Client");
        if (clientS is not null)
        {
            File.WriteAllText(ProjectDir + $"Wow{project}Messages/src/{modulePath}/ClientOpcodeReader.cs",
                clientS.ToString());
        }
    }
}