// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace Generator.Generated
{
    public class ObjectVersionsLogin : ObjectVersions
    {
        [JsonPropertyName("version_type_tag")]
        public string VersionTypeTag { get => "login"; }

        [JsonPropertyName("version_type")]
        public LoginVersions VersionType { get; set; }
    }
}