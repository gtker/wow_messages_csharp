// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace Generator.Generated
{
    public class ArrayTypeInteger : ArrayType
    {
        [JsonPropertyName("array_type_tag")]
        public string ArrayTypeTag { get => "Integer"; }

        [JsonPropertyName("integer_type")]
        public IntegerType IntegerType { get; set; }
    }
}
