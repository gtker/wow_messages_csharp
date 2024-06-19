using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_UPDATE_INSTANCE_OWNERSHIP: WrathServerMessage, IWorldMessage {
    public required bool PlayerIsSavedToARaid { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteBool32(PlayerIsSavedToARaid, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 6, 811, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 6, 811, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_UPDATE_INSTANCE_OWNERSHIP> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var playerIsSavedToARaid = await r.ReadBool32(cancellationToken).ConfigureAwait(false);

        return new SMSG_UPDATE_INSTANCE_OWNERSHIP {
            PlayerIsSavedToARaid = playerIsSavedToARaid,
        };
    }

}

