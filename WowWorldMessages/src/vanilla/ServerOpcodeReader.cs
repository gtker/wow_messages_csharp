using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

public abstract class VanillaServerMessage {}

public static class ServerOpcodeReader {
    public static async Task<VanillaServerMessage> ReadEncryptedAsync(Stream r, VanillaDecryption decrypter, CancellationToken cancellationToken = default) {
        var header = await decrypter.ReadServerHeaderAsync(r, cancellationToken).ConfigureAwait(false);

        unchecked {
            header.Size -= 2;
        }
        return await ReadBodyAsync(r, header, cancellationToken).ConfigureAwait(false);
    }
    public static async Task<VanillaServerMessage> ReadUnencryptedAsync(Stream r, CancellationToken cancellationToken = default) {
        var decrypter = new NullCrypter();
        var header = await decrypter.ReadServerHeaderAsync(r, cancellationToken).ConfigureAwait(false);

        unchecked {
            header.Size -= 2;
        }
        return await ReadBodyAsync(r, header, cancellationToken).ConfigureAwait(false);
    }
    private static async Task<VanillaServerMessage> ReadBodyAsync(Stream r, HeaderData header, CancellationToken cancellationToken = default) {
        return header.Opcode switch {
            492 => await SMSG_AUTH_CHALLENGE.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false),
            _ => throw new NotImplementedException()
        };
    }
    /// <summary>
    /// Expects an opcode to be the next sent. Returns null if type is not correct.
    /// </summary>
    public static async Task<T?> ExpectEncryptedOpcode<T>(Stream r, VanillaDecryption decrypter, CancellationToken cancellationToken = default) where T: VanillaServerMessage {
        if (await ReadEncryptedAsync(r, decrypter, cancellationToken).ConfigureAwait(false) is T c) {
            return c;
        }

        return null;
    }
    /// <summary>
    /// Expects an opcode to be the next sent. Returns null if type is not correct.
    /// </summary>
    public static async Task<T?> ExpectUnencryptedOpcode<T>(Stream r, CancellationToken cancellationToken = default) where T: VanillaServerMessage {
        if (await ReadUnencryptedAsync(r, cancellationToken).ConfigureAwait(false) is T c) {
            return c;
        }

        return null;
    }
}
