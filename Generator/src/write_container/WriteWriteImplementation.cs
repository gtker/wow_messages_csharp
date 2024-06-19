using Generator.Extensions;
using Generator.Generated;

namespace Generator.write_container;

public static class WriteWriteImplementation
{
    public static void WriteWrite(Writer s, Container e, string module, string functionName)
    {
        s.Body($"public async Task Write{functionName}Async(Stream w, CancellationToken cancellationToken = default)",
            s =>
            {
                switch (e.ObjectType)
                {
                    case ObjectTypeClogin objectTypeClogin:
                        s.Wln("// opcode: u8");
                        s.Wln(
                            $"await w.WriteByte({objectTypeClogin.Opcode}, cancellationToken).ConfigureAwait(false);");
                        s.Newline();
                        break;
                    case ObjectTypeSlogin objectTypeSlogin:
                        s.Wln("// opcode: u8");
                        s.Wln(
                            $"await w.WriteByte({objectTypeSlogin.Opcode}, cancellationToken).ConfigureAwait(false);");
                        s.Newline();
                        break;
                    case ObjectTypeCmsg:
                        break;
                    case ObjectTypeMsg:
                        break;
                    case ObjectTypeSmsg:
                        break;
                    case ObjectTypeStruct:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                foreach (var member in e.Members)
                {
                    WriteWriteMember(s, e, member, module, "");
                }

                if (e.Optional is { } optional)
                {
                    s.Body($"if ({e.Optional.Name.ToMemberName()} is {{ }} {e.Optional.Name.ToVariableName()})", s =>
                    {
                        foreach (var member in optional.Members)
                        {
                            WriteWriteMember(s, e, member, module, $"{e.Optional.Name.ToVariableName()}.");
                        }
                    });
                }
            });
    }

    private static void WriteWriteMember(Writer s, Container e, StructMember member, string module, string prefix)
    {
        switch (member)
        {
            case StructMemberDefinition d:
                WriteWriteForType(s, d.StructMemberContent, prefix, module);
                s.Newline();
                break;
            case StructMemberIfStatement statement:
                WriteContainers.WriteIfStatement(s, e, statement.StructMemberContent, module,
                    (s, e, member, enumerator, variablePrefix, objectPrefix) =>
                    {
                        WriteWriteMember(s, e, member, module, variablePrefix);
                    },
                    (_, _, _, _) => { },
                    true, prefix);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(member));
        }
    }

    private static void WriteWriteForType(Writer s, Definition d, string prefix, string module)
    {
        var value = $"{prefix}{d.MemberName()}";
        if (d.SizeOfFieldsBeforeSize is not null)
        {
            var cast = d.DataType.CsType();
            value = $"({cast})Size()";
        }
        else if (d.ConstantValue is { } val)
        {
            value = val.value;
        }
        else if (d.UsedAsSizeIn is { } v)
        {
            value = $"({d.DataType.CsType()}){prefix}{v.ToPascalCase()}.Count";
        }

        switch (d.DataType)
        {
            case DataTypeInteger i:
                s.Wln(
                    $"await w.{i.IntegerType.WriteFunction()}({value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeEnum i:
                if (d.UsedInIf)
                {
                    value += "Value";
                }

                s.Wln(
                    $"await w.{i.IntegerType.WriteFunction()}(({i.IntegerType.CsType()}){value}, cancellationToken).ConfigureAwait(false);");
                break;
            case DataTypeFlag i:
                if (d.UsedInIf)
                {
                    value += ".Inner";
                }

                s.Wln(
                    $"await w.{i.IntegerType.WriteFunction()}(({i.IntegerType.CsType()}){value}, cancellationToken).ConfigureAwait(false);");
                break;
            case DataTypeStruct dataTypeStruct:
                var body = dataTypeStruct.StructData.IsWorld() ? "Body" : "";
                s.Wln($"await {value}.Write{body}Async(w, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeSpell or DataTypeIpAddress or DataTypeItem or DataTypeLevel32 or DataTypeSeconds
                or DataTypeMilliseconds or DataTypeGold or DataTypeDateTime:
            {
                s.Wln($"await w.WriteUInt({value}, cancellationToken).ConfigureAwait(false);");
            }
                break;
            case DataTypeSpell16 or DataTypeLevel16:
            {
                s.Wln($"await w.WriteUShort({value}, cancellationToken).ConfigureAwait(false);");
            }
                break;
            case DataTypeLevel:
                s.Wln($"await w.WriteByte({value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeGuid:
                s.Wln($"await w.WriteULong({value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeString:
                s.Wln($"await w.WriteString({value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypePopulation:
                s.Wln($"await w.WritePopulation({value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeFloatingPoint:
                s.Wln($"await w.WriteFloat({value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeBool b:
                s.Wln(
                    $"await w.WriteBool{b.IntegerType.SizeBits()}({value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeSizedCstring:
                s.Wln($"await w.WriteSizedCString({value}, cancellationToken).ConfigureAwait(false);");
                break;
            case DataTypeCstring:
                s.Wln($"await w.WriteCString({value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypePackedGuid:
                s.Wln($"await w.WritePackedGuid({value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeNamedGuid:
                s.Wln($"await {value}.WriteAsync(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeUpdateMask:
                s.Wln($"await {value}.WriteAsync(cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeMonsterMoveSpline:
                s.Wln($"await ReadUtils.WriteMonsterMoveSpline(w, {value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeAuraMask:
                s.Wln($"await {value}.WriteAsync(w, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeEnchantMask:
                s.Wln($"await {value}.WriteAsync(w, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeAchievementDoneArray:
                s.Wln(
                    $"await ReadUtils.WriteAchievementDoneArray({value}, w, cancellationToken).ConfigureAwait(false);");
                break;
            case DataTypeAchievementInProgressArray:
                s.Wln(
                    $"await ReadUtils.WriteAchievementInProgressArray({value}, w, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeArray array:
                WriteWriteForArray(s, d, array, prefix);
                break;

            case DataTypeAddonArray dataTypeAddonArray:
                throw new NotImplementedException();
            case DataTypeCacheMask dataTypeCacheMask:
                throw new NotImplementedException();
            case DataTypeInspectTalentGearMask dataTypeInspectTalentGearMask:
                throw new NotImplementedException();
            case DataTypeVariableItemRandomProperty dataTypeVariableItemRandomProperty:
                throw new NotImplementedException();
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static void WriteWriteForArray(Writer s, Definition d, DataTypeArray array, string prefix)
    {
        if (d.IsCompressed())
        {
            s.OpenCurly($"if ({prefix}{d.Name.ToMemberName()}.Count != 0)");
            s.Wln("var oldStream = w;");
            s.Wln("w = new MemoryStream();");
        }

        s.Body($"foreach (var v in {prefix}{d.MemberName()})", s =>
        {
            switch (array.InnerType)
            {
                case ArrayTypeCstring:
                    s.Wln("await w.WriteCString(v, cancellationToken).ConfigureAwait(false);");
                    break;
                case ArrayTypeGuid:
                    s.Wln("await w.WriteULong(v, cancellationToken).ConfigureAwait(false);");
                    break;
                case ArrayTypeInteger it:
                    s.Wln(
                        $"await w.{it.IntegerType.WriteFunction()}(v, cancellationToken).ConfigureAwait(false);");
                    break;
                case ArrayTypeSpell:
                    s.Wln("await w.WriteUInt(v, cancellationToken).ConfigureAwait(false);");
                    break;
                case ArrayTypeStruct dataTypeStruct:
                    var body = dataTypeStruct.StructData.IsWorld() ? "Body" : "";
                    s.Wln($"await v.Write{body}Async(w, cancellationToken).ConfigureAwait(false);");
                    break;
                case ArrayTypePackedGuid:
                    s.Wln("await w.WritePackedGuid(v, cancellationToken).ConfigureAwait(false);");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        });

        if (d.IsCompressed())
        {
            s.Wln("var uncompressedLength = w.Position;");
            s.Newline();

            s.Wln("var compressedOutput = new MemoryStream();");
            s.Wln(
                "var zlib = new System.IO.Compression.ZLibStream(compressedOutput, System.IO.Compression.CompressionMode.Compress);");
            s.Wln("zlib.Write((w as MemoryStream)!.ToArray());");
            s.Wln("zlib.Flush();");
            s.Newline();

            s.Wln("w = oldStream;");
            s.Wln("await w.WriteUInt((uint)uncompressedLength, cancellationToken).ConfigureAwait(false);");
            s.Wln("await w.WriteAsync(compressedOutput.ToArray(), cancellationToken).ConfigureAwait(false);");

            s.ClosingCurly();
            s.Body("else", s => { s.Wln("await w.WriteUInt(0, cancellationToken).ConfigureAwait(false);"); });
        }
    }
}