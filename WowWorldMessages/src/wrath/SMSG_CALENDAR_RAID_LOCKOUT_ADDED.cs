using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_CALENDAR_RAID_LOCKOUT_ADDED: WrathServerMessage, IWorldMessage {
    public required uint Time { get; set; }
    public required Wrath.Map Map { get; set; }
    public required uint Difficulty { get; set; }
    public required uint RemainingTime { get; set; }
    public required ulong InstanceId { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Time, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Map, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Difficulty, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(RemainingTime, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(InstanceId, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 26, 1086, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 26, 1086, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_CALENDAR_RAID_LOCKOUT_ADDED> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var time = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var map = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var difficulty = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var remainingTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var instanceId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        return new SMSG_CALENDAR_RAID_LOCKOUT_ADDED {
            Time = time,
            Map = map,
            Difficulty = difficulty,
            RemainingTime = remainingTime,
            InstanceId = instanceId,
        };
    }

}

