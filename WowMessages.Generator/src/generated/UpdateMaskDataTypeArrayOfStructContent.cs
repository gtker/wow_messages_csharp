// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class UpdateMaskDataTypeArrayOfStructContent
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("update_mask_struct")]
        public UpdateMaskStruct UpdateMaskStruct { get; set; }

        [JsonPropertyName("variable_name")]
        public string VariableName { get; set; }
    }
}
