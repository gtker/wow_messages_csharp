using Generator.Generated;

namespace Generator.Extensions;

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
        DataTypeSizedCstring => "string",
        DataTypeCstring => "string",
        DataTypeString => "string",
        DataTypeGold => "uint",
        DataTypeGuid or DataTypePackedGuid => "ulong",
        DataTypeIpAddress => "uint",
        DataTypeSeconds => "uint",
        DataTypeFloatingPoint => "float",
        DataTypeStruct s => s.StructData.Name,
        DataTypePopulation => "Population",
        DataTypeArray array => array.CsType(),
        DataTypeNamedGuid => "NamedGuid",
        DataTypeUpdateMask => "UpdateMask",
        DataTypeMonsterMoveSpline => "List<Vector3d>",
        DataTypeAuraMask => "AuraMask",
        DataTypeAchievementDoneArray => "List<AchievementDone>",
        DataTypeAchievementInProgressArray => "List<AchievementInProgress>",

        // Wrath/Tbc
        DataTypeAddonArray dataTypeAddonArray => throw new NotImplementedException(),
        DataTypeVariableItemRandomProperty dataTypeVariableItemRandomProperty => throw new NotImplementedException(),
        DataTypeInspectTalentGearMask dataTypeInspectTalentGearMask => throw new NotImplementedException(),
        DataTypeEnchantMask dataTypeEnchantMask => throw new NotImplementedException(),
        DataTypeCacheMask dataTypeCacheMask => throw new NotImplementedException(),

        _ => throw new ArgumentOutOfRangeException(nameof(d))
    };
}