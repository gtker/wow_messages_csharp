using System.Diagnostics;
using Generator.Extensions;
using Generator.Generated;
using Container = Generator.Generated.Container;

namespace Generator;

public static class WriteOpcodesImpl
{
    public static Writer? WriteOpcodes(IList<Container> containers, string module, string project,
        string side)
    {
        return project switch
        {
            "Login" => WriteLoginOpcodes(containers, module, project, side),
            "World" => WriteWorldOpcodes(containers, module, project, side),
            _ => throw new UnreachableException()
        };
    }

    public static Writer? WriteWorldOpcodes(IList<Container> containers, string module, string project,
        string side)
    {
        var s = new Writer();

        s.Wln("using WowSrp.Header;");
        s.Newline();

        var versionClass = WriteIncludesAndHeaders(s, module, project, side);

        WriteWorldRead(s, versionClass, module, side, EncryptOrDecrypt.Encrypt);
        WriteWorldRead(s, versionClass, module, side, EncryptOrDecrypt.Decrypt);

        s.Body(
            $"private static async Task<{versionClass}> ReadBodyAsync(Stream r, HeaderData header, CancellationToken cancellationToken = default)",
            s =>
            {
                s.Body("return header.Opcode switch", s =>
                {
                    foreach (var e in containers)
                    {
                        var bodySize = e.NeedsBodySize() ? "header.Size, " : "";
                        switch (e.ObjectType)
                        {
                            case ObjectTypeCmsg o:
                                s.Wln(
                                    $"{o.Opcode} => await {e.Name}.ReadBodyAsync(r, {bodySize}cancellationToken).ConfigureAwait(false),");
                                break;
                            case ObjectTypeSmsg o:
                                s.Wln(
                                    $"{o.Opcode} => await {e.Name}.ReadBodyAsync(r, {bodySize}cancellationToken).ConfigureAwait(false),");
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }

                    s.Wln("_ => throw new NotImplementedException()");
                }, ";");
            });

        WriteWorldExpected(s, versionClass, module, EncryptOrDecrypt.Encrypt);
        WriteWorldExpected(s, versionClass, module, EncryptOrDecrypt.Decrypt);


        s.ClosingCurly(); // public class ServerOpcodeReader

        return s;
    }

    private static void WriteWorldExpected(Writer s, string versionClass, string module, EncryptOrDecrypt encrypt)
    {
        var encrypted = encrypt == EncryptOrDecrypt.Encrypt;
        var functionName = encrypted ? "Encrypted" : "Unencrypted";
        var extraArgument = encrypted ? $", {module}Decryption decrypter" : "";
        var extraParameter = encrypted ? ", decrypter" : "";

        s.Wln("/// <summary>");
        s.Wln("/// Expects an opcode to be the next sent. Returns null if type is not correct.");
        s.Wln("/// </summary>");
        s.Body(
            $"public static async Task<T?> Expect{functionName}Opcode<T>(Stream r{extraArgument}, CancellationToken cancellationToken = default) where T: {versionClass}",
            s =>
            {
                s.Body(
                    $"if (await Read{functionName}Async(r{extraParameter}, cancellationToken).ConfigureAwait(false) is T c)",
                    s => { s.Wln("return c;"); });
                s.Newline();

                s.Wln("return null;");
            });
    }

    private static void WriteWorldRead(Writer s, string versionClass, string module, string side,
        EncryptOrDecrypt encrypt)
    {
        var encrypted = encrypt == EncryptOrDecrypt.Encrypt;
        var functionName = encrypted ? "Encrypted" : "Unencrypted";
        var extraArgument = encrypted ? $", {module}Decryption decrypter" : "";

        s.Body(
            $"public static async Task<{versionClass}> Read{functionName}Async(Stream r{extraArgument}, CancellationToken cancellationToken = default)",
            s =>
            {
                if (!encrypted)
                {
                    if (module == "Wrath")
                    {
                        s.Wln("var decrypter = new NullCrypterWrath();");
                    }
                    else
                    {
                        s.Wln("var decrypter = new NullCrypter();");
                    }
                }

                s.Wln(
                    $"var header = await decrypter.Read{side}HeaderAsync(r, cancellationToken).ConfigureAwait(false);");
                s.Newline();

                var size = side == "Server" ? 2 : 4;
                s.Body("unchecked", s => { s.Wln($"header.Size -= {size};"); });

                s.Wln("return await ReadBodyAsync(r, header, cancellationToken).ConfigureAwait(false);");
            });
    }

    public static Writer? WriteLoginOpcodes(IList<Container> containers, string module, string project,
        string side)
    {
        var s = new Writer();
        if (containers.Count == 0)
        {
            return null;
        }

        var versionClass = WriteIncludesAndHeaders(s, module, project, side);

        s.Body(
            $"public static async Task<{versionClass}> ReadAsync(Stream r, CancellationToken cancellationToken = default)",
            s =>
            {
                s.Wln("var opcode = await r.ReadByte(cancellationToken).ConfigureAwait(false);");


                s.Body("return opcode switch", s =>
                {
                    foreach (var e in containers)
                    {
                        switch (e.ObjectType)
                        {
                            case ObjectTypeClogin o:
                                s.Wln(
                                    $"{o.Opcode} => await {e.Name}.ReadAsync(r, cancellationToken).ConfigureAwait(false),");
                                break;
                            case ObjectTypeSlogin o:
                                s.Wln(
                                    $"{o.Opcode} => await {e.Name}.ReadAsync(r, cancellationToken).ConfigureAwait(false),");
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }

                    s.Wln("_ => throw new NotImplementedException(),");
                }, ";");
            });

        s.Newline();

        s.Wln("/// <summary>");
        s.Wln("/// Expects an opcode to be the next sent. Returns null if type is not correct.");
        s.Wln("/// </summary>");
        s.Body(
            $"public static async Task<T?> ExpectOpcode<T>(Stream r, CancellationToken cancellationToken = default) where T: {versionClass}",
            s =>
            {
                s.Body("if (await ReadAsync(r, cancellationToken).ConfigureAwait(false) is T c)",
                    s => { s.Wln("return c;"); });
                s.Newline();

                s.Wln("return null;");
            });

        s.ClosingCurly(); // public class ServerOpcodeReader

        return s;
    }

    private static string WriteIncludesAndHeaders(Writer s, string module, string project, string side)
    {
        s.Wln($"namespace Wow{project}Messages.{module};");
        s.Newline();

        var versionClass = $"{module}{side}Message";
        s.Wln($"public abstract class {versionClass} {{}}");
        s.Newline();

        s.OpenCurly($"public static class {side}OpcodeReader");

        return versionClass;
    }
}

public enum EncryptOrDecrypt
{
    Encrypt,
    Decrypt
}