// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class DataTypeFlagContent
    {
        [JsonPropertyName("integer_type")]
        public IntegerType IntegerType { get; init; }

        [JsonPropertyName("type_name")]
        public string TypeName { get; init; }

        [JsonPropertyName("upcast")]
        public bool Upcast { get; init; }
    }
}