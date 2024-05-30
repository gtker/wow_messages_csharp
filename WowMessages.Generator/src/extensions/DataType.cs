using WowMessages.Generator.Generated;

namespace WowMessages.Generator.Extensions;

public static class DataTypeExtension
{
    public static IntegerType EnumOrFlagIntegerType(this DataType d) => d switch
    {
        DataTypeEnum dataTypeEnum => dataTypeEnum.IntegerType,
        DataTypeFlag dataTypeFlag => dataTypeFlag.IntegerType,
        _ => throw new ArgumentOutOfRangeException(nameof(d))
    };

    public static string CsType(this DataType d) => d switch
    {
        DataTypeInteger i => i.IntegerType.CsType(),
        DataTypeEnum e => e.TypeName,
        DataTypeFlag e => e.TypeName,
        DataTypeBool => "bool",
        DataTypeLevel => "byte",
        DataTypeLevel16 => "ushort",
        DataTypeLevel32 => "uint",
        DataTypeSpell16 => "ushort",
        DataTypeSpell => "uint",
        DataTypeDateTime => "uint",
        DataTypeItem => "uint",
        DataTypeMilliseconds => "uint",
        DataTypeCstring => "string",
        DataTypeString => "string",
        DataTypeGold => "uint",
        DataTypeGuid or DataTypePackedGuid => "ulong",
        DataTypeIpAddress => "uint",
        DataTypeSeconds => "uint",
        DataTypeSizedCstring => "string",
        DataTypeFloatingPoint => "float",
        DataTypeStruct s => s.StructData.Name,
        DataTypePopulation => "Population",
        DataTypeArray array => array.CsType(),

        DataTypeAchievementDoneArray dataTypeAchievementDoneArray => throw new NotImplementedException(),
        DataTypeAchievementInProgressArray dataTypeAchievementInProgressArray => throw new NotImplementedException(),
        DataTypeAddonArray dataTypeAddonArray => throw new NotImplementedException(),
        DataTypeAuraMask dataTypeAuraMask => throw new NotImplementedException(),
        DataTypeCacheMask dataTypeCacheMask => throw new NotImplementedException(),
        DataTypeEnchantMask dataTypeEnchantMask => throw new NotImplementedException(),
        DataTypeInspectTalentGearMask dataTypeInspectTalentGearMask => throw new NotImplementedException(),
        DataTypeMonsterMoveSpline dataTypeMonsterMoveSpline => throw new NotImplementedException(),
        DataTypeNamedGuid dataTypeNamedGuid => throw new NotImplementedException(),
        DataTypeUpdateMask dataTypeUpdateMask => throw new NotImplementedException(),
        DataTypeVariableItemRandomProperty dataTypeVariableItemRandomProperty => throw new NotImplementedException(),
        _ => throw new ArgumentOutOfRangeException(nameof(d))
    };
}