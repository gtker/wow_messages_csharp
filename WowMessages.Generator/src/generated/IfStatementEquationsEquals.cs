// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class IfStatementEquationsEquals : IfStatementEquations
    {
        [JsonPropertyName("equation_tag")]
        public string EquationTag { get => "Equals"; }

        [JsonPropertyName("value")]
        public IList<string> Value { get; init; }
    }
}
