using Gtker.WowMessages.Generator.Extensions;
using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.write_container;

public static class WriteReadImplementation
{
    public static void WriteRead(Writer s, Container e)
    {
        s.Body($"public static async Task<{e.Name}> ReadAsync(Stream r, CancellationToken cancellationToken = default)",
            s =>
            {
                var hasDefaultedMembers = false;

                foreach (var member in e.Members)
                {
                    switch (member)
                    {
                        case StructMemberDefinition structMemberDefinition:
                            break;
                        case StructMemberIfStatement statement:
                            hasDefaultedMembers = true;
                            foreach (var d in statement.AllDefinitions())
                            {
                                s.Wln($"var {d.VariableName()} = default({d.CsTypeName()});");
                            }

                            break;
                        case StructMemberOptional optional:
                            hasDefaultedMembers = true;
                            foreach (var d in optional.AllDefinitions())
                            {
                                s.Wln($"var {d.VariableName()} = default({d.CsTypeName()});");
                            }

                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(member));
                    }
                }

                if (hasDefaultedMembers)
                {
                    s.Newline();
                }

                foreach (var member in e.Members)
                {
                    WriteReadMember(s, e, member, true);
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
                            case StructMemberIfStatement statement:
                                foreach (var d in statement.AllDefinitions())
                                {
                                    if (d.IsNotInType())
                                    {
                                        continue;
                                    }

                                    s.Wln($"{d.MemberName()} = {d.VariableName()},");
                                }

                                break;
                            case StructMemberOptional optional:
                                foreach (var d in optional.AllDefinitions())
                                {
                                    if (d.IsNotInType())
                                    {
                                        continue;
                                    }

                                    s.Wln($"{d.MemberName()} = {d.VariableName()},");
                                }

                                break;
                            default:
                                throw new ArgumentOutOfRangeException(nameof(member));
                        }
                    }
                }, ";");
            });
    }

    private static void WriteReadMember(Writer s, Container e, StructMember member, bool declareTypes)
    {
        switch (member)
        {
            case StructMemberDefinition definition:
            {
                var d = definition.StructMemberContent;

                WriteReadForType(s, d, declareTypes);
                break;
            }
            case StructMemberIfStatement statement:
                WriteContainers.WriteIfStatement(s, e, statement.StructMemberContent,
                    (s, e, member) => { WriteReadMember(s, e, member, false); }, false);
                break;
            case StructMemberOptional:
                throw new NotImplementedException();
            default:
                throw new ArgumentOutOfRangeException(nameof(member));
        }
    }

    private static void WriteReadForType(Writer s, Definition d, bool declareTypes)
    {
        if (d.IsNotInType())
        {
            s.Wln("// ReSharper disable once UnusedVariable.Compiler");
        }

        var declare = declareTypes ? "var " : "";

        switch (d.DataType)
        {
            case DataTypeInteger i:
                s.Wln(
                    $"{declare}{d.VariableName()} = await ReadUtils.{i.Content.ReadFunction()}(r, cancellationToken);");
                break;

            case DataTypeEnum dataTypeEnum:
                s.Wln(
                    $"{declare}{d.VariableName()} = ({dataTypeEnum.CsType()})await ReadUtils.{dataTypeEnum.Content.IntegerType.ReadFunction()}(r, cancellationToken);");
                break;
            case DataTypeFlag dataTypeFlag:
                s.Wln(
                    $"{declare}{d.VariableName()} = ({dataTypeFlag.CsType()})await ReadUtils.{dataTypeFlag.Content.IntegerType.ReadFunction()}(r, cancellationToken);");
                break;
            case DataTypeStruct:
                s.Wln($"{declare}{d.VariableName()} = await {d.CsTypeName()}.ReadAsync(r, cancellationToken);");
                break;

            case DataTypeSpell or DataTypeIpAddress or DataTypeItem or DataTypeLevel32 or DataTypeSeconds
                or DataTypeMilliseconds or DataTypeGold or DataTypeDateTime:
            {
                s.Wln($"{declare}{d.VariableName()} = await ReadUtils.ReadUInt(r, cancellationToken);");
            }
                break;
            case DataTypeSpell16 or DataTypeLevel16:
            {
                s.Wln($"{declare}{d.VariableName()} = await ReadUtils.ReadUShort(r, cancellationToken);");
            }
                break;
            case DataTypeLevel:
                s.Wln($"{declare}{d.VariableName()} = await ReadUtils.ReadByte(r, cancellationToken);");
                break;

            case DataTypeGuid:
                s.Wln($"{declare}{d.VariableName()} = await ReadUtils.ReadULong(r, cancellationToken);");
                break;

            case DataTypeString:
                s.Wln($"{declare}{d.VariableName()} = await ReadUtils.ReadString(r, cancellationToken);");
                break;

            case DataTypePopulation:
                s.Wln($"{declare}{d.VariableName()} = await ReadUtils.ReadPopulation(r, cancellationToken);");
                break;

            case DataTypeFloatingPoint:
                s.Wln($"{declare}{d.VariableName()} = await ReadUtils.ReadFloat(r, cancellationToken);");
                break;

            case DataTypeBool b:
                s.Wln(
                    $"{declare}{d.VariableName()} = await ReadUtils.ReadBool{b.Content.SizeBits()}(r, cancellationToken);");
                break;

            case DataTypeCstring:
                s.Wln($"{declare}{d.VariableName()} = await ReadUtils.ReadCString(r, cancellationToken);");
                break;

            case DataTypeArray array:
                WriteReadForArray(s, d, array, declare);
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

        s.Newline();
    }

    private static void WriteReadForArray(Writer s, Definition d, DataTypeArray array, string declare)
    {
        s.Wln($"{declare}{d.VariableName()} = new List<{array.Content.InnerType.CsType()}>();");

        var loopHeader = array.Content.Size switch
        {
            ArraySizeFixed v => $"for (var i = 0; i < {v.Size.ToCamelCase()}; ++i)",
            ArraySizeVariable v => $"for (var i = 0; i < {v.Size.ToCamelCase()}; ++i)",
            ArraySizeEndless v => throw new NotImplementedException(),
            _ => throw new ArgumentOutOfRangeException()
        };

        s.Body(loopHeader, s =>
        {
            switch (array.Content.InnerType)
            {
                case ArrayTypeCstring:
                    s.Wln($"{d.VariableName()}.Add(await ReadUtils.ReadCString(r, cancellationToken));");
                    break;
                case ArrayTypeGuid:
                    s.Wln($"{d.VariableName()}.Add(await ReadUtils.ReadULong(r, cancellationToken));");
                    break;
                case ArrayTypeInteger it:
                    s.Wln(
                        $"{d.VariableName()}.Add(await ReadUtils.{it.Content.ReadFunction()}(r, cancellationToken));");
                    break;
                case ArrayTypeSpell:
                    s.Wln($"{d.VariableName()}.Add(await ReadUtils.ReadUInt(r, cancellationToken));");
                    break;
                case ArrayTypeStruct e:
                    s.Wln(
                        $"{d.VariableName()}.Add(await {e.Content.StructData.Name}.ReadAsync(r, cancellationToken));");
                    break;
                case ArrayTypePackedGuid:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        });
    }
}