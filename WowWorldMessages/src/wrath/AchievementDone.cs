using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class AchievementDone {
    public required uint Achievement { get; set; }
    public required uint Time { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Achievement, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Time, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<AchievementDone> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var achievement = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var time = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new AchievementDone {
            Achievement = achievement,
            Time = time,
        };
    }

}

