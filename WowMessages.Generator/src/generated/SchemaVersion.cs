// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class SchemaVersion
    {
        [JsonPropertyName("major")]
        public uint Major { get; set; }

        [JsonPropertyName("minor")]
        public uint Minor { get; set; }

        [JsonPropertyName("patch")]
        public uint Patch { get; set; }
    }
}
