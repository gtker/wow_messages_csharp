// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class WorldVersion
    {
        [JsonPropertyName("build")]
        public ushort? Build { get; init; }

        [JsonPropertyName("major")]
        public byte Major { get; init; }

        [JsonPropertyName("minor")]
        public byte? Minor { get; init; }

        [JsonPropertyName("patch")]
        public byte? Patch { get; init; }
    }
}