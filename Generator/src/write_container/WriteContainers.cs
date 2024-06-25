using Generator.Extensions;
using Generator.Generated;

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

        foreach (var po in e.AllEnumsWithMembers())
        {
            newline = true;

            var d = e.FindDefinitionByName(po.Name);
            s.W($"using {po.EnumName(d)} = OneOf.OneOf<");

            foreach (var (enumerator, members) in po.Enumerators)
            {
                if (members.Any(m => e.FindDefinitionByName(m.Name).IsInType()))
                {
                    s.WNoIndentation($"{e.Name}.{d.PreparedObjectTypeName(enumerator)}, ");
                }
            }

            s.WlnNoIndentation($"{d.CsTypeName()}>;");
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

    private static void WriteMemberDefinition(Writer s, Container e, Definition d, string module)
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

        var prefix = d.DataType is DataTypeEnum or DataTypeFlag && !d.UsedInIf ? $"{module}." : "";

        var typeName = $"{prefix}{d.CsTypeName()}{postfix}";
        var po = e.FindPreparedObject(d.Name);
        if (po.IsEnumFromFlag(d))
        {
            typeName = po.EnumName(d);
        }

        s.Wln($"public required {typeName} {d.MemberName()} {{ get; set; }}");
    }

    private static void WriteEnumValue(Writer s, PreparedObject po, Definition d, Container e, string module)
    {
        if (po.Enumerators is { } enumerators)
        {
            if (po.DefinerType is DefinerType.Enum_)
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
        foreach (var po in e.AllEnumsWithMembers())
        {
            foreach (var (enumerator, members) in po.Enumerators)
            {
                var d = e.FindDefinitionByName(po.Name);
                if (members.Any(m => e.FindDefinitionByName(m.Name).IsInType()))
                {
                    s.Body($"public class {d.PreparedObjectTypeName(enumerator)}", s =>
                    {
                        foreach (var member in members)
                        {
                            var d = e.FindDefinitionByName(member.Name);
                            WriteMemberDefinition(s, e, d, module);

                            if (e.Name == "MovementBlock" && member.Name == "spline_flags")
                            {
                                int a;
                            }

                            WriteEnumValue(s, member, d, e, module);
                        }
                    });
                }
            }
        }

        foreach (var po in e.AllFlagsWithMembers())
        {
            var d = e.FindDefinitionByName(po.Name);

            if (po.IsElseifFlag && po.Enumerators is not null && po.Enumerators.Count == 1)
            {
                continue;
            }

            s.Body($"public class {d.CsTypeName()}Type", s =>
            {
                s.Wln($"public required {d.CsTypeName()} Inner;");

                foreach (var (enumerator, members) in po.Enumerators)
                {
                    var typeName = d.PreparedObjectTypeName(enumerator);
                    if (po.IsFakeElseIf(members))
                    {
                        typeName = $"{typeName}Multi";
                    }
                    else
                    {
                        typeName = $"{typeName}?";
                    }


                    s.Wln(
                        $"public {typeName} {enumerator.ToEnumerator()};");
                }
            });

            foreach (var (enumerator, members) in po.Enumerators)
            {
                if (po.IsFakeElseIf(members))
                {
                    continue;
                }

                s.Body($"public class {d.PreparedObjectTypeName(enumerator)}", s =>
                {
                    foreach (var member in members)
                    {
                        var d = e.FindDefinitionByName(member.Name);
                        WriteMemberDefinition(s, e, d, module);

                        var newMember = member;
                        if (member.IsElseifFlag)
                        {
                            newMember = member.Enumerators.First().Value[0];
                        }

                        WriteEnumValue(s, newMember, d, e, module);
                    }
                });
            }
        }

        foreach (var po in e.PreparedObjects)
        {
            var d = e.FindDefinitionByName(po.Name);
            WriteMemberDefinition(s, e, d, module);

            WriteEnumValue(s, po, d, e, module);
        }

        if (e.Optional is { } optional)
        {
            s.Body($"public struct Optional{optional.Name.ToMemberName()}", s =>
            {
                foreach (var po in optional.PreparedObjects)
                {
                    var d = e.FindDefinitionByName(po.Name);
                    WriteMemberDefinition(s, e, d, module);
                }
            });

            s.Wln(
                $"public required Optional{optional.Name.ToMemberName()}? {optional.Name.ToMemberName()} {{ get; set; }}");
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
            if (e.RequiresAllModule())
            {
                s.Wln("using WowWorldMessages.All;");
            }

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
        string containerName, string module, string enumerator, string variablePrefix, Container e)
    {
        var typeExists = statement.Members.Any(d => d.AllDefinitions().Any(d => d.IsInType()));
        var modulePrefix = isWrite && typeExists ? containerName : module;
        var dot = isWrite && typeExists ? "" : ".";

        var po = e.FindPreparedObject(statement.VariableName);

        switch (statement.DefinerType)
        {
            case DefinerType.Flag:
                if (po.DefinerType is DefinerType.Enum_ || po.IsElseifFlag)
                {
                    if (isWrite)
                    {
                        return $" is {originalType}{enumerator.ToEnumerator()} {variablePrefix}";
                    }

                    return $" is {module}.{originalType}.{enumerator.ToEnumerator()}";
                }

                if (isWrite)
                {
                    return $" is {{}} {variablePrefix}";
                }

                return $".HasFlag({modulePrefix}.{originalType}{dot}{enumerator.ToEnumerator()})";
            case DefinerType.Enum_:
                if (isWrite && typeExists)
                {
                    return
                        $" is {modulePrefix}.{originalType}{dot}{enumerator.ToEnumerator()} {variablePrefix}";
                }

                return $" is {modulePrefix}.{originalType}{dot}{enumerator.ToEnumerator()}";
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static string GetVariablePrefixExtra(IfStatement statement)
    {
        // C# does not have block scope variables, so if the same if
        // statement is present multiple times we need separate identifiers
        var str = "";

        foreach (var d in statement.AllDefinitions())
        {
            str += d.Name[0];
        }

        return str;
    }

    private static string GetIfStatementVariablePrefix(Definition d, string enumerator, IfStatement statement)
    {
        var s = d.PreparedObjectTypeName(enumerator);
        var t = char.ToLower(s[0]);
        var extra = statement.PartOfSeparateIfStatement ? GetVariablePrefixExtra(statement) : "";
        return t + s[1..] + extra;
    }

    public static void WriteIfStatement(Writer s, Container e, IfStatement statement, string module,
        Action<Writer, Container, StructMember, string, string, string> invocation,
        Action<Writer, Definition, IList<PreparedObject>, string, string> end,
        bool isWrite, string variablePrefix, string? primaryName = null)
    {
        Func<string, string> transform = isWrite ? Utils.SnakeCaseToPascalCase : Utils.SnakeCaseToCamelCase;
        var isElseIf = primaryName != null;

        foreach (var (i, enumerator) in statement.Values
                     .Select((v, i) => (i, v)))
        {
            var po = e.FindPreparedObject(statement.VariableName);
            var d = e.FindDefinitionByName(statement.VariableName);

            var newVariablePrefix = GetIfStatementVariablePrefix(d, enumerator, statement);
            var cond = GetConditional(statement, isWrite, statement.OriginalType.CsType(), e.Name, module,
                enumerator, newVariablePrefix, e);
            var flag = po.DefinerType is DefinerType.Flag;
            var prefix = i != 0 || isElseIf ? "else " : "";
            var isEnumForFlag = (flag && po.IsElseifFlag && statement.ElseIfStatements.Count != 0) ||
                                (isElseIf && po.IsElseifFlag);
            var usedEnumerator = primaryName ?? enumerator;
            var value = isEnumForFlag && isWrite ? $".{usedEnumerator.ToMemberName()}.Value" :
                flag ? isWrite ? $".{usedEnumerator.ToMemberName()}" : ".Inner" : ".Value";
            var ifHeader = $"{prefix}if ({variablePrefix}{transform(statement.VariableName)}{value}{cond})";

            s.Body(ifHeader, s =>
            {
                foreach (var member in statement.Members)
                {
                    var objectPrefix = $"{d.PreparedObjectTypeName(enumerator)}.";
                    invocation(s, e, member, enumerator, $"{newVariablePrefix}.", objectPrefix);
                }

                var members = !po.IsElseifFlag ? po.Enumerators[enumerator] : po.Enumerators.Take(1).First().Value;

                if (members.Any(po => e.FindDefinitionByName(po.Name).IsInType()))
                {
                    if (!statement.PartOfSeparateIfStatement)
                    {
                        end(s, d, members, enumerator, usedEnumerator);
                    }
                }
            });
        }

        foreach (var elseif in statement.ElseIfStatements)
        {
            WriteIfStatement(s, e, elseif, module, invocation, end, isWrite, variablePrefix, statement.Values[0]);
        }

        if (!isElseIf)
        {
            s.Newline();
        }
    }
}