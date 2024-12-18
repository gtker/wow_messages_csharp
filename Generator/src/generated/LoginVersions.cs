// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Generator.Generated
{
    [JsonConverter(typeof(LoginVersionsJsonConverter))]
    public abstract class LoginVersions
    {
    }

    public class LoginVersionsJsonConverter : JsonConverter<LoginVersions>
    {
        public override LoginVersions Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerCopy = reader;
            var tagValue = JsonDocument.ParseValue(ref reader).RootElement.GetProperty("login_version_tag").GetString();

            switch (tagValue)
            {
                case "all":
                    return JsonSerializer.Deserialize<LoginVersionsAll>(ref readerCopy, options);
                case "specific":
                    return JsonSerializer.Deserialize<LoginVersionsSpecific>(ref readerCopy, options);
                default:
                    throw new ArgumentException(String.Format("Bad LoginVersionTag value: {0}", tagValue));
            }
        }

        public override void Write(Utf8JsonWriter writer, LoginVersions value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
