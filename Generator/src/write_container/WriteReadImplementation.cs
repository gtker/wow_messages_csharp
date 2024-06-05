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

                foreach (var member in e.Members)
                {
                    WriteReadMember(s, e, member, module);
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
                }, ";");
            });
    }

    private static void WriteReadMember(Writer s, Container e, StructMember member, string module)
    {
        switch (member)
        {
            case StructMemberDefinition definition:
            {
                var d = definition.StructMemberContent;

                WriteReadForType(s, d, e.NeedsBodySize(), module);
                break;
            }
            case StructMemberIfStatement statement:
                WriteContainers.WriteIfStatement(s, e, statement.StructMemberContent, module,
                    (s, e, member, _) => { WriteReadMember(s, e, member, module); },
                    (s, d, members, enumerator) =>
                    {
                        var flagExtra = statement.StructMemberContent.IsFlag() ? $".{enumerator.ToMemberName()}" : "";
                        s.Body($"{d.VariableName()}{flagExtra} = new {d.PreparedObjectTypeName(enumerator)}", s =>
                            {
                                foreach (var member in members)
                                {
                                    var d = e.FindDefinitionByName(member.Name);
                                    if (d.IsNotInType())
                                    {
                                        continue;
                                    }

                                    s.Wln($"{member.Name.ToMemberName()} = {member.Name.ToVariableName()},");
                                }
                            }
                            , ";");
                    },
                    false, "");
                break;
            case StructMemberOptional:
                throw new NotImplementedException();
            default:
                throw new ArgumentOutOfRangeException(nameof(member));
        }
    }

    private static void WriteReadForType(Writer s, Definition d, bool needsSize, string module)
    {
        if (d.IsNotInType())
        {
            s.Wln("// ReSharper disable once UnusedVariable.Compiler");
        }

        var isWorld = module is "Vanilla" or "Tbc" or "Wrath";

        switch (d.DataType)
        {
            case DataTypeInteger i:
                s.Wln(
                    $"var {d.VariableName()} = await r.{i.IntegerType.ReadFunction()}(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeEnum dataTypeEnum:
                var prefix = d.UsedInIf ? $"{d.CsTypeName()}Type" : "var";

                s.Wln(
                    $"{prefix} {d.VariableName()} = ({dataTypeEnum.CsType()})await r.{dataTypeEnum.IntegerType.ReadFunction()}(cancellationToken).ConfigureAwait(false);");
                break;
            case DataTypeFlag dataTypeFlag:
                var read =
                    $"({dataTypeFlag.CsType()})await r.{dataTypeFlag.IntegerType.ReadFunction()}(cancellationToken).ConfigureAwait(false)";
                if (d.UsedInIf)
                {
                    s.Body($"var {d.VariableName()} = new {d.CsTypeName()}Type", s => { s.Wln($"Inner = {read},"); },
                        ";");
                }
                else
                {
                    s.Wln(
                        $"var {d.VariableName()} = {read};");
                }

                break;
            case DataTypeStruct:
                var body = isWorld ? "Body" : "";
                s.Wln(
                    $"var {d.VariableName()} = await {d.CsTypeName()}.Read{body}Async(r, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeSpell or DataTypeIpAddress or DataTypeItem or DataTypeLevel32 or DataTypeSeconds
                or DataTypeMilliseconds or DataTypeGold or DataTypeDateTime:
            {
                s.Wln(
                    $"var {d.VariableName()} = await r.ReadUInt(cancellationToken).ConfigureAwait(false);");
            }
                break;
            case DataTypeSpell16 or DataTypeLevel16:
            {
                s.Wln(
                    $"var {d.VariableName()} = await r.ReadUShort(cancellationToken).ConfigureAwait(false);");
            }
                break;
            case DataTypeLevel:
                s.Wln(
                    $"var {d.VariableName()} = await r.ReadByte(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeGuid:
                s.Wln(
                    $"var {d.VariableName()} = await r.ReadULong(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeString:
                s.Wln(
                    $"var {d.VariableName()} = await r.ReadString(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypePopulation:
                s.Wln(
                    $"var {d.VariableName()} = await r.ReadPopulation(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeFloatingPoint:
                s.Wln(
                    $"var {d.VariableName()} = await r.ReadFloat(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeBool b:
                s.Wln(
                    $"var {d.VariableName()} = await r.ReadBool{b.IntegerType.SizeBits()}(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeSizedCstring:
                s.Wln($"var {d.VariableName()}Length = await r.ReadUInt(cancellationToken).ConfigureAwait(false);");
                s.Wln(
                    $"var {d.VariableName()} = await r.ReadCString(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeCstring:
                s.Wln(
                    $"var {d.VariableName()} = await r.ReadCString(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypePackedGuid dataTypePackedGuid:
                s.Wln(
                    $"var {d.VariableName()} = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeArray array:
                WriteReadForArray(s, d, array, module, needsSize);
                break;


            case DataTypeAchievementDoneArray dataTypeAchievementDoneArray:
                throw new NotImplementedException();
            case DataTypeAchievementInProgressArray dataTypeAchievementInProgressArray:
                throw new NotImplementedException();
            case DataTypeAddonArray dataTypeAddonArray:
                throw new NotImplementedException();
            case DataTypeAuraMask dataTypeAuraMask:
                throw new NotImplementedException();
            case DataTypeCacheMask dataTypeCacheMask:
                throw new NotImplementedException();
            case DataTypeEnchantMask dataTypeEnchantMask:
                throw new NotImplementedException();
            case DataTypeNamedGuid dataTypeGuid:
                throw new NotImplementedException();
            case DataTypeInspectTalentGearMask dataTypeInspectTalentGearMask:
                throw new NotImplementedException();
            case DataTypeMonsterMoveSpline dataTypeMonsterMoveSpline:
                throw new NotImplementedException();
            case DataTypeUpdateMask dataTypeUpdateMask:
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

    private static void WriteReadForArray(Writer s, Definition d, DataTypeArray array, string module, bool needsSize)
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

        s.Wln($"var {d.VariableName()} = new List<{array.InnerType.CsType()}>();");

        var loopHeader = array.Size switch
        {
            ArraySizeFixed v => $"for (var i = 0; i < {v.Size.ToCamelCase()}; ++i)",
            ArraySizeVariable v => $"for (var i = 0; i < {v.Size.ToCamelCase()}; ++i)",
            ArraySizeEndless v => array.Compressed ? "while (r.Position < r.Length)" : "while (size <= bodySize)",
            _ => throw new ArgumentOutOfRangeException()
        };

        s.Body(loopHeader, s =>
        {
            switch (array.InnerType)
            {
                case ArrayTypeCstring:
                    s.Wln(
                        $"{d.VariableName()}.Add(await r.ReadCString(cancellationToken).ConfigureAwait(false));");
                    break;
                case ArrayTypeGuid:
                    s.Wln(
                        $"{d.VariableName()}.Add(await r.ReadULong(cancellationToken).ConfigureAwait(false));");
                    break;
                case ArrayTypeInteger it:
                    s.Wln(
                        $"{d.VariableName()}.Add(await r.{it.IntegerType.ReadFunction()}(cancellationToken).ConfigureAwait(false));");
                    break;
                case ArrayTypeSpell:
                    s.Wln(
                        $"{d.VariableName()}.Add(await r.ReadUInt(cancellationToken).ConfigureAwait(false));");
                    break;
                case ArrayTypeStruct e:
                    var body = e.StructData.IsWorld() ? "Body" : "";
                    s.Wln(
                        $"{d.VariableName()}.Add(await {module}.{e.StructData.Name}.Read{body}Async(r, cancellationToken).ConfigureAwait(false));");
                    break;
                case ArrayTypePackedGuid:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
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