using Gtker.WowMessages.Generator.Extensions;
using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.write_container;

public static class WriteWriteImplementation
{
    public static void WriteWrite(Writer s, Container e)
    {
        s.Body("public async Task WriteAsync(Stream w, CancellationToken cancellationToken = default)", s =>
        {
            switch (e.ObjectType)
            {
                case ObjectTypeClogin objectTypeClogin:
                    s.Wln("// opcode: u8");
                    s.Wln($"await WriteUtils.WriteByte(w, {objectTypeClogin.Opcode}, cancellationToken);");
                    s.Newline();
                    break;
                case ObjectTypeSlogin objectTypeSlogin:
                    s.Wln("// opcode: u8");
                    s.Wln($"await WriteUtils.WriteByte(w, {objectTypeSlogin.Opcode}, cancellationToken);");
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
                WriteWriteMember(s, e, member);
            }
        });
    }

    private static void WriteWriteMember(Writer s, Container e, StructMember member)
    {
        switch (member)
        {
            case StructMemberDefinition d:
                WriteWriteForType(s, d.StructMemberContent);
                s.Newline();
                break;
            case StructMemberIfStatement statement:
                WriteContainers.WriteIfStatement(s, e, statement.StructMemberContent, WriteWriteMember, true);
                break;
            case StructMemberOptional structMemberOptional:
                throw new NotImplementedException();
            default:
                throw new ArgumentOutOfRangeException(nameof(member));
        }
    }

    private static void WriteWriteForType(Writer s, Definition d)
    {
        var value = d.MemberName();
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
            value = $"({d.DataType.CsType()}){v.ToPascalCase()}.Count";
        }

        switch (d.DataType)
        {
            case DataTypeInteger i:
                s.Wln($"await WriteUtils.{i.Content.WriteFunction()}(w, {value}, cancellationToken);");
                break;

            case DataTypeEnum i:
                s.Wln(
                    $"await WriteUtils.{i.Content.IntegerType.WriteFunction()}(w, ({i.Content.IntegerType.CsType()}){value}, cancellationToken);");
                break;
            case DataTypeFlag i:
                s.Wln(
                    $"await WriteUtils.{i.Content.IntegerType.WriteFunction()}(w, ({i.Content.IntegerType.CsType()}){value}, cancellationToken);");
                break;
            case DataTypeStruct:
                s.Wln($"await {d.MemberName()}.WriteAsync(w, cancellationToken);");
                break;

            case DataTypeSpell or DataTypeIpAddress or DataTypeItem or DataTypeLevel32 or DataTypeSeconds
                or DataTypeMilliseconds or DataTypeGold or DataTypeDateTime:
            {
                s.Wln($"await WriteUtils.WriteUInt(w, {value}, cancellationToken);");
            }
                break;
            case DataTypeSpell16 or DataTypeLevel16:
            {
                s.Wln($"await WriteUtils.WriteUShort(w, {value}, cancellationToken);");
            }
                break;
            case DataTypeLevel:
                s.Wln($"await WriteUtils.WriteByte(w, {value}, cancellationToken);");
                break;

            case DataTypeGuid:
                s.Wln($"await WriteUtils.WriteULong(w, {value}, cancellationToken);");
                break;

            case DataTypeString:
                s.Wln($"await WriteUtils.WriteString(w, {value}, cancellationToken);");
                break;

            case DataTypePopulation:
                s.Wln($"await WriteUtils.WritePopulation(w, {value}, cancellationToken);");
                break;

            case DataTypeFloatingPoint:
                s.Wln($"await WriteUtils.WriteFloat(w, {value}, cancellationToken);");
                break;

            case DataTypeBool b:
                s.Wln($"await WriteUtils.WriteBool{b.Content.SizeBits()}(w, {value}, cancellationToken);");
                break;

            case DataTypeCstring:
                s.Wln($"await WriteUtils.WriteCString(w, {value}, cancellationToken);");
                break;

            case DataTypeArray array:
                WriteWriteForArray(s, d, array);
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

    private static void WriteWriteForArray(Writer s, Definition d, DataTypeArray array)
    {
        s.Body($"foreach (var v in {d.MemberName()})", s =>
        {
            switch (array.Content.InnerType)
            {
                case ArrayTypeCstring:
                    s.Wln("await WriteUtils.WriteCString(w, v, cancellationToken);");
                    break;
                case ArrayTypeGuid:
                    s.Wln("await WriteUtils.WriteULong(w, v, cancellationToken);");
                    break;
                case ArrayTypeInteger it:
                    s.Wln($"await WriteUtils.{it.Content.WriteFunction()}(w, v, cancellationToken);");
                    break;
                case ArrayTypeSpell:
                    s.Wln("await WriteUtils.WriteUInt(w, v, cancellationToken);");
                    break;
                case ArrayTypeStruct:
                    s.Wln("await v.WriteAsync(w, cancellationToken);");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        });
    }
}