using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator.write_container;

public static class WriteTests
{
    public static void TestHeader(Writer s, string module)
    {
        s.Wln($"using Gtker.WowMessages.Login.{module};");
        s.Newline();
        s.Wln("namespace Gtker.WowMessages.LoginTest;");
        s.Newline();

        s.OpenCurly($"public class {module}");
    }

    public static void TestFooter(Writer s)
    {
        s.ClosingCurly();
    }

    public static void WriteTest(Writer s, Container e)
    {
        for (var i = 0; i < e.Tests.Count; i++)
        {
            s.Wln("[Test]");
            s.Wln("[Timeout(500)]");
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

                s.Wln($"var c = await {e.Name}.ReadAsync(r);");
                s.Wln("Assert.That(r.Position, Is.EqualTo(r.Length));");
                s.Newline();

                s.Wln("var w = new MemoryStream();");
                s.Wln("await c.WriteAsync(w);");
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