// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    [JsonConverter(typeof(IfStatementDefinerTypeJsonConverter))]
    public enum IfStatementDefinerType
    {
        Enum_,

        Flag,
    }
    public class IfStatementDefinerTypeJsonConverter : JsonConverter<IfStatementDefinerType>
    {
        public override IfStatementDefinerType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string value = JsonSerializer.Deserialize<string>(ref reader, options);
            switch (value)
            {
                case "Enum":
                    return IfStatementDefinerType.Enum_;
                case "Flag":
                    return IfStatementDefinerType.Flag;
                default:
                    throw new ArgumentException(String.Format("Bad IfStatementDefinerType value: {0}", value));
            }
        }

        public override void Write(Utf8JsonWriter writer, IfStatementDefinerType value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case IfStatementDefinerType.Enum_:
                    JsonSerializer.Serialize<string>(writer, "Enum", options);
                    return;
                case IfStatementDefinerType.Flag:
                    JsonSerializer.Serialize<string>(writer, "Flag", options);
                    return;
            }
        }
    }
}