// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class TestCaseValueSubObject : TestCaseValue
    {
        [JsonPropertyName("test_value_tag")]
        public string TestValueTag { get => "SubObject"; }

        [JsonPropertyName("content")]
        public TestCaseValueSubObjectContent Content { get; set; }
    }
}
