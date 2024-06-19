using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_BATTLEFIELD_MGR_EJECTED: WrathServerMessage, IWorldMessage {
    public required uint BattleId { get; set; }
    public required byte Reason { get; set; }
    public required byte BattleStatus { get; set; }
    public required byte Relocated { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(BattleId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Reason, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(BattleStatus, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Relocated, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 9, 1254, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 9, 1254, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_BATTLEFIELD_MGR_EJECTED> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var battleId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var reason = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var battleStatus = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var relocated = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        return new SMSG_BATTLEFIELD_MGR_EJECTED {
            BattleId = battleId,
            Reason = reason,
            BattleStatus = battleStatus,
            Relocated = relocated,
        };
    }

}

