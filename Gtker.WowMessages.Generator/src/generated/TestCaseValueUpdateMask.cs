// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gtker.WowMessages.Generator.Generated
{
    public class TestCaseValueUpdateMask : TestCaseValue
    {
        [JsonPropertyName("test_value_tag")]
        public string TestValueTag { get => "UpdateMask"; }

        [JsonPropertyName("content")]
        public IList<TestCaseValueUpdateMaskContent> Content { get; init; }
    }
}
