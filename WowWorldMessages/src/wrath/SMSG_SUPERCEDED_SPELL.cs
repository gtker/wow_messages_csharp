using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_SUPERCEDED_SPELL: WrathServerMessage, IWorldMessage {
    public required uint NewValue { get; set; }
    public required uint Old { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(NewValue, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Old, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 10, 300, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 10, 300, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_SUPERCEDED_SPELL> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var newValue = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var old = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_SUPERCEDED_SPELL {
            NewValue = newValue,
            Old = old,
        };
    }

}

