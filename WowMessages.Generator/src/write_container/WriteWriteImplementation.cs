using WowMessages.Generator.Extensions;
using WowMessages.Generator.Generated;

namespace WowMessages.Generator.write_container;

public static class WriteWriteImplementation
{
    public static void WriteWrite(Writer s, Container e, string module)
    {
        s.Body("public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default)", s =>
        {
            switch (e.ObjectType)
            {
                case ObjectTypeClogin objectTypeClogin:
                    s.Wln("// opcode: u8");
                    s.Wln(
                        $"await WriteUtils.WriteByte(w, {objectTypeClogin.Opcode}, cancellationToken).ConfigureAwait(false);");
                    s.Newline();
                    break;
                case ObjectTypeSlogin objectTypeSlogin:
                    s.Wln("// opcode: u8");
                    s.Wln(
                        $"await WriteUtils.WriteByte(w, {objectTypeSlogin.Opcode}, cancellationToken).ConfigureAwait(false);");
                    s.Newline();
                    break;
                case ObjectTypeCmsg objectTypeCmsg:
                    throw new NotImplementedException();
                case ObjectTypeMsg objectTypeMsg:
                    throw new NotImplementedException();
                case ObjectTypeSmsg objectTypeSmsg:
                    throw new NotImplementedException();
                case ObjectTypeStruct objectTypeStruct:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            foreach (var member in e.Members)
            {
                WriteWriteMember(s, e, member, module, "");
            }
        });
    }

    private static void WriteWriteMember(Writer s, Container e, StructMember member, string module, string prefix)
    {
        switch (member)
        {
            case StructMemberDefinition d:
                WriteWriteForType(s, d.StructMemberContent, prefix);
                s.Newline();
                break;
            case StructMemberIfStatement statement:
                WriteContainers.WriteIfStatement(s, e, statement.StructMemberContent, module,
                    (s, e, member, enumerator) =>
                    {
                        var newPrefix = statement.StructMemberContent.IsFlag()
                            ? $"{enumerator.ToVariableName()}."
                            : $"{statement.StructMemberContent.VariableName.ToVariableName()}.";
                        WriteWriteMember(s, e, member, module, newPrefix);
                    },
                    (_, _, _, _) => { },
                    true, prefix);
                break;
            case StructMemberOptional structMemberOptional:
                throw new NotImplementedException();
            default:
                throw new ArgumentOutOfRangeException(nameof(member));
        }
    }

    private static void WriteWriteForType(Writer s, Definition d, string prefix)
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
                    $"await WriteUtils.{i.IntegerType.WriteFunction()}(w, {value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeEnum i:
                if (d.UsedInIf)
                {
                    value += "Value";
                }

                s.Wln(
                    $"await WriteUtils.{i.IntegerType.WriteFunction()}(w, ({i.IntegerType.CsType()}){value}, cancellationToken).ConfigureAwait(false);");
                break;
            case DataTypeFlag i:
                if (d.UsedInIf)
                {
                    value += ".Inner";
                }

                s.Wln(
                    $"await WriteUtils.{i.IntegerType.WriteFunction()}(w, ({i.IntegerType.CsType()}){value}, cancellationToken).ConfigureAwait(false);");
                break;
            case DataTypeStruct:
                s.Wln($"await {value}.WriteAsync(w, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeSpell or DataTypeIpAddress or DataTypeItem or DataTypeLevel32 or DataTypeSeconds
                or DataTypeMilliseconds or DataTypeGold or DataTypeDateTime:
            {
                s.Wln($"await WriteUtils.WriteUInt(w, {value}, cancellationToken).ConfigureAwait(false);");
            }
                break;
            case DataTypeSpell16 or DataTypeLevel16:
            {
                s.Wln($"await WriteUtils.WriteUShort(w, {value}, cancellationToken).ConfigureAwait(false);");
            }
                break;
            case DataTypeLevel:
                s.Wln($"await WriteUtils.WriteByte(w, {value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeGuid:
                s.Wln($"await WriteUtils.WriteULong(w, {value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeString:
                s.Wln($"await WriteUtils.WriteString(w, {value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypePopulation:
                s.Wln($"await WriteUtils.WritePopulation(w, {value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeFloatingPoint:
                s.Wln($"await WriteUtils.WriteFloat(w, {value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeBool b:
                s.Wln(
                    $"await WriteUtils.WriteBool{b.IntegerType.SizeBits()}(w, {value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeCstring:
                s.Wln($"await WriteUtils.WriteCString(w, {value}, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeArray array:
                WriteWriteForArray(s, d, array, prefix);
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
            case DataTypePackedGuid dataTypePackedGuid:
                throw new NotImplementedException();
            case DataTypeInspectTalentGearMask dataTypeInspectTalentGearMask:
                throw new NotImplementedException();
            case DataTypeMonsterMoveSpline dataTypeMonsterMoveSpline:
                throw new NotImplementedException();
            case DataTypeSizedCstring dataTypeSizedCstring:
                throw new NotImplementedException();
            case DataTypeUpdateMask dataTypeUpdateMask:
                throw new NotImplementedException();
            case DataTypeVariableItemRandomProperty dataTypeVariableItemRandomProperty:
                throw new NotImplementedException();
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static void WriteWriteForArray(Writer s, Definition d, DataTypeArray array, string prefix)
    {
        s.Body($"foreach (var v in {prefix}{d.MemberName()})", s =>
        {
            switch (array.InnerType)
            {
                case ArrayTypeCstring:
                    s.Wln("await WriteUtils.WriteCString(w, v, cancellationToken).ConfigureAwait(false);");
                    break;
                case ArrayTypeGuid:
                    s.Wln("await WriteUtils.WriteULong(w, v, cancellationToken).ConfigureAwait(false);");
                    break;
                case ArrayTypeInteger it:
                    s.Wln(
                        $"await WriteUtils.{it.IntegerType.WriteFunction()}(w, v, cancellationToken).ConfigureAwait(false);");
                    break;
                case ArrayTypeSpell:
                    s.Wln("await WriteUtils.WriteUInt(w, v, cancellationToken).ConfigureAwait(false);");
                    break;
                case ArrayTypeStruct:
                    s.Wln("await v.WriteAsync(w, cancellationToken).ConfigureAwait(false);");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        });
    }
}