// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class UpdateMaskDataTypeBytes : UpdateMaskDataType
    {
        [JsonPropertyName("update_mask_type_tag")]
        public string UpdateMaskTypeTag { get => "Bytes"; }

        [JsonPropertyName("content")]
        public UpdateMaskDataTypeBytesContent Content { get; set; }
    }
}
