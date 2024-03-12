using Gtker.WowMessages.Generator.Extensions;
using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.write_container;

public static class WriteContainers
{
    public static Writer WriteContainer(Container e, string module, string project)
    {
        var s = new Writer();
        WriteIncludes(s, e);

        s.Wln($"namespace Gtker.WowMessages.{project}.{module};");
        s.Newline();

        s.Wln("[System.CodeDom.Compiler.GeneratedCode(\"WoWM\", \"0.1.0\")]");
        if (e.Name.Contains('_'))
        {
            s.Wln("// ReSharper disable once InconsistentNaming");
        }

        var implements = e.ObjectType switch
        {
            ObjectTypeClogin or ObjectTypeSlogin => ": ILoginMessage",
            ObjectTypeStruct => "",
            _ => throw new ArgumentOutOfRangeException()
        };

        s.Body($"public class {e.Name}{implements}", s =>
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
            else if (e is { ObjectType: ObjectTypeStruct, Sizes.ConstantSized: false })
            {
                WriteSizeImplementation.WriteSize(s, e, 0);
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
                case StructMemberIfStatement statement:
                    foreach (var d in statement.AllDefinitions())
                    {
                        s.Wln($"public {d.CsTypeName()} {d.MemberName()} {{ get; set; }}");
                    }

                    break;
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

        foreach (var member in e.AllDefinitions())
        {
            switch (member.DataType)
            {
                case DataTypePopulation:
                    s.Wln("using Gtker.WowMessages.Login.All;");
                    shouldNewline = true;
                    break;
                case DataTypeStruct c:
                    if (c.Content.StructData.Name == "Version")
                    {
                        s.Wln("using Version = Gtker.WowMessages.Login.All.Version;");
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
            ifHeader += $"{transform(statement.Conditional.VariableName)}{cond}";
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
    }
}