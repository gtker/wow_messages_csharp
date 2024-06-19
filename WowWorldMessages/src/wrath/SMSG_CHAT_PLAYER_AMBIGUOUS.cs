using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CHAT_PLAYER_AMBIGUOUS: WrathServerMessage, IWorldMessage {
    public required string Player { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteCString(Player, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 813, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, (uint)Size() + 2, 813, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CHAT_PLAYER_AMBIGUOUS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var player = await r.ReadCString(cancellationToken).ConfigureAwait(false);

        return new SMSG_CHAT_PLAYER_AMBIGUOUS {
            Player = player,
        };
    }

    internal int Size() {
        var size = 0;

        // player: Generator.Generated.DataTypeCstring
        size += Player.Length + 1;

        return size;
    }

}

