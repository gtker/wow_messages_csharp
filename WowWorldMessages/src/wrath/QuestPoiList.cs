using WowSrp.Header;

namespace WowWorldMessages.Wrath;

[System.CodeDom.Compiler.GeneratedCode("WoWM", "0.1.0")]
public class QuestPoiList {
    public required uint QuestId { get; set; }
    public required List<QuestPoi> Pois { get; set; }

    public async Task WriteBodyAsync(Stream w, CancellationToken cancellationToken = default) {
        await w.WriteUInt(QuestId, cancellationToken).ConfigureAwait(false);

        await w.WriteUInt((uint)Pois.Count, cancellationToken).ConfigureAwait(false);

        foreach (var v in Pois) {
            await v.WriteBodyAsync(w, cancellationToken).ConfigureAwait(false);
        }

    }

    public static async Task<QuestPoiList> ReadBodyAsync(Stream r, CancellationToken cancellationToken = default) {
        var questId = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        // ReSharper disable once UnusedVariable.Compiler
        var amountOfPois = await r.ReadUInt(cancellationToken).ConfigureAwait(false);

        var pois = new List<QuestPoi>();
        for (var i = 0; i < amountOfPois; ++i) {
            pois.Add(await Wrath.QuestPoi.ReadBodyAsync(r, cancellationToken).ConfigureAwait(false));
        }

        return new QuestPoiList {
            QuestId = questId,
            Pois = pois,
        };
    }

    internal int Size() {
        var size = 0;

        // quest_id: Generator.Generated.DataTypeInteger
        size += 4;

        // amount_of_pois: Generator.Generated.DataTypeInteger
        size += 4;

        // pois: Generator.Generated.DataTypeArray
        size += Pois.Sum(e => e.Size());

        return size;
    }

}

