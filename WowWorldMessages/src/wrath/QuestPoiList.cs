using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class QuestPoiList {
    public required uint QuestId { get; set; }
    public required uint AmountOfPois { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(QuestId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt(AmountOfPois, cancellationToken).ConfigureAwait(false);

    }

    public static async Task<QuestPoiList> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var questId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var amountOfPois = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        return new QuestPoiList {
            QuestId = questId,
            AmountOfPois = amountOfPois,
        };
    }

}

