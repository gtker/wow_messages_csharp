// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace Generator.Generated
{
    public class TestCaseValueBool : TestCaseValue
    {
        [JsonPropertyName("test_value_tag")]
        public string TestValueTag { get => "Bool"; }

        [JsonPropertyName("content")]
        public bool Content { get; set; }
    }
}
