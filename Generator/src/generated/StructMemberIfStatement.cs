// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace Generator.Generated
{
    public class StructMemberIfStatement : StructMember
    {
        [JsonPropertyName("struct_member_tag")]
        public string StructMemberTag { get => "IfStatement"; }

        [JsonPropertyName("struct_member_content")]
        public IfStatement StructMemberContent { get; set; }
    }
}
