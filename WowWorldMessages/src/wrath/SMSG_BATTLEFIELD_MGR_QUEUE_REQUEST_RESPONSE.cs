using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_BATTLEFIELD_MGR_QUEUE_REQUEST_RESPONSE: WrathServerMessage, IWorldMessage {
    public required uint BattleId { get; set; }
    public required Wrath.Area Area { get; set; }
    public required bool Queued { get; set; }
    public required bool Full { get; set; }
    public required bool Warmup { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(BattleId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Area, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Queued, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Full, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Warmup, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 13, 1252, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 13, 1252, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_BATTLEFIELD_MGR_QUEUE_REQUEST_RESPONSE> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var battleId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var area = (Wrath.Area)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var queued = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var full = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var warmup = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        return new SMSG_BATTLEFIELD_MGR_QUEUE_REQUEST_RESPONSE {
            BattleId = battleId,
            Area = area,
            Queued = queued,
            Full = full,
            Warmup = warmup,
        };
    }

}

