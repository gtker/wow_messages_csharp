using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class LfgQuestReward {
    public required uint Item { get; set; }
    public required uint DisplayId { get; set; }
    public required uint AmountOfRewards { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(Item, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(DisplayId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(AmountOfRewards, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<LfgQuestReward> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var item = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var displayId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var amountOfRewards = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new LfgQuestReward {
            Item = item,
            DisplayId = displayId,
            AmountOfRewards = amountOfRewards,
        };
    }

}

