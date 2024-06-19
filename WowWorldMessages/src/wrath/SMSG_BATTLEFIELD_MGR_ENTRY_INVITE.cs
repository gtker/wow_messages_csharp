using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_BATTLEFIELD_MGR_ENTRY_INVITE: WrathServerMessage, IWorldMessage {
    public required uint BattleId { get; set; }
    public required Wrath.Area Area { get; set; }
    public required uint AcceptTime { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(BattleId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Area, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(AcceptTime, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 14, 1246, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 14, 1246, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_BATTLEFIELD_MGR_ENTRY_INVITE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var battleId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var area = (Wrath.Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var acceptTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_BATTLEFIELD_MGR_ENTRY_INVITE {
            BattleId = battleId,
            Area = area,
            AcceptTime = acceptTime,
        };
    }

}

