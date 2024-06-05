// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace Generator.Generated
{
    public class DataTypeFlag : DataType
    {
        [JsonPropertyName("data_type_tag")]
        public string DataTypeTag { get => "Flag"; }

        [JsonPropertyName("integer_type")]
        public IntegerType IntegerType { get; set; }

        [JsonPropertyName("type_name")]
        public string TypeName { get; set; }

        [JsonPropertyName("upcast")]
        public bool Upcast { get; set; }
    }
}