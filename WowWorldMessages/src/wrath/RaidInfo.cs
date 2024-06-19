using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class RaidInfo {
    public required Wrath.Map Map { get; set; }
    public required Wrath.DungeonDifficulty Difficulty { get; set; }
    public required ulong InstanceId { get; set; }
    public required bool Expired { get; set; }
    public required bool Extended { get; set; }
    /// <summary>
    /// Seems to be in seconds
    /// </summary>
    public required uint TimeUntilReset { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt((uint)Map, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Difficulty, cancellationToken).ConfigureAwait(false);

        await w.WriteULong(InstanceId, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Expired, cancellationToken).ConfigureAwait(false);

        await w.WriteBool8(Extended, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TimeUntilReset, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<RaidInfo> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var map = (Wrath.Map)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var difficulty = (Wrath.DungeonDifficulty)await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var instanceId = await r.ReadULong(cancellationToken).ConfigureAwait(false);

        var expired = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var extended = await r.ReadBool8(cancellationToken).ConfigureAwait(false);

        var timeUntilReset = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new RaidInfo {
            Map = map,
            Difficulty = difficulty,
            InstanceId = instanceId,
            Expired = expired,
            Extended = extended,
            TimeUntilReset = timeUntilReset,
        };
    }

}

