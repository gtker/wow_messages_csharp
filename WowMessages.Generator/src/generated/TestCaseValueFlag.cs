// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class TestCaseValueFlag : TestCaseValue
    {
        [JsonPropertyName("test_value_tag")]
        public string TestValueTag { get => "Flag"; }

        [JsonPropertyName("content")]
        public IList<string> Content { get; set; }
    }
}
