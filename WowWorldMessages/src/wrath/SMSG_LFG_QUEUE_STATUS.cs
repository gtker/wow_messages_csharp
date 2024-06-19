using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
// ReSharper disable once InconsistentNaming
public class SMSG_LFG_QUEUE_STATUS: WrathServerMessage, IWorldMessage {
    public required uint Dungeon { get; set; }
    public required int AverageWaitTime { get; set; }
    public required int WaitTime { get; set; }
    public required int WaitTimeTank { get; set; }
    public required int WaitTimeHealer { get; set; }
    public required int WaitTimeDps { get; set; }
    public required byte TanksNeeded { get; set; }
    public required byte HealersNeeded { get; set; }
    public required byte DpsNeeded { get; set; }
    public required uint QueueTime { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Dungeon, cancellationToken).ConfigureAwait(false);

        await w.WriteInt(AverageWaitTime, cancellationToken).ConfigureAwait(false);

        await w.WriteInt(WaitTime, cancellationToken).ConfigureAwait(false);

        await w.WriteInt(WaitTimeTank, cancellationToken).ConfigureAwait(false);

        await w.WriteInt(WaitTimeHealer, cancellationToken).ConfigureAwait(false);

        await w.WriteInt(WaitTimeDps, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(TanksNeeded, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(HealersNeeded, cancellationToken).ConfigureAwait(false);

        await w.WriteByte(DpsNeeded, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(QueueTime, cancellationToken).ConfigureAwait(false);

    }

    public async Task WriteEncryptedServerAsync(Stream w, IServerEncrypter encrypter, CancellationToken cancellationToken = default) {
        await encrypter.WriteServerHeaderAsync(w, 33, 869, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public async Task WriteUnencryptedServerAsync(Stream w, CancellationToken cancellationToken = default) {
        var encrypter = new NullCrypterWrath();
        await encrypter.WriteServerHeaderAsync(w, 33, 869, cancellationToken).ConfigureAwait(false);

        await WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
    }

    public static async Task<SMSG_LFG_QUEUE_STATUS> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var dungeon = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var averageWaitTime = await r.ReadInt(cancellationToken).ConfigureAwait(false);

        var waitTime = await r.ReadInt(cancellationToken).ConfigureAwait(false);

        var waitTimeTank = await r.ReadInt(cancellationToken).ConfigureAwait(false);

        var waitTimeHealer = await r.ReadInt(cancellationToken).ConfigureAwait(false);

        var waitTimeDps = await r.ReadInt(cancellationToken).ConfigureAwait(false);

        var tanksNeeded = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var healersNeeded = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var dpsNeeded = await r.ReadByte(cancellationToken).ConfigureAwait(false);

        var queueTime = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new SMSG_LFG_QUEUE_STATUS {
            Dungeon = dungeon,
            AverageWaitTime = averageWaitTime,
            WaitTime = waitTime,
            WaitTimeTank = waitTimeTank,
            WaitTimeHealer = waitTimeHealer,
            WaitTimeDps = waitTimeDps,
            TanksNeeded = tanksNeeded,
            HealersNeeded = healersNeeded,
            DpsNeeded = dpsNeeded,
            QueueTime = queueTime,
        };
    }

}

