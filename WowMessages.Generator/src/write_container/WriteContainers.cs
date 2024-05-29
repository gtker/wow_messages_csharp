using WowMessages.Generator.Extensions;
using WowMessages.Generator.Generated;

namespace WowMessages.Generator.write_container;

public static class WriteContainers
{
    public static Writer WriteContainer(Container e, string module, string project)
    {
        var s = new Writer();
        WriteIncludes(s, e);

        s.Wln($"namespace Wow{project}Messages.{module};");
        s.Newline();

        s.Wln("[System.CodeDom.Compiler.GeneratedCode(\"WoWM\", \"0.1.0\")]");
        if (e.Name.Contains('_'))
        {
            s.Wln("// ReSharper disable once InconsistentNaming");
        }

        var implements = e.ObjectType switch
        {
            ObjectTypeClogin => $": {module}ClientMessage, ILoginMessage",
            ObjectTypeSlogin => $": {module}ServerMessage, ILoginMessage",
            ObjectTypeStruct => "",
            _ => throw new ArgumentOutOfRangeException()
        };

        s.Body($"public class {e.Name}{implements}", s =>
        {
            WriteDefinition(s, e);
            s.Newline();

            WriteWriteImplementation.WriteWrite(s, e);
            s.Newline();

            WriteReadImplementation.WriteRead(s, e);
            s.Newline();

            if (e.ManualSizeSubtraction is { } manualSizeSubtraction)
            {
                WriteSizeImplementation.WriteSize(s, e, manualSizeSubtraction);
                s.Newline();
            }
            else if (e is { ObjectType: ObjectTypeStruct, Sizes.ConstantSized: false })
            {
                WriteSizeImplementation.WriteSize(s, e, 0);
                s.Newline();
            }
        });
        s.Newline();

        return s;
    }

    private static void WriteMemberDefinition(Writer s, Container e, Definition d)
    {
        if (d.IsNotInType())
        {
            return;
        }

        WriteDefinitionComment(s, d.Tags.Comment);

        s.Wln($"public required {d.CsTypeName()} {d.MemberName()} {{ get; set; }}");
    }

    private static void WriteDefinition(Writer s, Container e)
    {
        foreach (var member in e.Members)
        {
            switch (member)
            {
                case StructMemberDefinition definition:
                {
                    WriteMemberDefinition(s, e, definition.StructMemberContent);
                    break;
                }
                case StructMemberIfStatement statement:
                    foreach (var d in statement.AllDefinitions())
                    {
                        if (d.IsNotInType())
                        {
                            continue;
                        }

                        WriteDefinitionComment(s, d.Tags.Comment);

                        s.Wln($"public {d.CsTypeName()} {d.MemberName()} {{ get; set; }}");
                    }

                    break;
                case StructMemberOptional optional:
                    foreach (var d in optional.AllDefinitions())
                    {
                        if (d.IsNotInType())
                        {
                            continue;
                        }

                        s.Wln($"public {d.CsTypeName()} {d.MemberName()} {{ get; set; }}");
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(member));
            }
        }
    }

    private static void WriteDefinitionComment(Writer s, string? comment)
    {
        if (comment is "" or null)
        {
            return;
        }

        s.Wln("/// <summary>");
        using (var sr = new StringReader(comment))
        {
            while (sr.ReadLine() is { } line)
            {
                s.Wln($"/// {line}");
            }
        }

        s.Wln("/// </summary>");
    }

    private static void WriteIncludes(Writer s, Container e)
    {
        var shouldNewline = false;

        if (e.Members.Count == 0)
        {
            s.Wln(
                "// This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.");
            s.Wln("// Empty reads will have an unnecessary async keyword");
            s.Wln("#pragma warning disable 1998");
        }

        foreach (var member in e.AllDefinitions())
        {
            switch (member.DataType)
            {
                case DataTypePopulation:
                    s.Wln("using WowLoginMessages.All;");
                    shouldNewline = true;
                    break;
                case DataTypeStruct c:
                    if (c.StructData.Name == "Version")
                    {
                        s.Wln("using Version = WowLoginMessages.All.Version;");
                    }

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

    public static void WriteIfStatement(Writer s, Container e, IfStatement statement,
        Action<Writer, Container, StructMember> invocation, bool upperCaseFirstChar)
    {
        Func<string, string> transform = upperCaseFirstChar ? Utils.SnakeCaseToPascalCase : Utils.SnakeCaseToCamelCase;

        var ifHeader = "if (";
        foreach (var cond in statement.CsConditionals())
        {
            ifHeader += $"{transform(statement.VariableName)}{cond}";
        }

        ifHeader += ")";

        s.Body(ifHeader, s =>
        {
            foreach (var member in statement.Members)
            {
                invocation(s, e, member);
            }
        });


        if (statement.ElseMembers.Count != 0)
        {
            s.Body("else", s =>
            {
                foreach (var member in statement.ElseMembers)
                {
                    invocation(s, e, member);
                }
            });
        }

        s.Newline();
    }
}