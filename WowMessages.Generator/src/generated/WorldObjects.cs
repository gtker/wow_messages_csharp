// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class WorldObjects
    {
        [JsonPropertyName("enums")]
        public Enums Enums { get; init; }

        [JsonPropertyName("flags")]
        public Flags Flags { get; init; }

        [JsonPropertyName("messages")]
        public Messages Messages { get; init; }

        [JsonPropertyName("structs")]
        public Structs Structs { get; init; }
    }
}
