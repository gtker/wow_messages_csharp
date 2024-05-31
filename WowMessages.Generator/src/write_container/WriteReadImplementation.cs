using WowMessages.Generator.Extensions;
using WowMessages.Generator.Generated;

namespace WowMessages.Generator.write_container;

public static class WriteReadImplementation
{
    public static void WriteRead(Writer s, Container e, string module, string functionName)
    {
        s.Body(
            $"public static async Task<{e.Name}> Read{functionName}Async(Stream r, CancellationToken cancellationToken = default)",
            s =>
            {
                foreach (var member in e.Members)
                {
                    WriteReadMember(s, e, member, module, true);
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

    private static void WriteReadMember(Writer s, Container e, StructMember member, string module, bool declareTypes)
    {
        switch (member)
        {
            case StructMemberDefinition definition:
            {
                var d = definition.StructMemberContent;

                WriteReadForType(s, d);
                break;
            }
            case StructMemberIfStatement statement:
                WriteContainers.WriteIfStatement(s, e, statement.StructMemberContent, module,
                    (s, e, member, _) => { WriteReadMember(s, e, member, module, false); },
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

    private static void WriteReadForType(Writer s, Definition d)
    {
        if (d.IsNotInType())
        {
            s.Wln("// ReSharper disable once UnusedVariable.Compiler");
        }

        switch (d.DataType)
        {
            case DataTypeInteger i:
                s.Wln(
                    $"var {d.VariableName()} = await ReadUtils.{i.IntegerType.ReadFunction()}(r, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeEnum dataTypeEnum:
                var prefix = d.UsedInIf ? $"{d.CsTypeName()}Type" : "var";

                s.Wln(
                    $"{prefix} {d.VariableName()} = ({dataTypeEnum.CsType()})await ReadUtils.{dataTypeEnum.IntegerType.ReadFunction()}(r, cancellationToken).ConfigureAwait(false);");
                break;
            case DataTypeFlag dataTypeFlag:
                var read =
                    $"({dataTypeFlag.CsType()})await ReadUtils.{dataTypeFlag.IntegerType.ReadFunction()}(r, cancellationToken).ConfigureAwait(false)";
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
                s.Wln(
                    $"var {d.VariableName()} = await {d.CsTypeName()}.ReadAsync(r, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeSpell or DataTypeIpAddress or DataTypeItem or DataTypeLevel32 or DataTypeSeconds
                or DataTypeMilliseconds or DataTypeGold or DataTypeDateTime:
            {
                s.Wln(
                    $"var {d.VariableName()} = await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false);");
            }
                break;
            case DataTypeSpell16 or DataTypeLevel16:
            {
                s.Wln(
                    $"var {d.VariableName()} = await ReadUtils.ReadUShort(r, cancellationToken).ConfigureAwait(false);");
            }
                break;
            case DataTypeLevel:
                s.Wln(
                    $"var {d.VariableName()} = await ReadUtils.ReadByte(r, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeGuid:
                s.Wln(
                    $"var {d.VariableName()} = await ReadUtils.ReadULong(r, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeString:
                s.Wln(
                    $"var {d.VariableName()} = await ReadUtils.ReadString(r, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypePopulation:
                s.Wln(
                    $"var {d.VariableName()} = await ReadUtils.ReadPopulation(r, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeFloatingPoint:
                s.Wln(
                    $"var {d.VariableName()} = await ReadUtils.ReadFloat(r, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeBool b:
                s.Wln(
                    $"var {d.VariableName()} = await ReadUtils.ReadBool{b.IntegerType.SizeBits()}(r, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeCstring:
                s.Wln(
                    $"var {d.VariableName()} = await ReadUtils.ReadCString(r, cancellationToken).ConfigureAwait(false);");
                break;

            case DataTypeArray array:
                WriteReadForArray(s, d, array);
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

    private static void WriteReadForArray(Writer s, Definition d, DataTypeArray array)
    {
        s.Wln($"var {d.VariableName()} = new List<{array.InnerType.CsType()}>();");

        var loopHeader = array.Size switch
        {
            ArraySizeFixed v => $"for (var i = 0; i < {v.Size.ToCamelCase()}; ++i)",
            ArraySizeVariable v => $"for (var i = 0; i < {v.Size.ToCamelCase()}; ++i)",
            ArraySizeEndless v => throw new NotImplementedException(),
            _ => throw new ArgumentOutOfRangeException()
        };

        s.Body(loopHeader, s =>
        {
            switch (array.InnerType)
            {
                case ArrayTypeCstring:
                    s.Wln(
                        $"{d.VariableName()}.Add(await ReadUtils.ReadCString(r, cancellationToken).ConfigureAwait(false));");
                    break;
                case ArrayTypeGuid:
                    s.Wln(
                        $"{d.VariableName()}.Add(await ReadUtils.ReadULong(r, cancellationToken).ConfigureAwait(false));");
                    break;
                case ArrayTypeInteger it:
                    s.Wln(
                        $"{d.VariableName()}.Add(await ReadUtils.{it.IntegerType.ReadFunction()}(r, cancellationToken).ConfigureAwait(false));");
                    break;
                case ArrayTypeSpell:
                    s.Wln(
                        $"{d.VariableName()}.Add(await ReadUtils.ReadUInt(r, cancellationToken).ConfigureAwait(false));");
                    break;
                case ArrayTypeStruct e:
                    s.Wln(
                        $"{d.VariableName()}.Add(await {e.StructData.Name}.ReadAsync(r, cancellationToken).ConfigureAwait(false));");
                    break;
                case ArrayTypePackedGuid:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        });
    }
}