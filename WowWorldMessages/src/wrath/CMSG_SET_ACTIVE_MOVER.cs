using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_SET_ACTIVE_MOVER: WrathClientMessage, IWorldMessage {
    public required ulong Guid { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Guid, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 12, 618, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 12, 618, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_SET_ACTIVE_MOVER> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var guid = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        return new CMSG_SET_ACTIVE_MOVER {
            Guid = guid,
        };
    }

}

