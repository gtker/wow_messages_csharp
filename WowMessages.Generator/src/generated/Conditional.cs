// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class Conditional
    {
        [JsonPropertyName("equations")]
        public ConditionalEquations Equations { get; init; }

        [JsonPropertyName("variable_name")]
        public string VariableName { get; init; }
    }
}