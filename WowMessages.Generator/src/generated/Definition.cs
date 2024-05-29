// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class Definition
    {
        [JsonPropertyName("constant_value")]
        public Value? ConstantValue { get; init; }

        [JsonPropertyName("data_type")]
        public DataType DataType { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("size_of_fields_before_size")]
        public byte? SizeOfFieldsBeforeSize { get; init; }

        [JsonPropertyName("tags")]
        public MemberTags Tags { get; init; }

        [JsonPropertyName("used_as_size_in")]
        public string UsedAsSizeIn { get; init; }

        [JsonPropertyName("used_in_if")]
        public bool UsedInIf { get; init; }
    }
}