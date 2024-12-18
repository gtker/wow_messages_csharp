// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Generator.Generated
{
    /// <summary>
    /// Represents a field in the object, and the fields for each enumerator if
    /// it's an enum/flag.
    /// </summary>
    public class PreparedObject
    {
        [JsonPropertyName("enum_part_of_separate_statements")]
        public bool EnumPartOfSeparateStatements { get; set; }

        [JsonPropertyName("is_elseif_flag")]
        public bool IsElseifFlag { get; set; }

        /// <summary>
        /// Name inside the object. Search through the original object to get
        /// type and other information.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("definer_type")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DefinerType? DefinerType { get; set; }

        /// <summary>
        /// If this is present the field contains other fields.
        /// </summary>
        [JsonPropertyName("enumerators")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public IDictionary<string, IList<PreparedObject>>? Enumerators { get; set; }
    }
}
