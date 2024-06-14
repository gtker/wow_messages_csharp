using Generator.Extensions;
using Generator.Generated;

namespace Generator.write_container;

public static class WriteReadImplementation
{
    public static void WriteRead(Writer s, Container e, string module, string functionName)
    {
        var bodySize = e.NeedsBodySize() ? " uint bodySize," : "";

        s.Body(
            $"public static async Task<{e.Name}> Read{functionName}Async(Stream r,{bodySize} CancellationToken cancellationToken = default)",
            s =>
            {
                if (e.NeedsBodySize())
                {
                    s.Wln("var size = 0;");
                }

                var newline = false;
                foreach (var variable in e.EnumSeparateIfStatementVariables())
                {
                    newline = true;
                    s.Wln(variable);
                }

                if (newline)
                {
                    s.Newline();
                }

                foreach (var member in e.Members)
                {
                    WriteReadMember(s, e, member, module, "", null);
                }

                if (e.Optional is { } optional)
                {
                    s.Wln($"Optional{optional.Name.ToMemberName()}? optional{optional.Name.ToMemberName()} = null;");

                    s.Body("if (size < bodySize)", s =>
                    {
                        foreach (var member in optional.Members)
                        {
                            WriteReadMember(s, e, member, module, $"Optional{e.Optional.Name.ToMemberName()}.", null);
                        }

                        s.Body($"optional{optional.Name.ToMemberName()} = new Optional{optional.Name.ToMemberName()}",
                            s =>
                            {
                                foreach (var po in optional.PreparedObjects)
                                {
                                    var d = e.FindDefinitionByName(po.Name);
                                    if (d.IsNotInType())
                                    {
                                        continue;
                                    }

                                    s.Wln($"{po.Name.ToMemberName()} = {po.Name.ToVariableName()},");
                                }
                            }, ";");
                    });
                    s.Newline();
                }

                foreach (var po in e.AllPreparedObjects())
                {
                    if (po.EnumPartOfSeparateStatements)
                    {
                        foreach (var (i, (enumerator, members)) in po.Enumerators.Select((e, i) => (i, e)))
                        {
                            var prefix = i != 0 ? "else " : "";
                            var d = e.FindDefinitionByName(po.Name);

                            s.Body(
                                $"{prefix}if ({po.Name.ToVariableName()}.Value is {module}.{d.CsTypeName()}.{enumerator.ToEnumerator()})",
                                s =>
                                {
                                    WriteEnd(s, d, members, enumerator, false, e,
                                        str => $"{d.Name.ToVariableName()}If{str.ToMemberName()}");
                                });
                        }
                    }
                }

                s.Body($"return new {e.Name}", s =>
                {
                    foreach (var po in e.PreparedObjects)
                    {
                        var d = e.FindDefinitionByName(po.Name);
                        if (d.IsNotInType())
                        {
                            continue;
                        }


                        s.Wln($"{po.Name.ToMemberName()} = {po.Name.ToVariableName()},");
                    }

                    if (e.Optional is { } optional)
                    {
                        s.Wln($"{optional.Name.ToMemberName()} = optional{optional.Name.ToMemberName()},");
                    }
                }, ";");
            });
    }

    private static void WriteReadMember(Writer s, Container e, StructMember member, string module, string objectPrefix,
        string? variableNameOverride)
    {
        switch (member)
        {
            case StructMemberDefinition definition:
            {
                var d = definition.StructMemberContent;

                WriteReadForType(s, d, e.NeedsBodySize(), module, objectPrefix, variableNameOverride);
                break;
            }
            case StructMemberIfStatement statement:

                WriteContainers.WriteIfStatement(s, e, statement.StructMemberContent, module,
                    (s, e, member, _, _, objectPrefix) =>
                    {
                        var variableNameOverride = statement.StructMemberContent.PartOfSeparateIfStatement
                            ? statement.StructMemberContent.SeparateIfStatementNamePrefix()
                            : null;

                        WriteReadMember(s, e, member, module, objectPrefix, variableNameOverride);
                    },
                    (s, d, members, enumerator) =>
                    {
                        WriteEnd(s, d, members, enumerator, statement.StructMemberContent.IsFlag(), e,
                            str => str.ToVariableName());
                    },
                    false, "");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(member));
        }
    }

    private static void WriteEnd(Writer s, Definition d, IList<PreparedObject> members, string enumerator, bool isFlag,
        Container e, Func<string, string> variableName)
    {
        var flagExtra = isFlag ? $".{enumerator.ToMemberName()}" : "";
        s.Body($"{d.VariableName()}{flagExtra} = new {d.PreparedObjectTypeName(enumerator)}", s =>
        {
            foreach (var member in members)
            {
                var d = e.FindDefinitionByName(member.Name);
                if (d.IsNotInType())
                {
                    continue;
                }

                s.Wln($"{member.Name.ToMemberName()} = {variableName(member.Name)},");
            }
        }, ";");
    }

    private static void WriteReadForType(Writer s, Definition d, bool needsSize, string module, string objectPrefix,
        string? variableNameOverride)
    {
        if (d.IsNotInType())
        {
            s.Wln("// ReSharper disable once UnusedVariable.Compiler");
        }

        var isWorld = module is "Vanilla" or "Tbc" or "Wrath";

        var prefix = d.UsedInIf && d.DataType is DataTypeEnum ? $"{d.CsTypeName()}Type" : "var";
        var variable = variableNameOverride is not null
            ? $"{variableNameOverride}{d.MemberName()}"
            : $"{prefix} {d.VariableName()}";

        switch (d.DataType)
        {
            case DataTypeInteger i:
                s.Wln(
                    $"{variable} = await r.{i.IntegerType.ReadFunction()}(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeEnum dataTypeEnum:

                s.Wln(
                    $"{variable} = ({module}.{dataTypeEnum.CsType()})await r.{dataTypeEnum.IntegerType.ReadFunction()}(cancellationToken).ConfigureAwait(false);");
                break;
            case DataTypeFlag dataTypeFlag:
                var read =
                    $"({dataTypeFlag.CsType()})await r.{dataTypeFlag.IntegerType.ReadFunction()}(cancellationToken).ConfigureAwait(false)";
                if (d.UsedInIf)
                {
                    s.Body($"{variable} = new {d.CsTypeName()}Type", s => { s.Wln($"Inner = {read},"); },
                        ";");
                }
                else
                {
                    s.Wln(
                        $"{variable} = {read};");
                }

                break;
            case DataTypeStruct:
                var body = isWorld ? "Body" : "";
                s.Wln(
                    $"{variable} = await {d.CsTypeName()}.Read{body}Async(r, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeSpell or DataTypeIpAddress or DataTypeItem or DataTypeLevel32 or DataTypeSeconds
                or DataTypeMilliseconds or DataTypeGold or DataTypeDateTime:
            {
                s.Wln(
                    $"{variable} = await r.ReadUInt(cancellationToken).ConfigureAwait(false);");
            }
                break;
            case DataTypeSpell16 or DataTypeLevel16:
            {
                s.Wln(
                    $"{variable} = await r.ReadUShort(cancellationToken).ConfigureAwait(false);");
            }
                break;
            case DataTypeLevel:
                s.Wln(
                    $"{variable} = await r.ReadByte(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeGuid:
                s.Wln(
                    $"{variable} = await r.ReadULong(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeString:
                s.Wln(
                    $"{variable} = await r.ReadString(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypePopulation:
                s.Wln(
                    $"{variable} = await r.ReadPopulation(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeFloatingPoint:
                s.Wln(
                    $"{variable} = await r.ReadFloat(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeBool b:
                s.Wln(
                    $"{variable} = await r.ReadBool{b.IntegerType.SizeBits()}(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeSizedCstring:
                s.Wln(
                    $"{variable} = await r.ReadSizedCString(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeCstring:
                s.Wln(
                    $"{variable} = await r.ReadCString(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypePackedGuid:
                s.Wln(
                    $"{variable} = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeNamedGuid:
                s.Wln($"{variable} = await NamedGuid.ReadAsync(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeUpdateMask:
                s.Wln($"{variable} = await UpdateMask.ReadAsync(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeMonsterMoveSpline:
                s.Wln(
                    $"{variable} = await ReadUtils.ReadMonsterMoveSpline(r, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeAuraMask:
                s.Wln(
                    $"{variable} = await AuraMask.ReadAsync(r, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeArray array:
                WriteReadForArray(s, d, array, module, needsSize, objectPrefix, variable);
                break;


            case DataTypeAchievementDoneArray dataTypeAchievementDoneArray:
                throw new NotImplementedException();
            case DataTypeAchievementInProgressArray dataTypeAchievementInProgressArray:
                throw new NotImplementedException();
            case DataTypeAddonArray dataTypeAddonArray:
                throw new NotImplementedException();
            case DataTypeCacheMask dataTypeCacheMask:
                throw new NotImplementedException();
            case DataTypeEnchantMask dataTypeEnchantMask:
                throw new NotImplementedException();
            case DataTypeInspectTalentGearMask dataTypeInspectTalentGearMask:
                throw new NotImplementedException();
            case DataTypeVariableItemRandomProperty dataTypeVariableItemRandomProperty:
                throw new NotImplementedException();
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (needsSize && d.DataType is not DataTypeArray)
        {
            var size = d.Size("", false);
            s.Wln($"size += {size};");
        }

        s.Newline();
    }

    private static void WriteReadForArray(Writer s, Definition d, DataTypeArray array, string module, bool needsSize,
        string objectPrefix, string variable)
    {
        if (array.Compressed)
        {
            s.Wln("var decompressedLength = await r.ReadUInt(cancellationToken).ConfigureAwait(false);");
            s.Wln("size += 4;");
            s.Newline();

            s.Wln("var decompressed = new byte[decompressedLength];");
            s.Wln("var remaining = new byte[bodySize - size];");
            s.Wln("r.ReadExactly(remaining);");
            s.Newline();

            s.Wln(
                "var zlib = new System.IO.Compression.ZLibStream(new MemoryStream(remaining), System.IO.Compression.CompressionMode.Decompress);");
            s.Wln("zlib.ReadAtLeast(decompressed, remaining.Length);");
            s.Newline();

            s.Wln("r = new MemoryStream(decompressed);");
        }

        var memberLength = $"{objectPrefix}{d.MemberName()}Length";

        switch (array.Size)
        {
            case ArraySizeFixed:
                s.Wln($"{variable} = new {array.InnerType.CsType()}[{memberLength}];");
                break;
            case ArraySizeVariable or ArraySizeEndless:
                s.Wln($"{variable} = new List<{array.InnerType.CsType()}>();");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        var loopHeader = array.Size switch
        {
            ArraySizeFixed v => $"for (var i = 0; i < {memberLength}; ++i)",
            ArraySizeVariable v => $"for (var i = 0; i < {v.Size.ToCamelCase()}; ++i)",
            ArraySizeEndless v => array.Compressed ? "while (r.Position < r.Length)" : "while (size <= bodySize)",
            _ => throw new ArgumentOutOfRangeException()
        };

        s.Body(loopHeader, s =>
        {
            string item;
            switch (array.InnerType)
            {
                case ArrayTypeCstring:
                    item = "await r.ReadCString(cancellationToken).ConfigureAwait(false)";
                    break;
                case ArrayTypeGuid:
                    item = "await r.ReadULong(cancellationToken).ConfigureAwait(false)";
                    break;
                case ArrayTypeInteger it:
                    item =
                        $"await r.{it.IntegerType.ReadFunction()}(cancellationToken).ConfigureAwait(false)";
                    break;
                case ArrayTypeSpell:
                    item = "await r.ReadUInt(cancellationToken).ConfigureAwait(false)";
                    break;
                case ArrayTypeStruct e:
                    var body = e.StructData.IsWorld() ? "Body" : "";
                    item =
                        $"await {module}.{e.StructData.Name}.Read{body}Async(r, cancellationToken).ConfigureAwait(false)";
                    break;
                case ArrayTypePackedGuid:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (array.FixedSize())
            {
                s.Wln($"{d.VariableName()}[i] = {item};");
            }
            else
            {
                s.Wln($"{d.VariableName()}.Add({item});");
            }

            if (needsSize)
            {
                switch (array.InnerType)
                {
                    case ArrayTypeCstring:
                        s.Wln($"size += {d.VariableName()}[^1].Length + 1;");
                        break;
                    case ArrayTypeGuid:
                        s.Wln("size += 8;");
                        break;
                    case ArrayTypeSpell:
                        s.Wln("size += 4;");
                        break;
                    case ArrayTypeInteger arrayTypeInteger:
                        s.Wln($"size += {arrayTypeInteger.IntegerType.SizeBytes()};");
                        break;
                    case ArrayTypeStruct arrayTypeStruct:
                        if (arrayTypeStruct.StructData.Sizes.ConstantSized)
                        {
                            s.Wln($"size += {arrayTypeStruct.StructData.Sizes.MinimumSize};");
                        }
                        else
                        {
                            s.Wln($"size += {d.VariableName()}[^1].Size();");
                        }

                        break;
                    case ArrayTypePackedGuid:
                        throw new NotImplementedException();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        });
    }
}