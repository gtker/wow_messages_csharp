// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    [JsonConverter(typeof(StructMemberJsonConverter))]
    public abstract class StructMember
    {
    }

    public class StructMemberJsonConverter : JsonConverter<StructMember>
    {
        public override StructMember Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerCopy = reader;
            var tagValue = JsonDocument.ParseValue(ref reader).RootElement.GetProperty("struct_member_tag").GetString();

            switch (tagValue)
            {
                case "Definition":
                    return JsonSerializer.Deserialize<StructMemberDefinition>(ref readerCopy, options);
                case "IfStatement":
                    return JsonSerializer.Deserialize<StructMemberIfStatement>(ref readerCopy, options);
                case "Optional":
                    return JsonSerializer.Deserialize<StructMemberOptional>(ref readerCopy, options);
                default:
                    throw new ArgumentException(String.Format("Bad StructMemberTag value: {0}", tagValue));
            }
        }

        public override void Write(Utf8JsonWriter writer, StructMember value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}