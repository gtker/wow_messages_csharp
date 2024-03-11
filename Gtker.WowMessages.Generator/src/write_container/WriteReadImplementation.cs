using Gtker.WowMessages.Generator.Extensions;
using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.write_container;

public static class WriteReadImplementation
{
    public static void WriteRead(Writer s, Container e)
    {
        s.Body($"public static async Task<{e.Name}> Read(Stream r)", s =>
        {
            foreach (var member in e.Members)
            {
                switch (member)
                {
                    case StructMemberDefinition definition:
                    {
                        var d = definition.StructMemberContent;

                        WriteReadForType(s, d);
                        break;
                    }
                    case StructMemberIfStatement:
                        throw new NotImplementedException();
                    case StructMemberOptional:
                        throw new NotImplementedException();
                    default:
                        throw new ArgumentOutOfRangeException(nameof(member));
                }
            }

            s.Body($"return new {e.Name}", s =>
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

                            s.Wln($"{d.MemberName()} = {d.VariableName()},");

                            break;
                        }
                        case StructMemberIfStatement:
                            throw new NotImplementedException();
                        case StructMemberOptional:
                            throw new NotImplementedException();
                        default:
                            throw new ArgumentOutOfRangeException(nameof(member));
                    }
                }
            }, ";");
        });
    }

    private static void WriteReadForType(Writer s, Definition d)
    {
        if (d.IsNotInType())
        {
            s.Wln("// ReSharper disable once UnusedVariable.Compiler");
        }

        switch (d.DataType)
        {
            case DataTypeInteger i:
                s.Wln($"var {d.VariableName()} = await ReadUtils.{i.Content.ReadFunction()}(r);");
                break;

            case DataTypeEnum dataTypeEnum:
                s.Wln(
                    $"var {d.VariableName()} = ({dataTypeEnum.CsType()})await ReadUtils.{dataTypeEnum.Content.IntegerType.ReadFunction()}(r);");
                break;
            case DataTypeFlag dataTypeFlag:
                s.Wln(
                    $"var {d.VariableName()} = ({dataTypeFlag.CsType()})await ReadUtils.{dataTypeFlag.Content.IntegerType.ReadFunction()}(r);");
                break;
            case DataTypeStruct:
                s.Wln($"var {d.VariableName()} = await {d.CsTypeName()}.Read(r);");
                break;

            case DataTypeSpell or DataTypeIpAddress or DataTypeItem or DataTypeLevel32 or DataTypeSeconds
                or DataTypeMilliseconds or DataTypeGold or DataTypeDateTime:
            {
                s.Wln($"var {d.VariableName()} = await ReadUtils.ReadUInt(r);");
            }
                break;
            case DataTypeSpell16 or DataTypeLevel16:
            {
                s.Wln($"var {d.VariableName()} = await ReadUtils.ReadUShort(r);");
            }
                break;
            case DataTypeLevel:
                s.Wln($"var {d.VariableName()} = await ReadUtils.ReadByte(r);");
                break;

            case DataTypeGuid:
                s.Wln($"var {d.VariableName()} = await ReadUtils.ReadULong(r);");
                break;

            case DataTypeString:
                s.Wln($"var {d.VariableName()} = await ReadUtils.ReadString(r);");
                break;

            case DataTypePopulation:
                s.Wln($"var {d.VariableName()} = await ReadUtils.ReadPopulation(r);");
                break;

            case DataTypeFloatingPoint:
                s.Wln($"var {d.VariableName()} = await ReadUtils.ReadFloat(r);");
                break;

            case DataTypeBool b:
                s.Wln($"var {d.VariableName()} = await ReadUtils.ReadBool{b.Content.SizeBits()}(r);");
                break;

            case DataTypeCstring:
                s.Wln($"var {d.VariableName()} = await ReadUtils.ReadCString(r);");
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

        s.Newline();
    }
}