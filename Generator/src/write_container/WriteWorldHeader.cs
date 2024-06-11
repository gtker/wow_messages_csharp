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

                s.Wln(
                    $"await encrypter.Write{side}HeaderAsync(w, {size}, {opcode}, cancellationToken).ConfigureAwait(false);");
                s.Newline();

                s.Wln("await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);");
            });
        s.Newline();
    }
}