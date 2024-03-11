// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Gtker.WowMessages.Generator.Generated
{
    [JsonConverter(typeof(DataTypeJsonConverter))]
    public abstract class DataType
    {
    }

    public class DataTypeJsonConverter : JsonConverter<DataType>
    {
        public override DataType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerCopy = reader;
            var tagValue = JsonDocument.ParseValue(ref reader).RootElement.GetProperty("data_type_tag").GetString();

            switch (tagValue)
            {
                case "AchievementDoneArray":
                    return JsonSerializer.Deserialize<DataTypeAchievementDoneArray>(ref readerCopy, options);
                case "AchievementInProgressArray":
                    return JsonSerializer.Deserialize<DataTypeAchievementInProgressArray>(ref readerCopy, options);
                case "AddonArray":
                    return JsonSerializer.Deserialize<DataTypeAddonArray>(ref readerCopy, options);
                case "Array":
                    return JsonSerializer.Deserialize<DataTypeArray>(ref readerCopy, options);
                case "AuraMask":
                    return JsonSerializer.Deserialize<DataTypeAuraMask>(ref readerCopy, options);
                case "Bool":
                    return JsonSerializer.Deserialize<DataTypeBool>(ref readerCopy, options);
                case "CString":
                    return JsonSerializer.Deserialize<DataTypeCstring>(ref readerCopy, options);
                case "CacheMask":
                    return JsonSerializer.Deserialize<DataTypeCacheMask>(ref readerCopy, options);
                case "DateTime":
                    return JsonSerializer.Deserialize<DataTypeDateTime>(ref readerCopy, options);
                case "EnchantMask":
                    return JsonSerializer.Deserialize<DataTypeEnchantMask>(ref readerCopy, options);
                case "Enum":
                    return JsonSerializer.Deserialize<DataTypeEnum>(ref readerCopy, options);
                case "Flag":
                    return JsonSerializer.Deserialize<DataTypeFlag>(ref readerCopy, options);
                case "FloatingPoint":
                    return JsonSerializer.Deserialize<DataTypeFloatingPoint>(ref readerCopy, options);
                case "Gold":
                    return JsonSerializer.Deserialize<DataTypeGold>(ref readerCopy, options);
                case "Guid":
                    return JsonSerializer.Deserialize<DataTypeGuid>(ref readerCopy, options);
                case "InspectTalentGearMask":
                    return JsonSerializer.Deserialize<DataTypeInspectTalentGearMask>(ref readerCopy, options);
                case "Integer":
                    return JsonSerializer.Deserialize<DataTypeInteger>(ref readerCopy, options);
                case "IpAddress":
                    return JsonSerializer.Deserialize<DataTypeIpAddress>(ref readerCopy, options);
                case "Item":
                    return JsonSerializer.Deserialize<DataTypeItem>(ref readerCopy, options);
                case "Level":
                    return JsonSerializer.Deserialize<DataTypeLevel>(ref readerCopy, options);
                case "Level16":
                    return JsonSerializer.Deserialize<DataTypeLevel16>(ref readerCopy, options);
                case "Level32":
                    return JsonSerializer.Deserialize<DataTypeLevel32>(ref readerCopy, options);
                case "Milliseconds":
                    return JsonSerializer.Deserialize<DataTypeMilliseconds>(ref readerCopy, options);
                case "MonsterMoveSpline":
                    return JsonSerializer.Deserialize<DataTypeMonsterMoveSpline>(ref readerCopy, options);
                case "NamedGuid":
                    return JsonSerializer.Deserialize<DataTypeNamedGuid>(ref readerCopy, options);
                case "PackedGuid":
                    return JsonSerializer.Deserialize<DataTypePackedGuid>(ref readerCopy, options);
                case "Population":
                    return JsonSerializer.Deserialize<DataTypePopulation>(ref readerCopy, options);
                case "Seconds":
                    return JsonSerializer.Deserialize<DataTypeSeconds>(ref readerCopy, options);
                case "SizedCString":
                    return JsonSerializer.Deserialize<DataTypeSizedCstring>(ref readerCopy, options);
                case "Spell":
                    return JsonSerializer.Deserialize<DataTypeSpell>(ref readerCopy, options);
                case "Spell16":
                    return JsonSerializer.Deserialize<DataTypeSpell16>(ref readerCopy, options);
                case "String":
                    return JsonSerializer.Deserialize<DataTypeString>(ref readerCopy, options);
                case "Struct":
                    return JsonSerializer.Deserialize<DataTypeStruct>(ref readerCopy, options);
                case "UpdateMask":
                    return JsonSerializer.Deserialize<DataTypeUpdateMask>(ref readerCopy, options);
                case "VariableItemRandomProperty":
                    return JsonSerializer.Deserialize<DataTypeVariableItemRandomProperty>(ref readerCopy, options);
                default:
                    throw new ArgumentException(String.Format("Bad DataTypeTag value: {0}", tagValue));
            }
        }

        public override void Write(Utf8JsonWriter writer, DataType value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
