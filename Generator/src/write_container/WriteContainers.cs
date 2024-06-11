using Generator.Extensions;
using Generator.Generated;
using Generator;

namespace Generator.write_container;

public static class WriteContainers
{
    public static Writer WriteContainer(Container e, string module, string project)
    {
        var s = new Writer();
        WriteIncludes(s, e);

        s.Wln($"namespace Wow{project}Messages.{module};");
        s.Newline();

        var newline = false;

        foreach (var po in e.AllPreparedObjects())
        {
            if (po.Enumerators is { } enumerators)
            {
                newline = true;

                var d = e.FindDefinitionByName(po.Name);
                if (d.DataType is DataTypeEnum)
                {
                    s.W($"using {d.CsTypeName()}Type = OneOf.OneOf<");

                    foreach (var (enumerator, members) in enumerators)
                    {
                        if (members.Any(m => e.FindDefinitionByName(m.Name).IsInType()))
                        {
                            s.WNoIndentation($"{e.Name}.{d.PreparedObjectTypeName(enumerator)}, ");
                        }
                    }

                    s.WlnNoIndentation($"{d.CsTypeName()}>;");
                }
            }
        }

        if (newline)
        {
            s.Newline();
        }

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
            ObjectTypeSmsg => $": {module}ServerMessage, IWorldMessage",
            ObjectTypeCmsg => $": {module}ClientMessage, IWorldMessage",
            ObjectTypeMsg => $": {module}ClientMessage, {module}ServerMessage, IWorldMessage",
            _ => throw new ArgumentOutOfRangeException()
        };

        s.Body($"public class {e.Name}{implements}", s =>
        {
            WriteDefinition(s, e, module);
            s.Newline();

            var functionName = e.IsWorld() ? "Body" : "";
            WriteWriteImplementation.WriteWrite(s, e, module, functionName);
            s.Newline();

            if (e.IsWorld())
            {
                WriteWorldHeader.WriteHeaders(s, e, module);
            }

            WriteReadImplementation.WriteRead(s, e, module, functionName);
            s.Newline();

            if (e.ManualSizeSubtraction is { } manualSizeSubtraction)
            {
                WriteSizeImplementation.WriteSize(s, e, module, manualSizeSubtraction);
                s.Newline();
            }
            else if (e is
                     {
                         ObjectType: ObjectTypeStruct or ObjectTypeCmsg or ObjectTypeSmsg or ObjectTypeMsg,
                         Sizes.ConstantSized: false
                     })
            {
                WriteSizeImplementation.WriteSize(s, e, module, 0);
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

        var postfix = d.UsedInIf ? "Type" : "";

        if (d.DataType is DataTypeArray array)
        {
            switch (array.Size)
            {
                case ArraySizeFixed fix:
                    s.Wln($"public const int {d.MemberName()}Length = {fix.Size};");
                    break;
                case ArraySizeVariable or ArraySizeEndless:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        s.Wln($"public required {d.CsTypeName()}{postfix} {d.MemberName()} {{ get; set; }}");
    }

    private static void WriteEnumValue(Writer s, PreparedObject po, Definition d, Container e, string module)
    {
        if (po.Enumerators is { } enumerators)
        {
            if (d.DataType is DataTypeEnum)
            {
                s.Wln(
                    $"internal {d.CsTypeName()} {d.MemberName()}Value => {d.MemberName()}.Match(");
                s.IncrementIndentation();
                foreach (var (enumerator, members) in enumerators)
                {
                    if (members.Any(m => e.FindDefinitionByName(m.Name).IsInType()))
                    {
                        s.Wln($"_ => {module}.{d.CsTypeName()}.{enumerator.ToEnumerator()},");
                    }
                }

                s.Wln("v => v");
                s.DecrementIndentation();
                s.Wln(");");
            }
        }
    }

    private static void WriteDefinition(Writer s, Container e, string module)
    {
        foreach (var po in e.AllPreparedObjects())
        {
            if (po.Enumerators is { } enumerators)
            {
                var d = e.FindDefinitionByName(po.Name);
                if (d.DataType is DataTypeEnum)
                {
                    foreach (var (enumerator, members) in enumerators)
                    {
                        if (members.Any(m => e.FindDefinitionByName(m.Name).IsInType()))
                        {
                            s.Body($"public class {d.PreparedObjectTypeName(enumerator)}", s =>
                            {
                                foreach (var member in members)
                                {
                                    var d = e.FindDefinitionByName(member.Name);
                                    WriteMemberDefinition(s, e, d);

                                    WriteEnumValue(s, member, d, e, module);
                                }
                            });
                        }
                    }
                }
                else
                {
                    s.Body($"public class {d.CsTypeName()}Type", s =>
                    {
                        s.Wln($"public required {d.CsTypeName()} Inner;");

                        foreach (var (enumerator, _) in enumerators)
                        {
                            s.Wln(
                                $"public {d.PreparedObjectTypeName(enumerator)}? {enumerator.ToEnumerator()};");
                        }
                    });

                    foreach (var (enumerator, members) in enumerators)
                    {
                        s.Body($"public class {d.PreparedObjectTypeName(enumerator)}", s =>
                        {
                            foreach (var member in members)
                            {
                                var d = e.FindDefinitionByName(member.Name);
                                WriteMemberDefinition(s, e, d);
                            }
                        });
                    }
                }
            }
        }

        foreach (var po in e.PreparedObjects)
        {
            var d = e.FindDefinitionByName(po.Name);
            WriteMemberDefinition(s, e, d);

            WriteEnumValue(s, po, d, e, module);
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

        if (e.IsWorld())
        {
            s.Wln("using WowSrp.Header;");
            s.Newline();
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

    private static string GetConditional(IfStatement statement, bool isWrite, string originalType,
        string containerName, string module, string enumerator)
    {
        var typeExists = statement.Members.Any(d => d.AllDefinitions().Any(d => d.IsInType()));
        var modulePrefix = isWrite && typeExists ? containerName : module;
        var dot = isWrite && typeExists ? "" : ".";

        switch (statement.DefinerType)
        {
            case IfStatementDefinerType.Flag:
                if (isWrite)
                {
                    return $" is {{}} {enumerator.ToVariableName()}";
                }

                return $".HasFlag({modulePrefix}.{originalType}{dot}{enumerator.ToEnumerator()})";
            case IfStatementDefinerType.Enum_:
                if (isWrite && typeExists)
                {
                    return
                        $" is {modulePrefix}.{originalType}{dot}{enumerator.ToEnumerator()} {enumerator.ToVariableName()}";
                }

                return $" is {modulePrefix}.{originalType}{dot}{enumerator.ToEnumerator()}";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public static void WriteIfStatement(Writer s, Container e, IfStatement statement, string module,
        Action<Writer, Container, StructMember, string> invocation,
        Action<Writer, Definition, IList<PreparedObject>, string> end,
        bool isWrite, string variablePrefix, bool isElseIf = false)
    {
        Func<string, string> transform = isWrite ? Utils.SnakeCaseToPascalCase : Utils.SnakeCaseToCamelCase;

        foreach (var (i, enumerator) in statement.Values
                     .Select((v, i) => (i, v)))
        {
            var cond = GetConditional(statement, isWrite, statement.OriginalType.CsType(), e.Name, module,
                enumerator);
            var flag = statement.OriginalType is DataTypeFlag;
            var prefix = i != 0 || isElseIf ? "else " : "";
            var value = flag ? isWrite ? $".{enumerator.ToMemberName()}" : ".Inner" : ".Value";
            var ifHeader = $"{prefix}if ({variablePrefix}{transform(statement.VariableName)}{value}{cond})";

            s.Body(ifHeader, s =>
            {
                foreach (var member in statement.Members)
                {
                    invocation(s, e, member, enumerator);
                }

                var po = e.FindPreparedObject(statement.VariableName);
                var d = e.FindDefinitionByName(statement.VariableName);

                var members = po.Enumerators[enumerator];

                if (members.Any(po => e.FindDefinitionByName(po.Name).IsInType()))
                {
                    end(s, d, members, enumerator);
                }
            });
        }

        foreach (var elseif in statement.ElseIfStatements)
        {
            WriteIfStatement(s, e, elseif, module, invocation, end, isWrite, variablePrefix, true);
        }

        s.Newline();
    }
}