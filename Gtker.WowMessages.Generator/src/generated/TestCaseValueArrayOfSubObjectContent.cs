// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gtker.WowMessages.Generator.Generated
{
    public class TestCaseValueArrayOfSubObjectContent
    {
        [JsonPropertyName("members")]
        public IList<IList<TestCaseMember>> Members { get; init; }

        [JsonPropertyName("size")]
        public ArraySize Size { get; init; }

        [JsonPropertyName("type_name")]
        public string TypeName { get; init; }
    }
}
