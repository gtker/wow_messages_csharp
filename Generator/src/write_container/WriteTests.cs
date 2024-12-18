using Generator.Extensions;
using Generator.Generated;

namespace Generator.write_container;

public static class WriteTests
{
    public static void TestHeader(Writer s, string project, string module)
    {
        s.Wln($"using Wow{project}Messages.{module};");
        s.Newline();
        s.Wln($"namespace Wow{project}Messages.Test;");
        s.Newline();

        s.OpenCurly($"public class {module}");
    }

    public static void TestFooter(Writer s)
    {
        s.ClosingCurly();
    }

    public static void WriteTest(Writer s, Container e)
    {
        var side = e.ObjectType switch
        {
            ObjectTypeClogin => "Client",
            ObjectTypeCmsg => "Client",
            ObjectTypeSlogin => "Server",
            ObjectTypeSmsg => "Server",
            ObjectTypeMsg => "Server",
            _ => throw new ArgumentOutOfRangeException()
        };

        var crypt = e.IsWorld() ? "Unencrypted" : "";
        var writeSide = e.IsWorld() ? side : "";

        for (var i = 0; i < e.Tests.Count; i++)
        {
            s.Wln("[Test]");
            s.Wln("[Timeout(1000)]");
            var test = e.Tests[i];
            s.Body($"public async Task {e.Name}{i}()", s =>
            {
                s.W("var r = new MemoryStream([");

                foreach (var b in test.RawBytes)
                {
                    s.WNoIndentation($"{b}, ");
                }

                s.WlnNoIndentation("]);");
                s.Newline();

                s.Wln($"var c = ({e.Name})await {side}OpcodeReader.Read{crypt}Async(r);");
                s.Wln("Assert.That(r.Position, Is.EqualTo(r.Length));");
                s.Newline();

                s.Wln("var w = new MemoryStream();");
                s.Wln($"await c.Write{crypt}{writeSide}Async(w);");

                if (e.AllDefinitions().Any(d => d.IsCompressed()) || e.Tags.Compressed is true)
                {
                    s.Wln("w.Seek(0, SeekOrigin.Begin);");
                    s.Wln($"var s = ({e.Name})await {side}OpcodeReader.Read{crypt}Async(w);");
                    s.Wln("var jsonOptions = new System.Text.Json.JsonSerializerOptions { Converters = { new OneOf.Serialization.SystemTextJson.OneOfJsonConverter() }};");
                    s.Wln("var cJson = System.Text.Json.JsonSerializer.Serialize(c, jsonOptions);");
                    s.Wln("var sJson = System.Text.Json.JsonSerializer.Serialize(s, jsonOptions);");
                    s.Wln("Assert.That(cJson, Is.EqualTo(sJson));");
                }
                else
                {
                    s.Body("Assert.Multiple(() =>", s =>
                    {
                        s.Wln("Assert.That(w.Position, Is.EqualTo(r.Position));");
                        s.Wln("Assert.That(r, Is.EqualTo(w));");
                    }, ");");
                }
            });

            s.Newline();
        }
    }
}