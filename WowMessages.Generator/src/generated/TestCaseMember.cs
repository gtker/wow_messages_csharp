// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class TestCaseMember
    {
        [JsonPropertyName("tags")]
        public MemberTags Tags { get; init; }

        [JsonPropertyName("value")]
        public TestCaseValue Value { get; init; }

        [JsonPropertyName("variable_name")]
        public string VariableName { get; init; }
    }
}
