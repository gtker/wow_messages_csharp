using WowMessages.Generator.Extensions;
using WowMessages.Generator.Generated;

namespace WowMessages.Generator.write_container;

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
            ObjectTypeMsg => throw new NotImplementedException(),
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
                s.Body("Assert.Multiple(() =>", s =>
                {
                    s.Wln("Assert.That(w.Position, Is.EqualTo(r.Position));");
                    s.Wln("Assert.That(r, Is.EqualTo(w));");
                }, ");");
            });

            s.Newline();
        }
    }
}