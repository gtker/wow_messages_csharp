using WowMessages.Generator.Generated;

namespace WowMessages.Generator.Extensions;

public static class DefinitionExtensions
{
    public static string VariableName(this Definition d) =>
        Utils.SnakeCaseToCamelCase(d.Name);

    public static string MemberName(this Definition d) =>
        Utils.SnakeCaseToPascalCase(d.Name);

    public static string CsTypeName(this Definition d) =>
        d.DataType.CsType();

    public static bool IsNotInType(this Definition d) =>
        d.ConstantValue is not null || d.SizeOfFieldsBeforeSize is not null || d.UsedAsSizeIn is not null;

    public static bool IsInType(this Definition d) => !IsNotInType(d);

    public static string PreparedObjectTypeName(this Definition d, string enumerator) =>
        $"{d.CsTypeName()}{enumerator.ToEnumerator()}";

    public static string Size(this Definition d) => d.DataType switch
    {
        DataTypeInteger i => i.IntegerType.SizeBytes().ToString(),
        DataTypeEnum e => e.IntegerType.SizeBytes().ToString(),
        DataTypeFlag e => e.IntegerType.SizeBytes().ToString(),
        DataTypeBool e => e.IntegerType.SizeBytes().ToString(),

        DataTypeGold => 4.ToString(),
        DataTypeGuid => 8.ToString(),
        DataTypeFloatingPoint => 4.ToString(),
        DataTypeDateTime => 4.ToString(),
        DataTypeIpAddress => 4.ToString(),
        DataTypeItem => 4.ToString(),
        DataTypeLevel => 1.ToString(),
        DataTypeLevel16 => 2.ToString(),
        DataTypeLevel32 => 4.ToString(),
        DataTypeMilliseconds => 4.ToString(),
        DataTypePopulation => 4.ToString(),
        DataTypeSeconds => 4.ToString(),
        DataTypeSpell => 4.ToString(),
        DataTypeSpell16 => 2.ToString(),

        DataTypeString or DataTypeCstring => $"{d.MemberName()}.Length + 1",

        DataTypeStruct s => s.StructData.Sizes.ConstantSized
            ? s.StructData.Sizes.MaximumSize.ToString()
            : $"{d.MemberName()}.Size()",

        DataTypeArray array => array.ArraySize(d),

        DataTypeAchievementDoneArray dataTypeAchievementDoneArray => throw new NotImplementedException(),

        DataTypeAchievementInProgressArray dataTypeAchievementInProgressArray => throw new NotImplementedException(),
        DataTypeAddonArray dataTypeAddonArray => throw new NotImplementedException(),
        DataTypeAuraMask dataTypeAuraMask => throw new NotImplementedException(),
        DataTypeCacheMask dataTypeCacheMask => throw new NotImplementedException(),
        DataTypeEnchantMask dataTypeEnchantMask => throw new NotImplementedException(),
        DataTypeInspectTalentGearMask dataTypeInspectTalentGearMask => throw new NotImplementedException(),
        DataTypeMonsterMoveSpline dataTypeMonsterMoveSpline => throw new NotImplementedException(),
        DataTypeNamedGuid dataTypeNamedGuid => throw new NotImplementedException(),
        DataTypePackedGuid dataTypePackedGuid => throw new NotImplementedException(),
        DataTypeSizedCstring dataTypeSizedCstring => throw new NotImplementedException(),
        DataTypeUpdateMask dataTypeUpdateMask => throw new NotImplementedException(),
        DataTypeVariableItemRandomProperty dataTypeVariableItemRandomProperty => throw new NotImplementedException(),
        _ => throw new ArgumentOutOfRangeException(nameof(d))
    };
}