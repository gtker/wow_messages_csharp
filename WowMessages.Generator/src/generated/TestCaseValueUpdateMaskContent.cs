// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class TestCaseValueUpdateMaskContent
    {
        [JsonPropertyName("update_mask_name")]
        public string UpdateMaskName { get; init; }

        [JsonPropertyName("update_mask_type")]
        public TestCaseValueUpdateMaskContentUpdateMaskType UpdateMaskType { get; init; }

        [JsonPropertyName("update_mask_value")]
        public string UpdateMaskValue { get; init; }
    }
}
