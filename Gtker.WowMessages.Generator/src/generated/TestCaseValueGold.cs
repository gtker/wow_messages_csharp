// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace Gtker.WowMessages.Generator.Generated
{
    public class TestCaseValueGold : TestCaseValue
    {
        [JsonPropertyName("test_value_tag")]
        public string TestValueTag { get => "Gold"; }

        [JsonPropertyName("content")]
        public Value Content { get; init; }
    }
}
