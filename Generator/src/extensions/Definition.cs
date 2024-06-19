using Generator.Generated;

namespace Generator.Extensions;

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

    public static string Size(this Definition d, string module, string prefix = "", bool isMember = true)
    {
        var name = isMember ? d.MemberName() : d.VariableName();
        return d.DataType switch
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

            DataTypeSizedCstring => $"{prefix}{name}.Length + 5",
            DataTypeString or DataTypeCstring => $"{prefix}{name}.Length + 1",

            DataTypeStruct s => s.StructData.Sizes.ConstantSized
                ? s.StructData.Sizes.MaximumSize.ToString()
                : $"{prefix}{name}.Size()",

            DataTypePackedGuid => $"{prefix}{name}.PackedGuidLength()",

            DataTypeNamedGuid => $"{prefix}{name}.Length()",
            DataTypeUpdateMask => $"{prefix}{name}.Length()",

            DataTypeMonsterMoveSpline => $"ReadUtils.MonsterMoveSplineLength({prefix}{name})",

            DataTypeAuraMask => $"{prefix}{name}.Length();",

            DataTypeArray array => array.ArraySize(d, name, prefix),

            DataTypeAchievementDoneArray dataTypeAchievementDoneArray => throw new NotImplementedException(),

            DataTypeAchievementInProgressArray dataTypeAchievementInProgressArray =>
                throw new NotImplementedException(),
            DataTypeAddonArray dataTypeAddonArray => throw new NotImplementedException(),
            DataTypeCacheMask dataTypeCacheMask => throw new NotImplementedException(),
            DataTypeEnchantMask dataTypeEnchantMask => throw new NotImplementedException(),
            DataTypeInspectTalentGearMask dataTypeInspectTalentGearMask => throw new NotImplementedException(),
            DataTypeVariableItemRandomProperty dataTypeVariableItemRandomProperty =>
                throw new NotImplementedException(),
            _ => throw new ArgumentOutOfRangeException(nameof(d))
        };
    }

    public static bool IsCompressed(this Definition d) => d.DataType switch
    {
        DataTypeArray dataTypeArray => dataTypeArray.Compressed,
        _ => false
    };

    public static bool IsEndlessArray(this Definition d) => d.DataType switch
    {
        DataTypeArray dataTypeArray => dataTypeArray.Size is ArraySizeEndless,
        _ => false
    };
}