// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class ConditionalEquationsNotEquals : ConditionalEquations
    {
        [JsonPropertyName("equation_tag")]
        public string EquationTag { get => "NotEquals"; }

        [JsonPropertyName("values")]
        public ConditionalEquationsNotEqualsValues Values { get; init; }
    }
}