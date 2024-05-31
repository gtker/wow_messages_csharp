// Code generated by jtd-codegen for C# + System.Text.Json v0.2.1

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WowMessages.Generator.Generated
{
    [JsonConverter(typeof(IfStatementEquationsJsonConverter))]
    public abstract class IfStatementEquations
    {
    }

    public class IfStatementEquationsJsonConverter : JsonConverter<IfStatementEquations>
    {
        public override IfStatementEquations Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var readerCopy = reader;
            var tagValue = JsonDocument.ParseValue(ref reader).RootElement.GetProperty("equation_tag").GetString();

            switch (tagValue)
            {
                case "BitwiseAnd":
                    return JsonSerializer.Deserialize<IfStatementEquationsBitwiseAnd>(ref readerCopy, options);
                case "Equals":
                    return JsonSerializer.Deserialize<IfStatementEquationsEquals>(ref readerCopy, options);
                default:
                    throw new ArgumentException(String.Format("Bad EquationTag value: {0}", tagValue));
            }
        }

        public override void Write(Utf8JsonWriter writer, IfStatementEquations value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
