// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class ObjectTypeSmsg : ObjectType
    {
        [JsonPropertyName("container_type_tag")]
        public string ContainerTypeTag { get => "SMsg"; }

        [JsonPropertyName("opcode")]
        public ushort Opcode { get; init; }
    }
}