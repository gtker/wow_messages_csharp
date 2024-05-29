// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class DataTypeArray : DataType
    {
        [JsonPropertyName("data_type_tag")]
        public string DataTypeTag { get => "Array"; }

        [JsonPropertyName("compressed")]
        public bool Compressed { get; init; }

        [JsonPropertyName("inner_type")]
        public ArrayType InnerType { get; init; }

        [JsonPropertyName("size")]
        public ArraySize Size { get; init; }
    }
}