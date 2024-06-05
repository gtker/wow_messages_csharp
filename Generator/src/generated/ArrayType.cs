// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Generator.Generated
{
    [JsonConverter(typeof(ArrayTypeJsonConverter))]
    public abstract class ArrayType
    {
    }

    public class ArrayTypeJsonConverter : JsonConverter<ArrayType>
    {
        public override ArrayType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerCopy = reader;
            var tagValue = JsonDocument.ParseValue(ref reader).RootElement.GetProperty("array_type_tag").GetString();

            switch (tagValue)
            {
                case "CString":
                    return JsonSerializer.Deserialize<ArrayTypeCstring>(ref readerCopy, options);
                case "Guid":
                    return JsonSerializer.Deserialize<ArrayTypeGuid>(ref readerCopy, options);
                case "Integer":
                    return JsonSerializer.Deserialize<ArrayTypeInteger>(ref readerCopy, options);
                case "PackedGuid":
                    return JsonSerializer.Deserialize<ArrayTypePackedGuid>(ref readerCopy, options);
                case "Spell":
                    return JsonSerializer.Deserialize<ArrayTypeSpell>(ref readerCopy, options);
                case "Struct":
                    return JsonSerializer.Deserialize<ArrayTypeStruct>(ref readerCopy, options);
                default:
                    throw new ArgumentException(String.Format("Bad ArrayTypeTag value: {0}", tagValue));
            }
        }

        public override void Write(Utf8JsonWriter writer, ArrayType value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}