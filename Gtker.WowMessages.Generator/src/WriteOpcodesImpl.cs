using Gtker.WowMessages.Generator.Generated;

namespace Gtker.WowMessages.Generator;

public static class WriteOpcodesImpl
{
    public static Writer? WriteOpcodes(IEnumerable<Container> containers, string module, string project,
        string side)
    {
        var s = new Writer();

        var versionClass = $"{module}{side}Message";

        s.Wln($"namespace Gtker.WowMessages.{project}.{module};");
        s.Newline();

        s.Wln($"public abstract class {versionClass} {{}}");
        s.Newline();

        s.OpenCurly($"public static class {side}OpcodeReader");
        s.OpenCurly($"public static async Task<{versionClass}> ReadAsync(Stream r)");

        if (project == "Login")
        {
            s.Wln("var opcode = await ReadUtils.ReadByte(r);");

            s.OpenCurly("return opcode switch");
        }
        else
        {
            throw new NotImplementedException();
        }

        var hasMembers = false;

        foreach (var e in containers)
        {
            switch (e.ObjectType)
            {
                case ObjectTypeClogin o:
                    hasMembers = true;
                    s.Wln($"{o.Opcode} => await {e.Name}.ReadAsync(r),");
                    break;
                case ObjectTypeSlogin o:
                    hasMembers = true;
                    s.Wln($"{o.Opcode} => await {e.Name}.ReadAsync(r),");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        if (!hasMembers)
        {
            return null;
        }

        s.Wln("_ => throw new NotImplementedException(),");

        if (project == "Login")
        {
            s.ClosingCurly(";"); // return opcode switch
        }
        else
        {
            throw new NotImplementedException();
        }

        s.ClosingCurly(); // public static async Task<>

        s.Newline();

        s.Body($"public static async Task<T> ExpectOpcode<T>(Stream r) where T: {versionClass}", s =>
        {
            s.Body("if (await ReadAsync(r) is T c)", s => { s.Wln("return c;"); });
            s.Newline();

            s.Wln("throw new NotImplementedException();");
        });

        s.ClosingCurly(); // public class ServerOpcodeReader

        return s;
    }
}