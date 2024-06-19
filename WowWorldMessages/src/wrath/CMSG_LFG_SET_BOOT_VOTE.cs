using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_LFG_SET_BOOT_VOTE: WrathClientMessage, IWorldMessage {
    public required bool AgreeToKickPlayer { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteBool8(AgreeToKickPlayer, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 5, 876, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 5, 876, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_LFG_SET_BOOT_VOTE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var agreeToKickPlayer = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new CMSG_LFG_SET_BOOT_VOTE {
            AgreeToKickPlayer = agreeToKickPlayer,
        };
    }

}

