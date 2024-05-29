// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class ArraySizeFixed : ArraySize
    {
        [JsonPropertyName("array_size_tag")]
        public string ArraySizeTag { get => "Fixed"; }

        /// <summary>
        /// JSON Typedef does not support integers larger than unsigned 32 bit,
        /// so this is a string
        /// </summary>
        [JsonPropertyName("size")]
        public string Size { get; init; }
    }
}