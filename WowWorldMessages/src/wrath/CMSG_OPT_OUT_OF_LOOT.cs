using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_OPT_OUT_OF_LOOT: WrathClientMessage, IWorldMessage {
    public required bool PassOnLoot { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteBool32(PassOnLoot, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 8, 1033, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 8, 1033, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_OPT_OUT_OF_LOOT> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var passOnLoot = await r.ReadBool32(cancellationToken).ConfigureAwait(false);

        return new CMSG_OPT_OUT_OF_LOOT {
            PassOnLoot = passOnLoot,
        };
    }

}

