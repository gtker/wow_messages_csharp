using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class CMSG_BATTLEFIELD_MGR_QUEUE_INVITE_RESPONSE: WrathClientMessage, IWorldMessage {
    public required uint BattleId { get; set; }
    public required bool Accepted { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(BattleId, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Accepted, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedClientAsync(Stream w, IClientEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteClientHeaderAsync(w, 9, 1250, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedClientAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteClientHeaderAsync(w, 9, 1250, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<CMSG_BATTLEFIELD_MGR_QUEUE_INVITE_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var battleId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var accepted = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new CMSG_BATTLEFIELD_MGR_QUEUE_INVITE_RESPONSE {
            BattleId = battleId,
            Accepted = accepted,
        };
    }

}

