using Gtker.WowMessages.Generator.Extensions;
using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.write_container;

public static class WriteContainers
{
    public static Writer? WriteContainer(Container e, string module, string project)
    {
        if (e.ShouldSkip())
        {
            return null;
        }

        var s = new Writer();
        WriteIncludes(s, e);

        s.Wln($"namespace Gtker.WowMessages.{project}.{module};");
        s.Newline();

        s.Wln("[System.CodeDom.Compiler.GeneratedCode(\"WoWM\", \"0.1.0\")]");
        if (e.Name.Contains('_'))
        {
            s.Wln("// ReSharper disable once InconsistentNaming");
        }

        s.Body($"public class {e.Name}", s =>
        {
            WriteDefinition(s, e);
            s.Newline();

            WriteReadImplementation.WriteRead(s, e);
            s.Newline();

            WriteWriteImplementation.WriteWrite(s, e);
            s.Newline();

            if (e.ManualSizeSubtraction is { } manualSizeSubtraction)
            {
                WriteSizeImplementation.WriteSize(s, e, manualSizeSubtraction);
                s.Newline();
            }
        });
        s.Newline();

        return s;
    }

    private static void WriteDefinition(Writer s, Container e)
    {
        foreach (var member in e.Members)
        {
            switch (member)
            {
                case StructMemberDefinition definition:
                {
                    var d = definition.StructMemberContent;
                    if (d.IsNotInType())
                    {
                        continue;
                    }

                    s.Wln($"public required {d.CsTypeName()} {d.MemberName()} {{ get; set; }}");
                    break;
                }
                case StructMemberIfStatement:
                    throw new NotImplementedException();
                case StructMemberOptional:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(member));
            }
        }
    }

    private static void WriteIncludes(Writer s, Container e)
    {
        var shouldNewline = false;

        foreach (var member in e.AllMembers())
        {
            switch (member.DataType)
            {
                case DataTypePopulation:
                    s.Wln("using Gtker.WowMessages.Login.All;");
                    shouldNewline = true;
                    break;
                default:
                    continue;
            }
        }

        if (shouldNewline)
        {
            s.Newline();
        }
    }
}