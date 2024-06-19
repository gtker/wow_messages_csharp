using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CROSSED_INEBRIATION_THRESHOLD: WrathServerMessage, IWorldMessage {
    public required ulong Player { get; set; }
    public required uint State { get; set; }
    public required uint Item { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteULong(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(State, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Item, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 18, 961, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 18, 961, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CROSSED_INEBRIATION_THRESHOLD> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var player = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var state = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_CROSSED_INEBRIATION_THRESHOLD {
            Player = player,
            State = state,
            Item = item,
        };
    }

}

