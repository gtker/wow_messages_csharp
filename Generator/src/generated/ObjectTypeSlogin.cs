// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace Generator.Generated
{
    public class ObjectTypeSlogin : ObjectType
    {
        [JsonPropertyName("container_type_tag")]
        public string ContainerTypeTag { get => "SLogin"; }

        [JsonPropertyName("opcode")]
        public ushort Opcode { get; set; }
    }
}
