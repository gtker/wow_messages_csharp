// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class UpdateMaskStructMember
    {
        [JsonPropertyName("member")]
        public Definition Member { get; init; }

        [JsonPropertyName("offset")]
        public int Offset { get; init; }

        [JsonPropertyName("size")]
        public int Size { get; init; }
    }
}