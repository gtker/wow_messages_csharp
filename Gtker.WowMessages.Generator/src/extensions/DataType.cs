using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.Extensions;

public static class DataTypeExtension
{
    public static string CsType(this DataType d) => d switch
    {
        DataTypeInteger i => i.Content.CsType(),
        DataTypeEnum e => e.Content.TypeName,
        DataTypeFlag e => e.Content.TypeName,
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
        DataTypeStruct s => s.Content.StructData.Name,
        DataTypePopulation => "Population",

        DataTypeAchievementDoneArray dataTypeAchievementDoneArray => throw new NotImplementedException(),
        DataTypeAchievementInProgressArray dataTypeAchievementInProgressArray => throw new NotImplementedException(),
        DataTypeAddonArray dataTypeAddonArray => throw new NotImplementedException(),
        DataTypeArray dataTypeArray => throw new NotImplementedException(),
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