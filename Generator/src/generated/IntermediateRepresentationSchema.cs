// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Generator.Generated
{
    public class IntermediateRepresentationSchema
    {
        [JsonPropertyName("distinct_login_versions_other_than_all")]
        public IList<byte> DistinctLoginVersionsOtherThanAll { get; set; }

        [JsonPropertyName("integer_type_information")]
        public IDictionary<string, IntermediateRepresentationSchemaIntegerTypeInformation> IntegerTypeInformation { get; set; }

        [JsonPropertyName("login")]
        public Objects Login { get; set; }

        [JsonPropertyName("login_version_opcodes")]
        public IDictionary<string, byte> LoginVersionOpcodes { get; set; }

        [JsonPropertyName("tbc_update_mask")]
        public IList<UpdateMask> TbcUpdateMask { get; set; }

        [JsonPropertyName("vanilla_update_mask")]
        public IList<UpdateMask> VanillaUpdateMask { get; set; }

        [JsonPropertyName("version")]
        public SchemaVersion Version_ { get; set; }

        [JsonPropertyName("world")]
        public Objects World { get; set; }

        [JsonPropertyName("wrath_update_mask")]
        public IList<UpdateMask> WrathUpdateMask { get; set; }
    }
}
