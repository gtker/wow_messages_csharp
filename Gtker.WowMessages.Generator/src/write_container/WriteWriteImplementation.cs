using Gtker.WowMessages.Generator.Extensions;
using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.write_container;

public static class WriteWriteImplementation
{
    public static void WriteWrite(Writer s, Container e)
    {
        s.Body("public async Task WriteAsync(Stream w)", s =>
        {
            switch (e.ObjectType)
            {
                case ObjectTypeClogin objectTypeClogin:
                    s.Wln($"await WriteUtils.WriteByte(w, {objectTypeClogin.Opcode});");
                    s.Newline();
                    break;
                case ObjectTypeSlogin objectTypeSlogin:
                    s.Wln($"await WriteUtils.WriteByte(w, {objectTypeSlogin.Opcode});");
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
                switch (member)
                {
                    case StructMemberDefinition d:
                        WriteWriteForType(s, d.StructMemberContent);
                        s.Newline();
                        break;
                    case StructMemberIfStatement structMemberIfStatement:
                        throw new NotImplementedException();
                    case StructMemberOptional structMemberOptional:
                        throw new NotImplementedException();
                    default:
                        throw new ArgumentOutOfRangeException(nameof(member));
                }
            }
        });
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

        switch (d.DataType)
        {
            case DataTypeInteger i:
                s.Wln($"await WriteUtils.{i.Content.WriteFunction()}(w, {value});");
                break;

            case DataTypeEnum i:
                s.Wln(
                    $"await WriteUtils.{i.Content.IntegerType.WriteFunction()}(w, ({i.Content.IntegerType.CsType()}){value});");
                break;
            case DataTypeFlag i:
                s.Wln(
                    $"await WriteUtils.{i.Content.IntegerType.WriteFunction()}(w, ({i.Content.IntegerType.CsType()}){value});");
                break;
            case DataTypeStruct:
                s.Wln($"await {d.MemberName()}.WriteAsync(w);");
                break;

            case DataTypeSpell or DataTypeIpAddress or DataTypeItem or DataTypeLevel32 or DataTypeSeconds
                or DataTypeMilliseconds or DataTypeGold or DataTypeDateTime:
            {
                s.Wln($"await WriteUtils.WriteUInt(w, {value});");
            }
                break;
            case DataTypeSpell16 or DataTypeLevel16:
            {
                s.Wln($"await WriteUtils.WriteUShort(w, {value});");
            }
                break;
            case DataTypeLevel:
                s.Wln($"await WriteUtils.WriteByte(w, {value});");
                break;

            case DataTypeGuid:
                s.Wln($"await WriteUtils.WriteULong(w, {value});");
                break;

            case DataTypeString:
                s.Wln($"await WriteUtils.WriteString(w, {value});");
                break;

            case DataTypePopulation:
                s.Wln($"await WriteUtils.WritePopulation(w, {value});");
                break;

            case DataTypeFloatingPoint:
                s.Wln($"await WriteUtils.WriteFloat(w, {value});");
                break;

            case DataTypeBool b:
                s.Wln($"await WriteUtils.WriteBool{b.Content.SizeBits()}(w, {value});");
                break;

            case DataTypeCstring:
                s.Wln($"await WriteUtils.WriteCString(w, {value});");
                break;

            case DataTypeArray:
                throw new NotImplementedException();

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
}