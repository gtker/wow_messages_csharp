using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class QuestGiverReward {
    public required uint Item { get; set; }
    public required uint ItemCount { get; set; }
    public required uint DisplayId { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Item, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(ItemCount, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(DisplayId, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<QuestGiverReward> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var itemCount = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var displayId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new QuestGiverReward {
            Item = item,
            ItemCount = itemCount,
            DisplayId = displayId,
        };
    }

}

