// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class DataTypeBool : DataType
    {
        [JsonPropertyName("data_type_tag")]
        public string DataTypeTag { get => "Bool"; }

        [JsonPropertyName("integer_type")]
        public IntegerType IntegerType { get; set; }
    }
}
