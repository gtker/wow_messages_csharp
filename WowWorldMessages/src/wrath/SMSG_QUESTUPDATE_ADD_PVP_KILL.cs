using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_QUESTUPDATE_ADD_PVP_KILL: WrathServerMessage, IWorldMessage {
    public required uint QuestId { get; set; }
    public required uint Count { get; set; }
    public required uint PlayersSlain { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(QuestId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Count, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(PlayersSlain, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 14, 1135, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 14, 1135, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_QUESTUPDATE_ADD_PVP_KILL> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var questId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var count = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var playersSlain = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_QUESTUPDATE_ADD_PVP_KILL {
            QuestId = questId,
            Count = count,
            PlayersSlain = playersSlain,
        };
    }

}

