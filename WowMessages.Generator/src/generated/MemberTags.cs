// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    public class MemberTags
    {
        [JsonPropertyName("comment")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Comment { get; set; }

        [JsonPropertyName("display")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Display { get; set; }

        /// <summary>
        /// JSON Typedef does not support integers larger than unsigned 32 bit,
        /// so this is a string
        /// </summary>
        [JsonPropertyName("maximum_length")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string MaximumLength { get; set; }

        /// <summary>
        /// JSON Typedef does not support integers larger than unsigned 32 bit,
        /// so this is a string
        /// </summary>
        [JsonPropertyName("valid_range")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public MemberTagsValidRange ValidRange { get; set; }
    }
}
