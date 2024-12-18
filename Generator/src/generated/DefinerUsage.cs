// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Generator.Generated
{
    [JsonConverter(typeof(DefinerUsageJsonConverter))]
    public enum DefinerUsage
    {
        InIfStatement,

        RegularUse,
    }
    public class DefinerUsageJsonConverter : JsonConverter<DefinerUsage>
    {
        public override DefinerUsage Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string value = JsonSerializer.Deserialize<string>(ref reader, options);
            switch (value)
            {
                case "InIfStatement":
                    return DefinerUsage.InIfStatement;
                case "RegularUse":
                    return DefinerUsage.RegularUse;
                default:
                    throw new ArgumentException(String.Format("Bad DefinerUsage value: {0}", value));
            }
        }

        public override void Write(Utf8JsonWriter writer, DefinerUsage value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case DefinerUsage.InIfStatement:
                    JsonSerializer.Serialize<string>(writer, "InIfStatement", options);
                    return;
                case DefinerUsage.RegularUse:
                    JsonSerializer.Serialize<string>(writer, "RegularUse", options);
                    return;
            }
        }
    }
}
