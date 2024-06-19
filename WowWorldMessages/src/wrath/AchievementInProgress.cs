using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class AchievementInProgress {
    public required uint Achievement { get; set; }
    public required ulong Counter { get; set; }
    public required ulong Player { get; set; }
    public required bool TimedCriteriaFailed { get; set; }
    public required uint ProgressDate { get; set; }
    public required uint TimeSinceProgress { get; set; }
    public required uint TimeSinceProgress2 { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Achievement, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Counter, cancellationToken).ConfigureAwait(false);

        await w.WritePackedGuid(Player, cancellationToken).ConfigureAwait(false);

        await w.WriteBool32(TimedCriteriaFailed, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ProgressDate, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TimeSinceProgress, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(TimeSinceProgress2, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<AchievementInProgress> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var achievement = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var counter = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var player = await r.ReadPackedGuid(cancellationToken).ConfigureAwait(false);

        var timedCriteriaFailed = await r.ReadBool32(cancellationToken).ConfigureAwait(false);

        var progressDate = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var timeSinceProgress = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var timeSinceProgress2 = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new AchievementInProgress {
            Achievement = achievement,
            Counter = counter,
            Player = player,
            TimedCriteriaFailed = timedCriteriaFailed,
            ProgressDate = progressDate,
            TimeSinceProgress = timeSinceProgress,
            TimeSinceProgress2 = timeSinceProgress2,
        };
    }

    internal int Size() {
        var size = 0;

        // achievement: Generator.Generated.DataTypeInteger
        size += 4;

        // counter: Generator.Generated.DataTypePackedGuid
        size += Counter.PackedGuidLength();

        // player: Generator.Generated.DataTypePackedGuid
        size += Player.PackedGuidLength();

        // timed_criteria_failed: Generator.Generated.DataTypeBool
        size += 4;

        // progress_date: Generator.Generated.DataTypeDateTime
        size += 4;

        // time_since_progress: Generator.Generated.DataTypeInteger
        size += 4;

        // time_since_progress2: Generator.Generated.DataTypeInteger
        size += 4;

        return size;
    }

}

