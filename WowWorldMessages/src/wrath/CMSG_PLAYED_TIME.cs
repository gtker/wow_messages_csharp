using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_PLAYED_TIME: WrathClientMessage, IWorldMessage {
    /// <summary>
    /// Whether the clients wants it shown on the UI. Just ping it back in [SMSG_PLAYED_TIME]
    /// </summary>
    public required bool ShowOnUi { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteBool8(ShowOnUi, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 5, 460, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 5, 460, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_PLAYED_TIME> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var showOnUi = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new CMSG_PLAYED_TIME {
            ShowOnUi = showOnUi,
        };
    }

}

