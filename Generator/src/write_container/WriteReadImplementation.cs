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
                if (e.Tags.Compressed is true)
                {
                    s.Wln("var decompressedLength = await r.ReadUInt(cancellationToken).ConfigureAwait(false);");
                    s.Wln("bodySize -= 4;");
                    s.Newline();

                    s.Wln("var decompressed = new byte[decompressedLength];");
                    s.Wln("var remaining = new byte[bodySize];");
                    s.Wln("await r.ReadExactlyAsync(remaining, cancellationToken).ConfigureAwait(false);");
                    s.Newline();

                    s.Wln(
                        "var zlib = new System.IO.Compression.ZLibStream(new MemoryStream(remaining), System.IO.Compression.CompressionMode.Decompress);");
                    s.Wln("zlib.ReadAtLeast(decompressed, int.Min((int)bodySize, (int)decompressedLength));");
                    s.Newline();

                    s.Wln("r = new MemoryStream(decompressed);");
                    s.Wln("bodySize = decompressedLength;");
                    s.Newline();
                }

                if (e.NeedsBodySize())
                {
                    s.Wln("// ReSharper disable once InconsistentNaming");
                    s.Wln("var __size = 0;");
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

                    s.Body("if (__size < bodySize)", s =>
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
                                        str => $"{d.Name.ToVariableName()}If{str.ToMemberName()}", enumerator);
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
                var po = e.FindPreparedObject(d.Name);

                WriteReadForType(s, d, e, po, e.NeedsBodySize(), module, objectPrefix, variableNameOverride);
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
                    (s, d, members, enumerator, usedEnumerator) =>
                    {
                        var po = e.FindPreparedObject(d.Name);
                        WriteEnd(s, d, members, enumerator,
                            statement.StructMemberContent.IsFlag() && po.DefinerType is DefinerType.Flag, e,
                            str => str.ToVariableName(), usedEnumerator);
                    },
                    false, "");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(member));
        }
    }

    private static void WriteEnd(Writer s, Definition d, IList<PreparedObject> members, string enumerator, bool isFlag,
        Container e, Func<string, string> variableName, string usedEnumerator)
    {
        var flagExtra = isFlag ? $".{usedEnumerator.ToMemberName()}" : "";
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

    private static void WriteReadForType(Writer s, Definition d, Container e, PreparedObject po, bool needsSize,
        string module,
        string objectPrefix,
        string? variableNameOverride)
    {
        if (d.IsNotInType())
        {
            s.Wln("// ReSharper disable once UnusedVariable.Compiler");
        }

        var isWorld = module is "Vanilla" or "Tbc" or "Wrath";

        var prefix = po.IsEnumFromFlag(d) ? po.EnumName(e) :
            d is { UsedInIf: true, DataType: DataTypeEnum } ? $"{d.CsTypeName()}Type" : "var";
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
                if (po.DefinerType is DefinerType.Enum_)
                {
                    s.Wln(
                        $"{variable} = ({module}.{dataTypeFlag.CsType()})await r.{dataTypeFlag.IntegerType.ReadFunction()}(cancellationToken).ConfigureAwait(false);");
                }
                else if (d.UsedInIf)
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

            case DataTypeMonsterMoveSpline:
                s.Wln(
                    $"{variable} = await ReadUtils.ReadMonsterMoveSpline(r, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeAddonArray or DataTypeCacheMask or DataTypeVariableItemRandomProperty
                or DataTypeInspectTalentGearMask or DataTypeEnchantMask or DataTypeAuraMask or DataTypeUpdateMask
                or DataTypeNamedGuid:
                s.Wln(
                    $"{variable} = await {d.CsTypeName()}.ReadAsync(r, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeAchievementDoneArray:
                s.Wln(
                    $"{variable} = await ReadUtils.ReadAchievementDoneArray(r, cancellationToken).ConfigureAwait(false);");
                break;
            case DataTypeAchievementInProgressArray:
                s.Wln(
                    $"{variable} = await ReadUtils.ReadAchievementInProgressArray(r, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeArray array:
                WriteReadForArray(s, d, array, module, needsSize, objectPrefix, variable);
                break;


            default:
                throw new ArgumentOutOfRangeException();
        }

        if (needsSize && d.DataType is not DataTypeArray)
        {
            var size = d.Size(module, "", false);
            s.Wln($"__size += {size};");
        }

        s.Newline();
    }

    private static void WriteReadForArray(Writer s, Definition d, DataTypeArray array, string module, bool needsSize,
        string objectPrefix, string variable)
    {
        if (array.Compressed)
        {
            s.Wln("var decompressedLength = await r.ReadUInt(cancellationToken).ConfigureAwait(false);");
            s.Wln("__size += 4;");
            s.Newline();

            s.Wln("var decompressed = new byte[decompressedLength];");
            s.Wln("var remaining = new byte[bodySize - __size];");
            s.Wln("await r.ReadExactlyAsync(remaining, cancellationToken).ConfigureAwait(false);");
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
            ArraySizeFixed => $"for (var i = 0; i < {memberLength}; ++i)",
            ArraySizeVariable v => $"for (var i = 0; i < {v.Size.ToCamelCase()}; ++i)",
            ArraySizeEndless => array.Compressed ? "while (r.Position < r.Length)" : "while (__size < bodySize)",
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
                    if (e.StructData.Tags.Version_.IsVersionAll())
                    {
                        module = "All";
                    }

                    item =
                        $"await {module}.{e.StructData.Name}.Read{body}Async(r, cancellationToken).ConfigureAwait(false)";
                    break;
                case ArrayTypePackedGuid:
                    item = "await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false)";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            s.Wln(array.FixedSize() ? $"{d.VariableName()}[i] = {item};" : $"{d.VariableName()}.Add({item});");

            if (!needsSize)
            {
                return;
            }

            switch (array.InnerType)
            {
                case ArrayTypeCstring:
                    s.Wln($"__size += {d.VariableName()}[^1].Length + 1;");
                    break;
                case ArrayTypeGuid:
                    s.Wln("__size += 8;");
                    break;
                case ArrayTypeSpell:
                    s.Wln("__size += 4;");
                    break;
                case ArrayTypeInteger arrayTypeInteger:
                    s.Wln($"__size += {arrayTypeInteger.IntegerType.SizeBytes()};");
                    break;
                case ArrayTypeStruct arrayTypeStruct:
                    s.Wln(arrayTypeStruct.StructData.Sizes.ConstantSized
                        ? $"__size += {arrayTypeStruct.StructData.Sizes.MinimumSize};"
                        : $"__size += {d.VariableName()}[^1].Size();");

                    break;
                case ArrayTypePackedGuid:
                    s.Wln($"__size += {d.VariableName()}[^1].PackedGuidLength();");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        });
    }
}