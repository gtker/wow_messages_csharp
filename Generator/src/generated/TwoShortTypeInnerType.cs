// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Generator.Generated
{
    [JsonConverter(typeof(TwoShortTypeInnerTypeJsonConverter))]
    public abstract class TwoShortTypeInnerType
    {
    }

    public class TwoShortTypeInnerTypeJsonConverter : JsonConverter<TwoShortTypeInnerType>
    {
        public override TwoShortTypeInnerType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerCopy = reader;
            var tagValue = JsonDocument.ParseValue(ref reader).RootElement.GetProperty("two_short_type_tag").GetString();

            switch (tagValue)
            {
                case "Definer":
                    return JsonSerializer.Deserialize<TwoShortTypeInnerTypeDefiner>(ref readerCopy, options);
                case "Short":
                    return JsonSerializer.Deserialize<TwoShortTypeInnerTypeShort>(ref readerCopy, options);
                default:
                    throw new ArgumentException(String.Format("Bad TwoShortTypeTag value: {0}", tagValue));
            }
        }

        public override void Write(Utf8JsonWriter writer, TwoShortTypeInnerType value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
