using WowSrp.Header;

namespace WowWorldMessages.Vanilla;

public abstract class VanillaClientMessage {}

public static class ClientOpcodeReader {
    public static async Task<VanillaClientMessage> ReadEncryptedAsync(Stream r, VanillaDecryption decrypter, CancellationToken cancellationToken = default) {
        var header = await decrypter.ReadClientHeaderAsync(r, cancellationToken).ConfigureAwait(false);

        unchecked {
            header.Size -= 4;
        }
        return await ReadBodyAsync(r, header, cancellationToken).ConfigureAwait(false);
    }
    public static async Task<VanillaClientMessage> ReadUnencryptedAsync(Stream r, CancellationToken cancellationToken = default) {
        var decrypter = new NullCrypter();
        var header = await decrypter.ReadClientHeaderAsync(r, cancellationToken).ConfigureAwait(false);

        unchecked {
            header.Size -= 4;
        }
        return await ReadBodyAsync(r, header, cancellationToken).ConfigureAwait(false);
    }
    private static async Task<VanillaClientMessage> ReadBodyAsync(Stream r, HeaderData header, CancellationToken cancellationToken = default) {
        return header.Opcode switch {
            493 => await CMSG_AUTH_SESSION.ReadBodyAsync(r, header.Size, cancellationToken).ConfigureAwait(false),
            _ => throw new NotImplementedException()
        };
    }
    /// <summary>
    /// Expects an opcode to be the next sent. Returns null if type is not correct.
    /// </summary>
    public static async Task<T?> ExpectEncryptedOpcode<T>(Stream r, VanillaDecryption decrypter, CancellationToken cancellationToken = default) where T: VanillaClientMessage {
        if (await ReadEncryptedAsync(r, decrypter, cancellationToken).ConfigureAwait(false) is T c) {
            return c;
        }

        return null;
    }
    /// <summary>
    /// Expects an opcode to be the next sent. Returns null if type is not correct.
    /// </summary>
    public static async Task<T?> ExpectUnencryptedOpcode<T>(Stream r, CancellationToken cancellationToken = default) where T: VanillaClientMessage {
        if (await ReadUnencryptedAsync(r, cancellationToken).ConfigureAwait(false) is T c) {
            return c;
        }

        return null;
    }
}
