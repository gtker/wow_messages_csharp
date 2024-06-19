using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_BATTLEFIELD_MGR_ENTERED: WrathServerMessage, IWorldMessage {
    public required uint BattleId { get; set; }
    public required byte Unknown1 { get; set; }
    public required byte Unknown2 { get; set; }
    public required bool ClearAfk { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(BattleId, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown1, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(Unknown2, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(ClearAfk, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 9, 1248, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 9, 1248, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_BATTLEFIELD_MGR_ENTERED> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var battleId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var unknown1 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var unknown2 = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var clearAfk = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new SMSG_BATTLEFIELD_MGR_ENTERED {
            BattleId = battleId,
            Unknown1 = unknown1,
            Unknown2 = unknown2,
            ClearAfk = clearAfk,
        };
    }

}

