// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class ObjectTags
    {
        [JsonPropertyName("version")]
        public ObjectVersions Version_ { get; init; }

        [JsonPropertyName("comment")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Comment { get; init; }

        [JsonPropertyName("compressed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Compressed { get; init; }

        [JsonPropertyName("non_network_type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? NonNetworkType { get; init; }

        [JsonPropertyName("unimplemented")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Unimplemented { get; init; }

        [JsonPropertyName("used_in_update_mask")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? UsedInUpdateMask { get; init; }
    }
}