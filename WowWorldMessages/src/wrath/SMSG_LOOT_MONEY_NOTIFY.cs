using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_LOOT_MONEY_NOTIFY: WrathServerMessage, IWorldMessage {
    public required uint Amount { get; set; }
    /// <summary>
    /// Controls the text displayed in chat. False is 'Your share is...' and true is 'You loot...'
    /// </summary>
    public required bool Alone { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Amount, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Alone, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 7, 355, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 7, 355, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_LOOT_MONEY_NOTIFY> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var amount = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var alone = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new SMSG_LOOT_MONEY_NOTIFY {
            Amount = amount,
            Alone = alone,
        };
    }

}

