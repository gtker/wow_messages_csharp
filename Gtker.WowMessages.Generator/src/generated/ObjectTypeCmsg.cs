// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace Gtker.WowMessages.Generator.Generated
{
    public class ObjectTypeCmsg : ObjectType
    {
        [JsonPropertyName("container_type_tag")]
        public string ContainerTypeTag { get => "CMsg"; }

        [JsonPropertyName("opcode")]
        public ushort Opcode { get; init; }
    }
}
