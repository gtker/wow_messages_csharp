using WowSrp.Header;

namespace WowWorldMessages.Tbc;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_CONTACT_LIST: TbcClientMessage, IWorldMessage {
    /// <summary>
    /// Sent back in [SMSG_CONTACT_LIST].
    /// </summary>
    public required uint Flags { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Flags, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 8, 102, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypter();
        await encrypter.WriteClientHeaderAsync(w, 8, 102, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_CONTACT_LIST> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var flags = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new CMSG_CONTACT_LIST {
            Flags = flags,
        };
    }

}

