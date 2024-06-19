using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class LfgJoinLockedDungeon {
    public required uint DungeonEntry { get; set; }
    public required uint Reason { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(DungeonEntry, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(Reason, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<LfgJoinLockedDungeon> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var dungeonEntry = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var reason = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new LfgJoinLockedDungeon {
            DungeonEntry = dungeonEntry,
            Reason = reason,
        };
    }

}

