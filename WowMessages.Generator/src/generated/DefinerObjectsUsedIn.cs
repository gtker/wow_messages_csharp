// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class DefinerObjectsUsedIn
    {
        [JsonPropertyName("definer_usage")]
        public DefinerUsage DefinerUsage { get; init; }

        [JsonPropertyName("object_name")]
        public string ObjectName { get; init; }
    }
}