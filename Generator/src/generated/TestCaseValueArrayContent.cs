// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Generator.Generated
{
    public class TestCaseValueArrayContent
    {
        [JsonPropertyName("size")]
        public ArraySize Size { get; set; }

        [JsonPropertyName("values")]
        public IList<string> Values { get; set; }
    }
}
