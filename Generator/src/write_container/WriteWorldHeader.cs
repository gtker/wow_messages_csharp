using Generator.Extensions;
using Generator.Generated;

namespace Generator.write_container;

public static class WriteWorldHeader
{
    public static void WriteHeaders(Writer s, Container e, string module)
    {
        switch (e.ObjectType)
        {
            case ObjectTypeCmsg:
                WriteWriteHeader(s, e, "Client", module, EncryptOrDecrypt.Encrypt);
                WriteWriteHeader(s, e, "Client", module, EncryptOrDecrypt.Decrypt);
                break;
            case ObjectTypeSmsg:
                WriteWriteHeader(s, e, "Server", module, EncryptOrDecrypt.Encrypt);
                WriteWriteHeader(s, e, "Server", module, EncryptOrDecrypt.Decrypt);
                break;
            case ObjectTypeStruct:
                break;
            case ObjectTypeMsg:
                WriteWriteHeader(s, e, "Client", module, EncryptOrDecrypt.Encrypt);
                WriteWriteHeader(s, e, "Client", module, EncryptOrDecrypt.Decrypt);
                WriteWriteHeader(s, e, "Server", module, EncryptOrDecrypt.Encrypt);
                WriteWriteHeader(s, e, "Server", module, EncryptOrDecrypt.Decrypt);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        ;
    }

    private static void WriteWriteHeader(Writer s, Container e, string side, string module,
        EncryptOrDecrypt encryptOrDecrypt)
    {
        var encrypted = encryptOrDecrypt == EncryptOrDecrypt.Encrypt;
        var encrypt = encrypted ? "Encrypted" : "Unencrypted";
        var arguments = encrypted ? $", I{side}Encrypter encrypter" : "";
        var compressed = e.Tags.Compressed is true;

        s.Body(
            $"public async Task Write{encrypt}{side}Async(Stream w{arguments}, CancellationToken cancellationToken = default)",
            s =>
            {
                var isWrath = module == "Wrath";
                var isServer = side == "Server";
                var size = e.Sizes.ConstantSized
                    ? (e.Sizes.MinimumSize + e.HeaderSize(isServer)).ToString()
                    : $"(uint)Size() + {e.HeaderSize(isServer)}";
                var opcode = e.Opcode();

                if (encryptOrDecrypt == EncryptOrDecrypt.Decrypt)
                {
                    var wrath = isWrath ? "Wrath" : "";
                    s.Wln($"var encrypter = new NullCrypter{wrath}();");
                }

                if (compressed)
                {
                    size = $"(uint)compressedOutput.Length + 4 + {e.HeaderSize(isServer)}";

                    s.Wln("var output = new MemoryStream();");
                    s.Wln("await WriteBodyAsync(output, cancellationToken).ConfigureAwait(false);");

                    s.Wln("var compressedOutput = new MemoryStream();");
                    s.Wln(
                        "var zlib = new System.IO.Compression.ZLibStream(compressedOutput, System.IO.Compression.CompressionMode.Compress);");
                    s.Wln("zlib.Write(output.ToArray());");
                    s.Wln("zlib.Flush();");
                    s.Newline();
                }

                s.Wln(
                    $"await encrypter.Write{side}HeaderAsync(w, {size}, {opcode}, cancellationToken).ConfigureAwait(false);");
                s.Newline();

                if (!compressed)
                {
                    s.Wln("await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);");
                }
                else
                {
                    s.Wln("await w.WriteUInt((uint)output.Length, cancellationToken).ConfigureAwait(false);");
                    s.Wln("await w.WriteAsync(compressedOutput.ToArray(), cancellationToken).ConfigureAwait(false);");
                }
            });
        s.Newline();
    }
}